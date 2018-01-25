//查询
SqlCommand sqcommand = newSqlCommand("SelectAll", connection);
sqcommand.CommandType=CommandType.StoredProcedure;// 将命令变为存储过程的方式
SqlDataAdapter adapter = newSqlDataAdapter(sqcommand);
DataTable ds = newDataTable();
adapter.Fill(ds);
dataGridView1.DataSource= ds;
 connection.Close();
