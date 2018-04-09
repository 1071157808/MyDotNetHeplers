
# Sharepoint出现runtime error解决方法
>主要是webconfig的配置问题
C:\Program Files\Common Files\microsoft shared\Web Server Extensions\12\TEMPLATE\LAYOUTS中找到web.config
C:\Program Files\Common Files\microsoft shared\Web Server Extensions\15\TEMPLATE\LAYOUTS

    如果是sp13版本的，就是上面的12改成15
打开后有一个web.config文件，把<customErrors mode="On" />改成<customErrors mode="Off" />
就好了，可以看见详细的错误了
