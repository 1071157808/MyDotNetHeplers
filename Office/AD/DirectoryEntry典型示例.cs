//DirectorySearcher
DirectorySearcher search = new DirectorySearcher (entry);
search.Filter = "(&(objectClass=group)(cn=" + groupName + "))";
search.SearchScope = SearchScope.Subtree;
SearchResult result = search.FindOne ();
//1. SearchScope 取值說明﹕
//SearchScope.Base﹕ 只搜索对象中的属性， 至多可以得到一个对象。
//SearchScope.OneLevel﹕ 表示在基对象的子集合中继续搜索。 基对象本身是不搜索的
//SearchScope.Subtree﹕ 在子树中搜索
//2. 部分方法說明
//FindOne () 执行搜索并返回第一项
//FindAll () 执行搜索并返回项目集合
//3. DirectoryEntry类型的对象entry为搜索的根目录
//DirectorySearcher (DirectoryEntry, String, String[], SearchScope) 参
//数分别为： 搜索根目录、 搜索筛选条件、 要获取的属性和搜索范围， 初始化 DirectorySearcher类别
//
using System.DirectoryServices;
DirectoryEntry group = new DirectoryEntry ("LDAP://CN=MyGroup,DC=test,DC=com");
DirectorySearcher src = new DirectorySearcher (group "(&(objectClass=user)(objectCategory=Person))"); //& 表示同时满足多个条件
src.AttributeScopedQuery = "member"; // 仅查询组织
src.PropertiesToLoad.Add ("sn");
src.PropertiesToLoad.Add ("givenName");
src.PropertiesToLoad.Add ("telephoneNumber");
foreach (SearchResult res in src.FindAll ()) {
    Console.WriteLine ("…");
}