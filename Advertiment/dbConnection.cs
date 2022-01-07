using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Advertiment
{
    public class dbConnection
    {
        string ConnectionString = @"Data Source=PCBONG\SQLEXPRESS;Initial Catalog=db;Integrated Security=True";
        SqlConnection con;

        SqlDataAdapter adapter;
        DataTable table;
        SqlCommand command;

        public void OpenConnection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }
        public void ExecuteQueries(string Query_)
        {
            OpenConnection();
            command = new SqlCommand(Query_,con);
            command.ExecuteNonQuery();
            CloseConnection();
        }
        public SqlDataReader DataReader(string Query_)
        {
            command = new SqlCommand(Query_ ,con);   
            SqlDataReader dr = command.ExecuteReader();
            return dr;
        } 
        public object ShowDataInGridView (string Query_)
        {
            adapter = new SqlDataAdapter(Query_,ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        public int GetLastID(string query)
        {
            OpenConnection();
            command = new SqlCommand(query, con);
            return (int)command.ExecuteScalar();
        }

        public DataTable GetData(string query)
        {
            adapter = new SqlDataAdapter(query, ConnectionString);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataSet GetName(string query)
        {
            OpenConnection ();
            command = new SqlCommand(query ,con);
            adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }


    }
}
