using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Task.Application.StoreServices.Dto;
using Task.Infrastructure.Data;

namespace Task.Application.StoreServices;

public class SplitStoreSpaceCommandValidator : AbstractValidator<SplitStoreSpaceCommandDto>
{
    public SplitStoreSpaceCommandValidator(AppDbContext appDbContext)
    {
        RuleFor(r => r.StoreId).Custom((storeId, context) =>
        {
                var currentMainStore = appDbContext.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == storeId).GetAwaiter().GetResult();
                if (currentMainStore == null) context.AddFailure("StoreId", "store not exist");
        });

    }
}
