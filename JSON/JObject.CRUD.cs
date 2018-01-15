

//将json转换为JObject
JObject jObj = JObject.Parse(json);
JToken colleagues = jObj["Colleagues"];
colleagues[0]["Age"] = 45;
            jObj["Colleagues"] = colleagues;//修改后，再赋给对象
            Console.WriteLine(jObj.ToString());
           
           
            JObject jObj = JObject.Parse(json);
jObj.Remove("Colleagues");//跟的是属性名称
            Console.WriteLine(jObj.ToString());
           
           
            JObject jObj = JObject.Parse(json);
jObj["Colleagues"][1].Remove();
Console.WriteLine(jObj.ToString());
           
            JObject jObj = JObject.Parse(json);
JToken name = jObj.SelectToken("Name");
Console.WriteLine(name.ToString());
           
            JObject jObj = JObject.Parse(json);
var names = jObj.SelectToken("Colleagues").Select(p => p["Name"]).ToList();
            foreach (var name in names)
            Console.WriteLine(name.ToString());
           
           
我们发现Jack的信息中少了部门信息，要求我们必须添加在Age的后面
//将json转换为JObject
JObject jObj = JObject.Parse(json);
jObj["Age"].Parent.AddAfterSelf(new JProperty("Department", "Personnel Department"));
Console.WriteLine(jObj.ToString());
现在我们又发现，Jack公司来了一个新同事Linda
//将json转换为JObject
JObject jObj = JObject.Parse(json);
JObject linda = new JObject(new JProperty("Name", "Linda"), new JProperty("Age", "23"));
jObj["Colleagues"].Last.AddAfterSelf(linda);
Console.WriteLine(jObj.ToString());    
           

