using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Surname).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Age).IsRequired();
        }
    }
}
