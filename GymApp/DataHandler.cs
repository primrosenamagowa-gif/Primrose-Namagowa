using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    internal class DataHandler
    {
        public DataHandler() { }

        static string connect = "Data Source= DESKTOP-BV4MNMQ\\SQLEXPRESS01;Initial Catalog=GymDB; Integrated Security=SSPI";

        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter;

        public void registerMember(string memberID, string firstName, string lastName, string gender, string phoneNumber, string address, string trainingProgram, DateTime dob, DateTime start, DateTime end)
        {
            string query = $"INSERT INTO MemberData VALUES('{memberID}','{firstName}','{lastName}','{gender}','{phoneNumber}','{address}','{trainingProgram}','{dob}','{start}','{end}')";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Member Details Saved");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Member Details not Saved" + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

        public DataTable ReadData()
        {
            string query = @"SELECT * FROM MemberData";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                adapter.Fill(table);
                return table;
            }

        }

        public void UpdateData(string memberID, string firstName, string lastName, string gender, string phoneNumber, string address, string trainingProgram, DateTime dob, DateTime start, DateTime end)
        {
            string query = $"UPDATE MemberData SET[memberID] = '{memberID}', [firstName] = '{firstName}', [lastName] = '{lastName}', [gender] = '{phoneNumber}', [phoneNumber] = '{phoneNumber}', [address] = '{address}', [trainingProgram] = '{trainingProgram}', [dob] = '{dob}',[start] = '{start}', [end] = '{end}' WHERE [memberID] = '{memberID}'";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details Updated");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Details Not Updated" + ex.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        public void DeleteData(string memberID)
        {
            string query = $"DELETE FROM MemberData WHERE MemberID = '{memberID}'";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details Deleted");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Details Not DEleted" + ex.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        public DataTable Search(string memberID)
        {
            string query = $"SELECT * FROM MemberData WHERE MemberID = '{memberID}';";
            conn = new SqlConnection(connect);
            adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }

        public void AddPrograms(string classID, string name, string descriptor, string instructor, string schedule, string capacity, string duration)
        {
            string query = $"INSERT INTO ProgramData VALUES('{classID}','{name}','{descriptor}','{instructor}','{schedule}', '{capacity}','{duration})";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Program Details Saved");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Program Details not Saved" + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

        public DataTable ReadPrograms()
        {
            string query = @"SELECT * FROM ProgramData";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                adapter.Fill(table);
                return table;
            }

        }

        public void UpdatePrograms(string classID, string name, string descriptor, string instructor, string schedule, string    capacity, string duration)
        {
            string query = $"UPDATE ProgramData SET[ClassID] = '{classID}', [ProgramName] = '{name}', [Descriptor] = '{descriptor}', [Instruction] = '{instructor}', [Schedule] = '{schedule}', [Capacity] = '{capacity}', [Duration] = '{duration}' WHERE [memberID] = '{classID}'";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details Updated");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Details Not Updated" + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }

        public void DeleteProgram(string classID)
        {
            string query = $"DELETE FROM ProgramData WHERE ClassID = '{classID}'";
            conn = new SqlConnection(connect);
            conn.Open();
            command = new SqlCommand(query, conn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details Deleted");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Details Not Deleted" + ex.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        public DataTable SearchPrograms(string classID)
        {
            string query = $"SELECT * FROM ProgramData WHERE ClassID = '{classID}';";
            conn = new SqlConnection(connect);
            adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }



    }


}
