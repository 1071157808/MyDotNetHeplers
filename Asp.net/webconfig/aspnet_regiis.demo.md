
创建RSA密钥容器
aspnet_regiis -pc "MyKeys" -exp

设置密钥容器访问权限
aspnet_regiis -pa "MyKeys" "NT AUTHORITY\NETWORK SERVICE"

加密（需管理员权限）
aspnet_regiis -pef "connectionStrings" "C:\Users\spike\source\repos\WebApplication8\WebApplication8" 
aspnet_regiis -pef "system.web/sessionState" "D:\WebApp" -prov "RsaProtectedConfigurationProvider"

解密（需管理员权限）
aspnet_regiis -pdf "connectionStrings" "C:\Users\spike\source\repos\WebApplication8\WebApplication8"

--加密解密都会自动的修改webconfig中的内容，这个加密命令也可以自己指定用一个加密方式
--我觉得没有必要再去看了，如果黑客能获取到一个webconfig，说明已经攻破系统了

导出
aspnet_regiis -px "MyKeys" "D:/MyKeys.xml" -pri


删除密钥容器
aspnet_regiis -pz "MyKeys"
