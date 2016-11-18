using Entity;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET例子.Dal
{


    public class DalOrder
    {
        private string conn_string = "Data Source=localhost;Initial Catalog=SQLtest;Integrated Security=True";

        // 查询
        public Order SelectOrder(int OrderId)
        {

            //1.建立链接
            SqlConnection connection = new SqlConnection(conn_string);

            //2.执行查询 
            SqlCommand sqcommand = new SqlCommand("SelectOrderAll", connection);
            sqcommand.CommandType = CommandType.StoredProcedure;   // 将命令变为存储过程的方式
            SqlParameter sp_id = new SqlParameter("OrderId", OrderId);
            sqcommand.Parameters.Add(sp_id);
            SqlDataAdapter adapter = new SqlDataAdapter(sqcommand);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            
            //3.显示数据
            connection.Close();

            Order oo = new Order();
          

            if(ds != null && ds.Rows.Count>0)
            {
                DataRow row = ds.Rows[0];
                if(row["id"] != null)
                {
                    oo.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    oo.name = row["name"].ToString();
                }
                if (row["description"] != null)
                {
                    oo.description = row["description"].ToString();
                }
                if (row["amount"] != null)
                {
                    oo.amount = int.Parse(row["amount"].ToString());
                }
                if (row["price"] != null)
                {
                    oo.price = int.Parse(row["price"].ToString());
                }
                        
            }
            return oo;

            //dataGridView1.DataSource = ds;
        }

        public int AddOrder(Order or)
        {

            SqlConnection connection = new SqlConnection(conn_string);
            SqlCommand sqcommand = new SqlCommand("InsertOrder", connection);
            sqcommand.CommandType = CommandType.StoredProcedure;   // 将命令变为存储过程的方式
            SqlParameter sp_id = new SqlParameter("id", or.id);
            sqcommand.Parameters.Add(sp_id);
            SqlParameter sp_name = new SqlParameter("name", or.name);
            sqcommand.Parameters.Add(sp_name);
            SqlParameter sp_des = new SqlParameter("description", or.description);
            sqcommand.Parameters.Add(sp_des);
            SqlParameter sp_amount = new SqlParameter("amount", or.amount);
            sqcommand.Parameters.Add(sp_amount);
            connection.Open();
            int cc = sqcommand.ExecuteNonQuery();
            connection.Close();
            return cc;
        }
    }
}
