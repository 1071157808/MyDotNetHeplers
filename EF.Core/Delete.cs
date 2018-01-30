Student studentToDelete = new Student () { ID = id };
 _context.Entry (studentToDelete).State = EntityState.Deleted;





 .withMany("Posts")
 .HasForeignKey("BlogId")
 .OnDelete(DeleteBehavior.Cascade)