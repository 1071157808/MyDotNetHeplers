//[FromBody] 修饰的参数只能有一个

public class Student{
    public string Name{get;set;}
    public int Age{get;set;}
}
//前台发送两个参数的POST请求
前台传json键值对
//后台设置
public string Auth([FromBody]Student input){

}

//前台发送一i个参数的POST请求
需要将json的key设置为空，啥都没有
//后台设置
public string Auth([FromBody]string value){

}


