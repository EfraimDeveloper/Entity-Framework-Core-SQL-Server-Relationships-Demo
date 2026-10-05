using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_relationship_between_the_table.Models
{
    public class StudentCourse
    {
        public int studentId { get; set; } //foreign students
        public Student Student { get; set; } // propriety nevegation

        public int CourseId { get; set; }  // foreign couses
        public Course Course { get; set; } // the propriety navgation 
    }
}
