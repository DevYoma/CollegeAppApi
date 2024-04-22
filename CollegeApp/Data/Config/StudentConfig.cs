using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApp.Data.Config
{
    public class StudentConfig: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(t => t.Id);

            // making the ID column the Identity
            builder.Property(t => t.Id).UseIdentityColumn(); 

            builder.Property(n => n.StudentName).IsRequired().HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);

            builder.HasData(new List<Student>()
            {
                new Student {
                    Id = 1,
                    StudentName = "Yoma",
                    Address = "Github",
                    Email = "yoma@gmail.com",
                    DOB = new DateTime(2024, 4, 25)
                },
                   new Student {
                    Id = 2,
                    StudentName = "Maga",
                    Address = "Guitar Island",
                    Email = "emoremaaga@gmail.com",
                    DOB = new DateTime(2024, 7, 1)
                }
            });
        }

        //public void Configure(EntityTypeBuilder<Student> builder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
