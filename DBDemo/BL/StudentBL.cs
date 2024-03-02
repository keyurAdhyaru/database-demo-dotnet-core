using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DBDemo.BL
{
    public class StudentBL
    {
        public MySqlConnection _objConect;

        /// <summary>
        /// Init Object of Database.
        /// </summary>
        public StudentBL()
        {
            //STEP 1 - Create the Object of MYSQL Connection
            //_objConect = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            _objConect = new MySqlConnection("SERVER=localhost; port=3306; DATABASE=student; username=root; PASSWORD='123456'");
        }

        /// <summary>
        /// Get All Students Data
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetStudent()
        {
            //STEP 2 : Create Query and datatable
            DataTable studentTbl = new DataTable();

            //Query 
            string _studentQuery = string.Format(@"SELECT * FROM STD01");

            try
            {
                //STEP 4 : Open Connection
                _objConect.Open();

                //STEP 5: Create Adapter Object
                using (MySqlDataAdapter da = new MySqlDataAdapter(_studentQuery, _objConect))
                {
                    //STEP 6 : Fill data
                    da.Fill(studentTbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Close the Connection
                _objConect.Close();
            }
            
            return studentTbl;
        }

        /// <summary>
        /// Insert Data into table
        /// </summary>
        /// <param name="studentName">Name of the Student</param>
        /// <param name="studentEnd">enrollment Number</param>
        /// <param name="sem">Current Sem</param>
        /// <returns>String Message</returns>
        public string InsertStudent(string studentName, string studentEnd, int sem)
        {
            int result = 0;

            try
            {
                //STEP 2 : Create Command Object 
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    //SETP 3 : Open Connection
                    _objConect.Open();

                    //STEP 4 : SetUp Query String to Command Text
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = _objConect;
                    cmd.CommandText = "INSERT INTO STD01(D01F02,D01F03) VALUES(@name, @endrol)";

                    //STEP 5 : Add Parameters to Query.
                    cmd.Parameters.AddWithValue("@name", studentName);
                    cmd.Parameters.AddWithValue("@endrol", studentEnd);

                    //STEP 6 : Execute Query.
                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _objConect.Close();
            }

            if (result == 1)
            {
                return "User Inserted Successfully";
            }
            else
            {
                return "User not Inserted";
            }
        }

        public string UpdateStudent(int id, string studentName, string studentEnd, int sem)
        {
            int result = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    _objConect.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = _objConect;
                    cmd.CommandText = "UPDATE STD01 SET D01F02 = @name,D01F03 = @endrol,D01F04 = @sem WHERE D01F01 = @id";

                    cmd.Parameters.AddWithValue("@name", studentName);
                    cmd.Parameters.AddWithValue("@endrol", studentEnd);
                    cmd.Parameters.AddWithValue("@sem", sem);
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _objConect.Close();
            }

            if (result == 1)
            {
                return "Student Data Updated Successfully";
            }
            else
            {
                return "Student Data not Updated";
            }
        }

        public string DeleteStudent(int id)
        {
            int result = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    _objConect.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = _objConect;
                    cmd.CommandText = "DELETE FROM STD01 WHERE D01F01 = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _objConect.Close();
            }

            if (result == 1)
            {
                return "Student Data Deleted Successfully";
            }
            else
            {
                return "Student Data not Deleted";
            }
        }
    }
}
