ValidateOnSaveEnabled = true， 那么SaveChanges () 前不会调用DetectChanges ()，
ValidateOnSaveEnabled = false， 那么只有在AutoDetectChangesEnabled = true的情况下， EF在SaveChanges () 前才会调用DetectChanges ()
AutoDetectChangesEnabled： 自动跟踪对象的属性变化， 默认为true。

1. 如果关闭EF自动跟踪，
在SaveChanges () 前尚未手动调用DetectChanges ()， 那么保存不会生效。（ 前提： 对象状态为Unchanged）
因为如果AutoDetectChangesEnabled = false，
那么EF就不会自动跟踪对象属性的变化， 从而导致对象的状态也不会变为Modified，
并且因为AutoDetectChangesEnabled = false，
那么EF在SaveChanges () 实际保存到数据库之前不会调用DetectChanges ()，
所以最终修改不会生效。
2. 如果AutoDetectChangesEnabled = true，
那么就算不调用DetectChanges ()， EF在SaveChanges () 时也能生效。

DetectChanges ()： 同步对象与其属性的状态。
1. 如果对象A的状态为Unchanged， A的属性A1状态为Modified， 那么调用DetectChanges () 后， A状态变为Modified
2. 如果AutoDetectChangesEnabled = true， 那么对象与其属性的状态会立即同步
AcceptAllChanges ()： 上下文能跟踪状态为Added、 Modified、 Deleted的所有对象，
修改他们的状态为Unchanged。 在SaveChanges () 失败时不 会调用该方法。
AcceptAllChangesAfterSave： 标志SaveChanges () 后调用AcceptAllChanges
1.EF6.0 在SaveChanges () 成功后始终会调用AcceptAllChanges ()， 
把Added、 Modified、 Deleted的对象状态修改为Unchanged
DetectChangesBeforeSave： 标志在SaveChanges () 前， 需要调用DetectChanges () 同步所有状态
1. 如果AutoDetectChangesEnabled = false， 那么在SaveChanges () 前， 不会调用DetectChanges () 同步所有状态
SaveChanges ()：
1. 只有当AutoDetectChangesEnabled = true， ValidateOnSaveEnabled = false的情况下， 在保存之前才会调用DetectChanges ()
2. 当保存成功后， 始终都会调用AcceptAllChanges ()