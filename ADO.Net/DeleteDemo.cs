//删除
string id = txt_id.Text.Trim();
string conn_string = "Data Source=localhost;Initial Catalog=SQLtest;Integrated Security=True";
SqlConnection connection = newSqlConnection(conn_string);
SqlCommand sqcommand = newSqlCommand("DeleteInfo", connection);
sqcommand.CommandType=CommandType.StoredProcedure;// 将命令变为存储过程的方式
SqlParameter sp = newSqlParameter("ID", id);
sqcommand.Parameters.Add(sp);
connection.Open();
sqcommand.ExecuteNonQuery();
