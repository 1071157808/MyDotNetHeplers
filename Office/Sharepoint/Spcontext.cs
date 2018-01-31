//什么是SPContext?
//用一句话概括，SPContext对象可用于从当前上下文中获取一个site或web的引用，可以看作是一个对SharePoint的HTTP请求的上下文。
SPList currentList = SPContext.Current.List;
SPWeb currentSite = SPContext.Current.Web;
SPSite currentSiteCollection = SPContext.Current.Site;
SPWebApplication currentWebApplication = SPContext.Current.Site.WebApplication;
SPListItem item = (SPListItem) SPContext.Current.Item;
SPUser user = SPContext.Current.Web.CurrentUser;

//什么是“Properties”？
//properties对象包含了某个特定事件的信息，可以用来获取到该事件相关的SPSite，SPWeb，SPList或SPListItem的引用。
//例如：
SPListItem item = properties.ListItem;

//然而，当使用properties参数或SPContext时一定要非常小心。
//你不能用properties来创建你的对象，否则代码将出错。
//正确的用法是通过properties或SPContext来定位条目，
//然后用条目ID号来创建对象的引用。否则你的代码总是会出现这样那样的问题。
//你需要在进入权限提升代码块(RunWithElevatedPriveleges)或模拟用户前获取所有会用到的Guid标识，
//然后在安全上下文中再创建出所有需要的对象，如下所示：

Guid SiteId = SPContext.Current.Site.ID;
Guid WebId = SPContext.Current.Web.ID;
Guid ListId = properties.ListId;
Guid UniqueId = properties.ListItem.UniqueId;
SPSecurity.RunWithElevatedPrivileges (delegate () {
    using (SPSite site = new SPSite (SiteId)) {
        using (SPWeb web = site.AllWebs[WebId]) {
            SPList list = web.Lists[ListId];
            SPListItem listItem = list.Items[UniqueId];
            // Code..
        }
    }
});

//或者通过SPUserToken来模拟系统帐户（推荐这种写法）
Guid SiteId = SPContext.Current.Site.ID;
Guid WebId = SPContext.Current.Web.ID;
Guid ListId = properties.ListId;
Guid UniqueId = properties.ListItem.UniqueId;
SPUserToken systemAccountToken = SPContext.Current.Site.SystemAccount.UserToken;
using (SPSite mySite = new SPSite (SiteId, systemAccountToken)) {
    using (SPWeb myWeb = mySite.OpenWeb (WebId)) {
        SPList list = web.Lists[ListId];
        SPListItem listItem = list.Items[UniqueId];
        // Code..
    }
}




