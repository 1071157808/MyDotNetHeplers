modelBuilder.Entity<Blog>()
.MapToStoredProcedures(s =>
    s.Update(u => u.HasName("Update_Blog"))
    .Delete(d => d.HasName("Delete_Blog"))
    .Insert(i => i.HasName("Insert_Bblog")));

我感觉这个方式生成的存储过程不好用，还不如直接用sql来写
下面的应该是dbfirst的方法，所以codefirst应该使用直接执行sql语句的方

NorthwindEntities ne = new NorthwindEntities();
           var s =  ne.GetCustomerFun("ALFKI");   // GetCustomerFun这个就是存储过程的名称，ALFKI是存储过程需要的值
           //this.GridView1.DataSource = s;
           //this.GridView1.DataBind();
           var list = s.ToList();


