//避免CRSF攻击
//微软定义了一个HTTP-onlycookie特性来检测cookie是否发生了变化
//前端的cshtml页面需要声明一下这个
@Html.AntiForgeryToken();
//后端每一个model字段上，要使用
[ValidateAntiForgeryToken]
//使用[ValidateAntiForgeryToken]属性来验证Token
