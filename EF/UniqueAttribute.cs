using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Zwj.TEMS.Base {
    /// <summary>
    /// 唯一性标识
    /// </summary>
    [AttributeUsage (AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueAttribute : ValidationAttribute {
        protected string tableName;
        protected string filedName;

        public UniqueAttribute (string tableName, string filedName) {
            this.tableName = tableName;
            this.filedName = filedName;
        }

        public override Boolean IsValid (Object value) {
            bool validResult = false;
            //TEMSContext 是我项目中的DB上下文类，若需要使用在其它项目中，请更改成实际的DB上下文类就可以了！
            using (TEMSContext context = new TEMSContext ()) {
                string sqlCmd = string.Format ("select count(1) from [{0}] where [{1}]=@p0", tableName, filedName);
                context.Database.Connection.Open ();
                var cmd = context.Database.Connection.CreateCommand ();
                cmd.CommandText = sqlCmd;
                var p0 = cmd.CreateParameter ();
                p0.ParameterName = "@p0";
                p0.Value = value;
                cmd.Parameters.Add (p0);
                int result = Convert.ToInt32 (cmd.ExecuteScalar ());
                validResult = (result <= 0);
            }
            return validResult;
        }
    }
}


//  ------------------------------------------

[Required()]
[MaxLength(50)]
[Unique("Category", "CategoryCode")]
[Display(Name = "类别代码")]
public string CategoryCode { get; set; }
