using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using N01533897_Assign3_W2022.Models;
using MySql.Data.MySqlClient;

namespace N01533897_Assign3_W2022.Controllers
{
    public class StudentDataController : ApiController
    {
        //Access the MySql Database

        private SchoolDbContext School = new SchoolDbContext();

        //This Controller will access the students table of our DB
        /// <summary>
        /// Returns a list of students
        /// </summary>
        /// <example> GET api/StudentData/ListStudents</example>
        /// <returns>
        /// a list of students (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Student> ListStudents()
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //Write SQL query
            command.CommandText = "Select * from students";

            //Gather results into a variable
            MySqlDataReader Result = command.ExecuteReader();

            //Create empty list to add each student
            List<Student> Students = new List<Student> { };

            //While loop for each row
            while (Result.Read())
            {
                //Access each column info by using db column names
                int StudentId = Convert.ToInt32(Result["studentid"]);
                string StudentFname = Result["studentfname"].ToString();
                string StudentLname = Result["studentlname"].ToString();
                string StudentNumber = Result["studentnumber"].ToString();
                DateTime EnrolDate = Convert.ToDateTime(Result["enroldate"]);

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;


                //Add student into the list created before the loop
                Students.Add(NewStudent);
            }

            //Close the db connection
            Connection.Close();

            //Return list of students
            return Students;

        }


        /// This Controller will find a specific student with his/her id on DB table
        /// <summary>
        /// it will find a student in the system based on Student's id
        /// </summary>
        /// <param name="id">The student primary key</param>
        /// <returns>A student object</returns>
        [HttpGet]
        public Student FindStudent(int id)
        {
            //Create a connection
            MySqlConnection Connection = School.AccessDatabase();

            //Open the connection between local db and web server
            Connection.Open();

            //New command - Query for DB
            MySqlCommand command = Connection.CreateCommand();

            //Write SQL query
            command.CommandText = "Select * from Students where studentid = " + id;

            //Gather results into a variable
            MySqlDataReader Result = command.ExecuteReader();

            //Create an empty list to add selected student
            Student NewStudent = new Student();



            //While loop for each row
            while (Result.Read())
            {
                //Access each column info by using db column names
                int StudentId = Convert.ToInt32(Result["studentid"]);
                string StudentFname = Result["studentfname"].ToString();
                string StudentLname = Result["studentlname"].ToString();
                string StudentNumber = Result["studentnumber"].ToString();
                DateTime EnrolDate = Convert.ToDateTime(Result["enroldate"]);

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;

            }

            //Close the db connection
            Connection.Close();

            //Return list of students
            return NewStudent;

        }
    }
}
