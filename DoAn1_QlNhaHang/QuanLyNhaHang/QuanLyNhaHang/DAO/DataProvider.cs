using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class DataProvider
    {
        private string strcon = "Data Source=DESKTOP-JPN0TR7;Initial Catalog=QL_NhaHang;Integrated Security=True;";

        public static object Instance { get; internal set; }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;  
                    foreach (string para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            command.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
            public int ExecuteNonQuery(string query, object[] parameter = null)
            {
                int data = 0;
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteNonQuery();
                    con.Close();
                }
                return data;
            }
        //tra ve 1 cot dau tien cua dong bang ket qua 
        //public object ExecuteScalar(string query, object[] parameter = null)
        //{
        //    object data = 0;
        //    using (SqlConnection con = new SqlConnection(strcon))
        //    {
        //        con.Open();
        //        SqlCommand command = new SqlCommand(query, con);
        //        if (parameter != null)
        //        {
        //            string[] listPara = query.Split(' ');
        //            int i = 0;
        //            foreach (string item in listPara)
        //            {
        //                if (item.Contains('@'))
        //                {
        //                    command.Parameters.AddWithValue(item, parameter[i]);
        //                    i++;
        //                }
        //            }
        //        }
        //        data = command.ExecuteScalar();
        //        con.Close();
        //    }
        //    return data;
        //}
    }
}
