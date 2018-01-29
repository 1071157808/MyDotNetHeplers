
<system.web>
//最小代价自定义HTTP错误页面
<customErrors mode="On" defaultRedirect="GeneralError.aspx">
   <error statusCode="404" redirect="GeneralError.aspx"/>
   <error statusCode="403" redirect="GeneralError.aspx"/>
   <error statusCode="500" redirect="GeneralError.aspx"/>
</customErrors>
</system.web>
