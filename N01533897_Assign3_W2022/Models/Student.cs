using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N01533897_Assign3_W2022.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFname { get; set; }
        public string StudentLname { get; set; }
        public string StudentNumber { get; set; }
        public DateTime EnrolDate { get; set; }
    }
}