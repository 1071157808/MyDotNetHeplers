//定义表单字段的提示名称
[DisplayName]
//表示这个属性是必须提供内容的字段
[Required]
[Required(ErrorMessage=”Your {0} is required.”)]
//字符串长度 – 定义字符串类型的属性的最大长度
[StringLength]
[StringLength(160, ErrorMessage=”{0} is too long.”)]
//范围 – 为数字类型的属性提供最大值和最小值
[Range]
//正则表达式 – 指定动态数据中的数据字段值必须与指定的正则表达式匹配
[RegularExpression]
//验证邮件的正则表达式
[RegularExpression(@”[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}”,
ErrorMessage=”Email doesn’t look like a valid email address.”)]
//验证密码是否重复
[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
[DataType(DataType.Password)]
[Display(Name = "Password")]
public string Password { get; set; }
[DataType(DataType.Password)]
[Display(Name = "Confirm password")]
[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
public string ConfirmPassword { get; set; }
