using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Task.Application.StoreServices.Dto;
using Task.Infrastructure.Data;

namespace Task.Application.StoreServices;

public class AddStoreCommandValidator : AbstractValidator<AddStoreCommandDto>
{
    public AddStoreCommandValidator(AppDbContext appDbContext)
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(r => r.IsMain).Custom((isMain, context) =>
        {
            if (isMain)
            {
                var currentMainStore = appDbContext.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.IsMain).GetAwaiter().GetResult();
                if (currentMainStore != null) context.AddFailure("IsMain", "only one store can be marked as main store");
            }
        });

    }
}
