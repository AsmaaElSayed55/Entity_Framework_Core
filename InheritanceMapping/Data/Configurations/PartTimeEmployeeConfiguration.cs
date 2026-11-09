using InheritanceMapping.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Data.Configurations
{
    public class PartTimeEmployeeConfiguration : IEntityTypeConfiguration<PartTimeEmployee>
    {
        void IEntityTypeConfiguration<PartTimeEmployee>.Configure(EntityTypeBuilder<PartTimeEmployee> builder)
        {
          //  builder.HasBaseType<Employee>();
        }
    }
}
