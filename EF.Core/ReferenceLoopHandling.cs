在EF 6.x之前版本中因为导航属性的存在很容易导致循环引用，
所以对于EF Core同样是如此我们需要在Startup.cs中忽略循环引用

services.AddMvc()
        .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
