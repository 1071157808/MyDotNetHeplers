using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ConsoleApp14 {
    class Program {
        static void Main (string[] args) {
            var str = @"[{ 'name':'资质等级','value':'甲级'},{'name':'资质名称','value':'模板资质'},{ 'name':'颁发时间','value':''},{ 'name':'新字段','value':'4567'},{ 'name':'字段一','value':'字段1'},[{'name':'测试多选new','choice':[{'key':'new1','value':'true'},{'key':'new33','value':'true'}]},{'name':'测试多选','choice':[{'key':'第二','value':'true'}]}]]";
            var originJsonObject = JsonConvert.DeserializeObject<JArray> (str);
            foreach (var item in originJsonObject) {
                if (item is JObject) {
                    //取得普通数据类型的名称和值
                    var itemJobject = item as JObject;
                    Console.WriteLine (itemJobject.GetValue ("name"));
                    Console.WriteLine (itemJobject.GetValue ("value"));
                }
                if (item is JArray) {
                    var itemJArray = item as JArray;
                    foreach (JObject item2 in itemJArray) {
                        //取得多选的名称
                        var ii = item2.GetValue ("name");
                        var array = item2.GetValue ("choice");
                        if (array is JArray) {
                            //取得多选的值
                            var item3 = array as JArray;
                            foreach (JObject item7 in item3) {
                                Console.WriteLine (item7.GetValue ("key"));
                                Console.WriteLine (item7.GetValue ("value"));
                            }
                        }
                    }
                }
            }
            Console.ReadKey ();
        }
    }
}



//--------------------------
foreach (JObject items in _JArray) 
{ 
    foreach (var item in items) 
    { 
        str.Append(item.Key + ":" + item.Value + ","); 
    } 
}
