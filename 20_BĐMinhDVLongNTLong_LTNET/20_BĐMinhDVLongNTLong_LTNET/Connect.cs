using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _20_BĐMinhDVLongNTLong_LTNET
{
    class Connect
    {
        private SqlConnection Conn;
        private SqlCommand sqlCommand;
        private string StrCon = null;
        private string error;


        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        public SqlConnection Connection
        {
            get { return Conn; }
        }
        public SqlCommand CMD
        {
            get { return sqlCommand; }
            set { sqlCommand = value; }
        }

        public Connect()
        {
            StrCon = "Data Source=(local);Initial Catalog=qlhh_Nhom20_BĐMinhDVLongNTLong;Integrated Security=True";
            Conn = new SqlConnection(StrCon);
        }


        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool CloseConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Conn;
            try
            {
                this.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                sqlCommand.Dispose();
                this.CloseConn();
            }
            return dt;
        }

        public bool SetData(string sql)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Conn;
            try
            {
                this.OpenConn();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                sqlCommand.Dispose();
                this.CloseConn();
            }
            return false;
        }
    }
}
