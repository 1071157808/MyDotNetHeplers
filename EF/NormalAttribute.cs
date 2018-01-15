[DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]   
// ApplyFormatInEditMode设置指定的值显示在文本框中进行编辑时
// 应该也适用已指定的格式。（您可能不希望一些领域 — — 例如，对于货币值，您可能不希望货币符号在文本框中编辑。）
public DateTime EnrollmentDate { get; set; }
