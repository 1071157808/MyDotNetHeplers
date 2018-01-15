//使得页面具有缓存功能，缓存10秒。Cache的属性也可在web.config中设置
[OutputCache(Duration = 10, VaryByParam = "none")]
public ActionResult TestCache()
{
    ViewBag.Time = DateTime.Now.ToString(); return View();
}



//people不是在Models中定义的,是随意在任何地方定义的类，所以使用自定义绑定
public ActionResult Create([Bind(Include = "Id,Name")] People people)
{
}



//RouteValueDictionary可以传递更多的信息
return RedirectToAction( "Index", new RouteValueDictionary( new { controller = "Index", action = "Home" } ) );
//如果是前端回来的model，不管是参数中的哪个位置，Controller都能找到
public ActionResult Person(int id, Person p1) { }
//RedirectToAction
//RedirectToActions的传值方式只能使用GET方法
//这种方式是不安全的，所以要么讲字符串加密后传输后再解密，要么变个法，使用POST方式来传输
//前端没有返回List<model>的问题
//在view中没有编辑，所以razor认为是没有改变的，故不需要返回listmodel
//所以需要使用可以更改的listmodel来更改页面才行
public ActionResult Transfer(List<model> models) { }


