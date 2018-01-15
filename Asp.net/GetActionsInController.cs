

// 获取controller中的所有action和description
Assembly asm = Assembly.GetAssembly(typeof(NjModelmgr.MvcApplication));
var controlleractionlist = asm.GetTypes()
        .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
        .Select(x => new
        {
            Controller = x.DeclaringType.Name,
            Action = x.Name,
            Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
            Description = ((DescriptionAttribute)x.GetCustomAttribute(typeof(DescriptionAttribute))) == null ? "" : ((DescriptionAttribute)x.GetCustomAttribute(typeof(DescriptionAttribute))).Description
        })
        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
var jsonData = JsonConvert.SerializeObject(controlleractionlist);
            return Content(jsonData);
