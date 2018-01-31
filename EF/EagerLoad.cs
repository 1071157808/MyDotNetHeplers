 //热情加载
//使用Include方法关联预先加载的实体
 stud = ctx.Students.Include ("Standard")
     .Where (s => s.StudentName == "Student1").FirstOrDefault<Student> ();