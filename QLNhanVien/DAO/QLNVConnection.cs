using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class QLNVConnection
    {
        private const string strConnection = @"Data Source=LAPTOP-OUMK55PL\SQLEXPRESS;
                                                Initial Catalog=QLNV;
                                                Integrated Security=True;
                                                TrustServerCertificate=True";
        private static SqlConnection instance;
        private QLNVConnection() { }

        public static SqlConnection getInstance()
        {
            if (instance == null)
            {
                instance = new SqlConnection(strConnection);
            }
            return instance;
        }
        public static void open()
        {
            if (instance.State == ConnectionState.Closed)
                instance.Open();
        }
        public static void close()
        {
            if (instance.State == ConnectionState.Open)
                instance.Close();
        }
    }
}
