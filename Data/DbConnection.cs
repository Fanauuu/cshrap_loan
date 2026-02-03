using System.Configuration;
using Microsoft.Data.SqlClient;
using System;

namespace WinFormsApp1.Data
{
    public class DbConnection
    {
        public SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            if (connStr == null){
                throw new Exception("Connection string 'DbConnection' not found");
            }else{
                Console.WriteLine("Logged connection string: " + connStr);
            }
            return new SqlConnection(connStr);
        }
    }
}
