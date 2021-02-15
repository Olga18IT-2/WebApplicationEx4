using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Requests
    {
        public SqlConnection sqlConnection;
        public string sql;
        public SqlCommand cmd;
        public SqlDataReader reader;
        public string connectionString;
        
        public Requests()
        {
            sqlConnection = null;
            connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        private string GetDate()
        {
            string[] nowArr = DateTime.Now.ToShortDateString().Split('.');
            return nowArr[2] + "-" + nowArr[1] + "-" + nowArr[0];
        }
        public void OpenConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                 sqlConnection.Close();
        }
        public void Add_user(string login, string pasword, string name, string email)
        {
            OpenConnection();
            sql = "Insert INTO Users Values ('"+login+"', '"+pasword+"', '"+name+
                "', '"+email+"', '"+GetDate()+"', '"+GetDate()+"', 'NOT blocked')";
            cmd = new SqlCommand(sql, sqlConnection); int number = cmd.ExecuteNonQuery();
            CloseConnection();
        }
        public string Pasword_and_status_by_login(string login)
        {
            string answer = "";
            OpenConnection();
            sql = "Select * From Users Where (Login = '" + login + "')";
            cmd = new SqlCommand(sql, sqlConnection);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {   while (reader.Read())
                { answer = answer + reader["Pasword"].ToString() + "#" + reader["Status"].ToString(); }
            }
            reader.Close();
            CloseConnection();
            return answer;
        }
        public void Update_status(int id, string status)
        {
            OpenConnection();
            sql = "Update Users SET Status = '" + status + "' Where (Id = " + id + ")";
            cmd = new SqlCommand(sql, sqlConnection); int number = cmd.ExecuteNonQuery();
            CloseConnection();

        }
        public void Update_last_login(string login)
        {
            OpenConnection();
            sql = "Update Users SET Date_last_login = '" + GetDate() + "' Where (Login = '" + login + "')";
            cmd = new SqlCommand(sql, sqlConnection); int number = cmd.ExecuteNonQuery();
            CloseConnection();
        }
        public void Delete_user(int id)
        {
            OpenConnection();
            sql = "Delete from Users Where (Id =" + id + ")";
            cmd = new SqlCommand(sql, sqlConnection); int number = cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }
}