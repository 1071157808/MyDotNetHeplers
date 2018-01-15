//MVC使用Ajax.BeginForm上传图片时HttpPostedFileBase file为null，Request.Files获取不到文件
//问题分析是页面中存在jquery.unobtrusive-ajax.js文件，注释后能够获Html.ActionLink方法Html.ActionLink("linkText","actionName")
Html.ActionLink("linkText","actionName","controlName")
Html.ActionLik("linkText","actionName",routeValues)    // routeValue可以向action传递参数，如Html.ActionLink("detail","Detail",new { id=1})，会生成 <a href="Products/Detail/1">detail</a>
Html.ActionLink("linkText","actionName",routeValues,htmlAttributes) // htmlAttribute可以设置<a>标签的属性，如下面的例子
Html.ActionLink("detail","Detail",new{id=1},new{ target="_blank",@class="className"})，<a href = "Products/Detail/1" target="_blank">detail</a>,
//Ajax.ActionLink
@Ajax.ActionLink(
    "测试ajax",
    "ajax",
    "Home",
    newAjaxOptions()
{
    Confirm = "您确定要跳转吗？",
        UpdateTargetId = "testajax",
        HttpMethod = "GET",
        InsertionMode = InsertionMode.Replace,
        Confirm = "您确定要跳转吗？",   //获取或设置提交恳求之前，显示在确认窗口中的消息。
        HttpMethod = "GET",  // 获取或设置 HTTP 恳求办法（“Get”或“Post”）。
        InsertionMode = InsertionMode.Replace,  // 获取或设置指定如何将响应插入目标 DOM 元素的模式，InsertAfter，InsertBefore , Replace
        LoadingElementId = "",  // 获取或设置加载 Ajax 函数时要显示的 HTML 元素的 id 特点。
        OnBegin = "",   //获取或设置更新页面之前，正好调用的 JavaScript 函数的名称。
        OnComplete = "",     //获取或设置实例化响应数据之后但更新页面之前，要调用的 JavaScript 函数。
        OnFailure = "",  // 获取或设置页面更新失败时，要调用的 JavaScript 函数。
        OnSuccess = "",  //获取或设置成功更新页面之后，要调用的 JavaScript 函数。
        UpdateTargetId = "",  // 获取或设置要应用办事器响应来更新的 DOM 元素的 ID。
        Url = "",  //获取或设置要向其发送恳求的 URL。
        }
    );
