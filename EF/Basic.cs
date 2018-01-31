FK_Equipment_EquipmentClass 这个是sql中的命名规范， 外键名称在前面， 主键名称在后面

EF结合AutoMapper做模型映射的时候， 如果要从模型排除类型， 请使用 NotMapped
public class BaseModel {
    [NotMapped]
    public virtual int TempId { get; set; }
}

不要在使用migration的时候，轻易的直接操作数据库，如果migration不好用了，再去操作数据库

EF会缓存数据库连接字符串，就是下面的这个Book2Context，
如果windows系统已经连接了一个Book2Context，那么再启用一个程序还是会使用这个数据库链接


POCO是指Plain（Plain 绝对的、清楚的 ）Old Class Object，也就是最基本的CLR Class，
在原先的EF中，实体类通常是从一个基类继承下来的，而且带有大量的属性描述。
而POCO则是指最原始的Class，换句话说这个实体的Class仅仅需要从Object继承即可，
不需要从某一个特定的基类继承。主要是配合Code First使用。
Cost Frist则是指我们先定义POCO这样的实体class，然后生成数据库。
实际上现在也可以使用Entity Framework Power tools将已经存在的数据库反向生成POCO的class(不通过edmx文件)。