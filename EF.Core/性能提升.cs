
//性能提升
ef 自动更新保存
DbContext.SaveChanges
DbContext.Entry
ChangeTracker.Entries
当在循环中一次更新大量的数据的时候， 关掉自动保存可以快速提升性能
_context.ChangeTracker.AutoDetectChangesEnabled = false;