//添加
string id = txt_id.Text.Trim();
string username = txt_username.Text.Trim();
string ps = txt_ps.Text.Trim();
string date = txt_date.Text.Trim();
string conn_string = "Data Source=localhost;Initial Catalog=SQLtest;Integrated Security=True";
SqlConnection connection = newSqlConnection(conn_string);
SqlCommand sqcommand = newSqlCommand("InsertInto", connection);
sqcommand.CommandType=CommandType.StoredProcedure;// 将命令变为存储过程的方式
SqlParameter sp_id = newSqlParameter("ID", id);
sqcommand.Parameters.Add(sp_id);
SqlParameter sp_username = newSqlParameter("Username", username);
sqcommand.Parameters.Add(sp_username);
SqlParameter sp_password = newSqlParameter("Password", ps);
sqcommand.Parameters.Add(sp_password);
SqlParameter sp_date = newSqlParameter("Date", date);
sqcommand.Parameters.Add(sp_date);
connection.Open();
int cc = sqcommand.ExecuteNonQuery();
