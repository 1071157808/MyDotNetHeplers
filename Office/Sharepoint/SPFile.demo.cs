SPFile的使用

SPFile对应于SharePoint对象模型中的文件，它的使用方法与SPFolder类大致相似。在获取SPFile对象的时候，仍是通过SPFileCollection来进行，形式也与获取SPFolder相同。在SPWeb中，也同样提供了SPWeb.GetFile方法来获取一个文件。

· GetFile(string url)：参数为该文件所在的url。

此外，对于文档库列表中的列表条目来说，也可以通过SPListItem.File来得到该文件的对象（关于文档库，稍候会进一步加以说明）。

在删除文件的时候，同样使用SPFile.Delete方法。

· Delete(string url)：参数为待删除文件的url。

添加一个文件与添加文件夹稍有不同，需要指定文件的内容，并且有如下三种不同的形式。

· Add(string url, byte[] content)：第一个参数指定待添加文件的url，第二个参数中以字节流的方式指定文件的内容。在指定文件url的时候，既可以使用完整的url（需要保证该目录存在），也可以只使用文件名（即添加到当前文件夹中）。使用该方法添加文件的时候，如果该url已经存在一个文件，则该函数会引发一个异常；

· Add(string url, byte[] content, bool overwrite)：与上一种形式不同，这种形式通过第三个参数来指定当文件已存在时，是否进行覆盖。当overwrite为true时，会对重名的文件进行覆盖；否则，如果出现重名的情况，仍然会引发一个异常；

· Add(string url, byte[] content, SPUser createdBy, SPUser lastModifiedBy, DateTime timeCreated, DateTime timeLastModified)：添加文件的时候，根据后4个参数，指定文件的创建者、修改者、创建时间、修改时间。但是在使用这种形式的时候需要注意，该程序的执行者必须为网站的管理员，而且该形式只有在WSS网站上有效（在SPS网站上，该方法会产生一个“Access Denied”错误）。

以上三种方法在创建成功之后均会直接返回一个SPFile类型的对象。

SPFile类中一些属性及其含义如下，这些属性一律为只读的。

· Author：文件的创建者，是一个SPUser类的对象（关于该类，会在下一节中进行说明）；

· CheckedOutBy：文档库的文件允许进行签入和签出的操作，该属性为签出的用户；

· CheckedOutDate：文件签出的时间；

· CheckedInComment：文件签入时的评论内容；

· CheckOutExpires：文件签出的过期时间；

· CheckOutStatus：文件签出的状态，

· Exists：该文件是否存在；

· IconUrl：SharePoint为每种常用类型的文件都提供了图标，该属性中保存了该图标的图像文件的文件名（并非完整的url），这些图片一般保存在“_layouts/images/”目录下；

· InDocumentLibrary：表示该文件是否在文档库中；

· Item：如果该文件在文档库中，那么该属性（SPListItem类）获取该文件在该文档库列表中的列表条目对象；

· Length：文件的大小（以字节为单位）；

· ModifiedBy：该文件的最后修改者；

· Name：该文件的文件名；

· ParentFolder：该文件所在的目录对象；

· Properties：一个Hashtable型的对象，包括该文件的一些常用属性（例如创建者、创建时间、修改者、修改时间、文件大小、文件的版本等信息）；

· ServerRelativeUrl：该文件相对于服务器根地址的url；

· TimeCreated：文件创建的时间；

· TimeLastModified：文件最后修改的时间；

· Url：该文件相对于其所在网站的地址；

· Versions：SPFileVersionCollection类的对象，SharePoint的文档库可以支持文档的版本管理和控制，该属性中保存了该文件自创建以来的各个版本，同时保存了各版本的信息。（由于篇幅所限，不再一一列举SPFileVersion类的属性，有兴趣的读者请参考SDK。）

SPFile类中也同样提供了一些方法。

· CheckIn()：将文件签入文档库；

· CheckOut()：将文件从文档库中签出；

· CopyTo(string newUrl)：将文件复制到一个新的url地址中；

· CopyTo(string newUrl, bool overwrite)：将文件复制到新的url地址中，并指定是否覆盖同名文件；

· MoveTo(string newUrl)：将文件移动到一个新的地址中；

· MoveTo(string newUrl, bool overwrite)：将文件移动到一个新的地址中，并指定是否覆盖同名文件；

· OpenBinary()：以byte[]的形式返回该文件的内容；

· SaveBinary(byte[] content)：以参数为内容，保存该文件

该示例中演示了从本地上传文件到文档库的过程：
- // 首先获取到SPWeb对象web
- SPFolder folder = web.GetFolder("Shared Documents");
- if(folder.Exists)
- {
- FileStream fs = new FileStream(@"C:\Demo.txt", FileMode.Open);
- byte[] content = new byte[fs.Length];
- fs.Read(content, 0, (int)fs.Length);
- folder.Files.Add("Demo.txt", content);
- fs.Close();
- }
- else
- Console.WriteLine("Folder Not Exist!");
复制代码
该程序中的FileStream类和FileMode枚举是在System.IO命名空间中。

一个简单的函数，通过递归的方法遍历某文件夹下的层级结构：

	1. void LookupFolders(SPFolder parentFolder, int level)
	2. {
	3. for(int i=0; i<level; i++)
	4. Console.Write('\t');
	5. Console.WriteLine(parentFolder.Name);
	6. 

	7. foreach(SPFolder subFolder in parentFolder.SubFolders)
	8. {
	9. if(subFolder.Exists)
	10. LookupFolders(subFolder, level+1);
	11. }
	12. }

