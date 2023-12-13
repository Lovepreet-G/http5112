using MySql.Data.MySqlClient;
using Cumulative_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;



namespace Cumulative_3.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <returns>
        /// A list of Teachers including (id,firstname, last name, employeeNumber, hireDate and salary)
        /// </returns>
        /// 
        /// <example>
        /// 
        /// GET api/TeacherData/ListTeachers -> 
        /// 
        /// <Teacher>
        /// <EmployeeNumber>T378</EmployeeNumber>
        /// <HireDate>05-08-2016 00:00:00</HireDate>
        /// <Salary>55.30</Salary>  
        /// <TeacherFname>Alexander</TeacherFname>
        /// <TeacherId>1</TeacherId>
        /// <TeacherLname>Bennett</TeacherLname>
        /// </Teacher>
        /// ....
        /// </example>


        [HttpGet]
        [Route("api/TeacherData/ListTeachers")]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection 
            Conn.Open();

            //create a command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //Query
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //While Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];


                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.employeenumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;

                //Add the Teachers to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection 
            Conn.Close();

            //Return the final list of teachers
            return Teachers;
        }

        /// <summary>
        /// Finds an teacher in the system given an ID
        /// </summary>
        /// <param name="id">The teacher primary key</param>
        /// <returns>The information of a particular teacher (employee no, hire date, salary, teacher fname, teacher id, teacher lname) </returns>
        /// 
        /// <example>
        /// 
        /// GET api/TeacherData/ListTeachers/4 ->
        /// 
        /// <EmployeeNumber>T385</EmployeeNumber>
        /// <HireDate>2012-06-22T00:00:00</HireDate>
        /// <Salary>74.20</Salary>
        /// <TeacherFname>Lauren</TeacherFname>
        /// <TeacherId>4</TeacherId>
        /// <TeacherLname>Smith</TeacherLname>
        /// 
        /// </example>


        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{id}")]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection 
            Conn.Open();

            //create a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //query
            cmd.CommandText = "Select * from Teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //While Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.employeenumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            //Returns that particular teacher info
            return NewTeacher;
        }
        /// <summary>
        /// Deletes teacher info in the system through an ID
        /// </summary>
        /// <param name="id">The teacher id</param>
        /// 
        /// 
        /// <example>
        /// 
        /// POST /api/TeacherData/DeleteTeacher/5 ->
        /// 
        /// </example>

        [HttpPost]
        public void DeleteTeacher(int id)
        {

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }
        /// <summary>
        /// Adds a teacher into the database
        /// </summary>
        /// <param name="NewTeacher">Objects which contains teacher table columns names</param>
        /// 
        /// 
        /// <example>
        /// 
        /// POST api/TeacherData/AddTeacher
        /// {
        ///	    "TeacherFname":"Lovepreet",
        ///	    "TeacherLname":"Singh",
        ///	    "EmployeeNumber":"T123",
        ///	    "HireDate":"12/12/2023 04:55:00 AM"
        ///	    "Salary":"90.00"
        /// }
        /// </example>

        [HttpPost]
        public void AddTeacher([FromBody] Teacher NewTeacher)
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "insert into teachers ( teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname,@TeacherLname,@EmployeeNumber, CURRENT_DATE(),@Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.employeenumber);
            cmd.Parameters.AddWithValue("@HireDate", NewTeacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }
        /// <summary>
        /// Updates an teacher into the database
        /// </summary>
        /// <param name="TeacherInfo">Objects which contains teacher table columns names</param>
        /// 
        /// 
        /// <example>
        /// 
        /// POST : /Teacher/Update/5
        /// {
        ///	    "TeacherFname":"Lovepreet",
        ///	    "TeacherLname":"Singh",
        ///	    "EmployeeNumber":"T123",
        ///	    "Salary":"90.00"             
        /// }
        /// </example>
        /// 
        /// 
        [HttpPost]
        public void UpdateTeacher(int id, [FromBody] Teacher TeacherInfo)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "update teachers set teacherfname=@TeacherFname, teacherlname=@TeacherLname, employeenumber=@EmployeeNumber, salary=@Salary  where teacherid=@TeacherId";
            cmd.Parameters.AddWithValue("@TeacherFname", TeacherInfo.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", TeacherInfo.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", TeacherInfo.employeenumber);
            cmd.Parameters.AddWithValue("@Salary", TeacherInfo.Salary);
            cmd.Parameters.AddWithValue("@TeacherId", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }


    }
}