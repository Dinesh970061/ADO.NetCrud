using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Details.Models
{
    public class Dataaccess
    {
        string connectionString = "Persist Security Info=False; Integrated Security= true; Initial Catalog=Student_Details; server=.";
        //To view all student details
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getstudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student2 = new Student();
                    student2.Id = Convert.ToInt32(rdr["Student Id"]);
                    student2.Name = rdr["StudentName"].ToString();
                    student2.Age = Convert.ToInt32(rdr["StudentAge"]);
                    student2.City = rdr["StudentCity"].ToString();
                    students.Add(student2);
                }
                con.Close();
            }
            return students;
        }
        //To Add new student record
        public void AddStudent(Student student1)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("poststudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SID", student1.Id);
                    cmd.Parameters.AddWithValue("@SNAME", student1.Name);
                    cmd.Parameters.AddWithValue("@AGE", student1.Age);
                    cmd.Parameters.AddWithValue("@CITY", student1.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Sql Exception", ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine("exception", e);
                }
                finally
                {

                    con.Close();

                }
            }
        }
        //To Update the records of a particular student
        public void UpdateStudent(Student student1)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SID", student1.Id);
                    cmd.Parameters.AddWithValue("@SNAME", student1.Name);
                    cmd.Parameters.AddWithValue("@AGE", student1.Age);
                    cmd.Parameters.AddWithValue("@CITY", student1.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Sql Exception");
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {

                    con.Close();
                }
            }
        }
        //To delete the record on particular student
        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                { 
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                }
                 catch (SqlException ex)
                {
                    Console.WriteLine("Sql Exception",ex);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {

                    con.Close();
                }
            }
        }

    }
}
