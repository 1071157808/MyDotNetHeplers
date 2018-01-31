解决方法
SaveChanges前先关闭验证实体有效性（ ValidateOnSaveEnabled） 这个开关

db.Configuration.ValidateOnSaveEnabled = false;
int count = db.SaveChanges ();
db.Configuration.ValidateOnSaveEnabled = true;

问题原因可能是：
1. 非空列未插入值错误
2. 多个表间外键列长度不一样
3. ef上下文对象db为空
4. ef上下文设置属性为 db.Configuration.ValidateOnSaveEnabled = false;
5. 内容长度超过列最大长度
6. 解决方案里后来新增了类库但未更新
7. 添加引用using System.Data.Validation;

