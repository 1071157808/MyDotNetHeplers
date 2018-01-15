enum sex : byte
{
    male = 0;
    female = 1;
}
enum sexy : int
{
    male = 0;
    female = 1;
}
sex A = sex.male;  //A在栈中占用一个字节的位置
sexy B = sexy.male //B在栈中占用四个字节的位置 因为int是4字节整数
枚举类型默认时：public enum Icon_Type : int
byte 是 0～255之间的整数，int 是-2147483648～2147483647
