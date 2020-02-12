using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        /// <summary>
        ///  使用 ICollection<Enrollment> 时，EF Core 会默认创建 HashSet<Enrollment> 集合。
        /// </summary>
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
