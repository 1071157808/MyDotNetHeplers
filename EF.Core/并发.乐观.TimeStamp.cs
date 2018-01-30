//乐观并发
//Code First使用[Timestamp] 处理乐观并发性的属性
using System.Data.Entity;

namespace ConcurrencyCheck.Models
{
    class EducationContext : DbContext
    {
        public EducationContext()
            : base("EducationContext")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace ConcurrencyCheck.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string RollNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}


