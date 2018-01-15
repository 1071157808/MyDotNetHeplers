using System;
using System.Collections;

public class EnumOperate {
    //为Enum写一个扩展方法
    //Enum.Description Enum描述操作
    public static string GetDescription (this Enum value) {
        Type type = value.GetType ();
        string name = Enum.GetName (type, value);
        if (name != null) {
            FieldInfo field = type.GetField (name);
            if (field != null) {
                DescriptionAttribute attr =
                    Attribute.GetCustomAttribute (field,
                        typeof (DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null) {
                    return attr.Description;
                }
            }
        }
        return null;
    }
    //使用的例子如下：
    public enum MyEnum {
        [Description ("Description for Foo")]
        Foo, [Description ("Description for Bar")]
        Bar
    }
    MyEnum x = MyEnum.Foo;
    string description = x.GetDescription ();

    //DisplayName用法只能在配合MVC前台的 
    //@Html.DisplayFor(modelItem => item.FlagsEnum)的时候显示，后台使用的还是Enum定义中的值
    public enum MyEnum : byte {
        [Display (Name = "Zéro")]
        Zero,
    }


}