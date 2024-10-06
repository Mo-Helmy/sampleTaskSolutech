using Microsoft.EntityFrameworkCore;

namespace Task.Core.Interfaces;

public partial interface IMappingConfiguration
{
    void ApplyConfiguration(ModelBuilder modelBuilder);
}