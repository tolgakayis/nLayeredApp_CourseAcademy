using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId");

            builder.Property(b => b.CourseName).HasColumnName("CourseName").IsRequired();
            builder.Property(b => b.CourseDescription).HasColumnName("CourseDescription");

            builder.HasIndex(indexExpression: b => b.CourseName, name: "UK_Courses_CourseName").IsUnique();

            builder.HasOne(c => c.Category).WithMany(i => i.Courses).HasForeignKey(c => c.CategoryId);
            builder.HasOne(b => b.Instructor).WithMany(i => i.Courses).HasForeignKey(c => c.InstructorId);


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
