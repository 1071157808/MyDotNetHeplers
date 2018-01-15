 //下面的调试代码可以让保存时的错误输出到日志或者其他自定义的位置
 public override int SaveChanges () {
     try {
         return base.SaveChanges ();
     } catch (DbEntityValidationException dbEx) {
         foreach (var validationErrors in dbEx.EntityValidationErrors) {
             foreach (var validationError in validationErrors.ValidationErrors) {
                 //Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                 //    validationErrors.Entry.Entity.GetType().FullName,
                 //    validationError.PropertyName,
                 //    validationError.ErrorMessage);
                 Logger.Info (validationErrors.Entry.Entity.GetType ().FullName.ToString () + "  " + validationError.PropertyName.ToString () + " " + validationError.ErrorMessage.ToString ());
             }
         }
         return 0;