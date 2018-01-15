 protected override void Seed(AspNetMVCEssential.Models.ApplicationDbContext context)
        {
            //UserStore一定要使用context作为参数
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "liulixiang1988"))
            {
                //1、创建用户
                var user = new ApplicationUser { UserName = "liulixiang1988", Email = "liulixiang1988@gmail.com" };
                //下面这句会创建一个用户并且会立即执行，不需调用SaveChanges
                userManager.Create(user, "passW0rd");

                //2、创建用户相关的账户
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("liulixiang1988", "管理员", user.Id, 1000);

                //3、添加角色并保存
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                //4、给用户添加角色，指定Id和角色名
                userManager.AddToRole(user.Id, "Admin");

            }
        }
