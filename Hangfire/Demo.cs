RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Daily);
RecurringJob.AddOrUpdate(() => Console.Write("Powerful!"), "0 12 * */2");
RecurringJob.AddOrUpdate("some-id", () => Console.WriteLine(), Cron.Hourly);
RecurringJob.RemoveIfExists("some-id");
RecurringJob.Trigger("some-id");
RecurringJob.AddOrUpdate(() => Console.Write("Easy!"), Cron.Daily, TimeZoneInfo.Utc);
var manager = new RecurringJobManager();
manager.AddOrUpdate("some-id", Job.FromExpression(() => Method()), Cron.Yearly());
