public void WriteToExcel (string filePath) {
    //创建工作薄 
    IWorkbook wb;
    string extension = System.IO.Path.GetExtension (filePath);
    //根据指定的文件格式创建对应的类
    if (extension.Equals (".xls")) {
        wb = new HSSFWorkbook ();
    } else {
        wb = new XSSFWorkbook ();
    }
    ICellStyle style1 = wb.CreateCellStyle (); //样式
    style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //文字水平对齐方式
    style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //文字垂直对齐方式
    //设置边框
    style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
    style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
    style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
    style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
    style1.WrapText = true; //自动换行
    ICellStyle style2 = wb.CreateCellStyle (); //样式
    IFont font1 = wb.CreateFont (); //字体
    font1.FontName = "楷体";
    font1.Color = HSSFColor.Red.Index; //字体颜色
    font1.Boldweight = (short) FontBoldWeight.Normal; //字体加粗样式
    style2.SetFont (font1); //样式里的字体设置具体的字体样式
    //设置背景色
    style2.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
    style2.FillPattern = FillPattern.SolidForeground;
    style2.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
    style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //文字水平对齐方式
    style2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //文字垂直对齐方式
    ICellStyle dateStyle = wb.CreateCellStyle (); //样式
    dateStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left; //文字水平对齐方式
    dateStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center; //文字垂直对齐方式
    //设置数据显示格式
    IDataFormat dataFormatCustom = wb.CreateDataFormat ();
    dateStyle.DataFormat = dataFormatCustom.GetFormat ("yyyy-MM-dd HH:mm:ss");
    //创建一个表单
    ISheet sheet = wb.CreateSheet ("Sheet0");
    //设置列宽
    int[] columnWidth = { 10, 10, 20, 10 };
    for (int i = 0; i < columnWidth.Length; i++) {
        //设置列宽度，256*字符数，因为单位是1/256个字符
        sheet.SetColumnWidth (i, 256 * columnWidth[i]);
    }
    //测试数据
    int rowCount = 3, columnCount = 4;
    object[, ] data = { { "列0", "列1", "列2", "列3" },
        { "", 400, 5.2, 6.01 },
        { "", true, "2014-07-02", DateTime.Now }
        //日期可以直接传字符串，NPOI会自动识别
        //如果是DateTime类型，则要设置CellStyle.DataFormat，否则会显示为数字
    };
    IRow row;
    ICell cell;
    for (int i = 0; i < rowCount; i++) {
        row = sheet.CreateRow (i); //创建第i行
        for (int j = 0; j < columnCount; j++) {
            cell = row.CreateCell (j); //创建第j列
            cell.CellStyle = j % 2 == 0 ? style1 : style2;
            //根据数据类型设置不同类型的cell
            object obj = data[i, j];
            SetCellValue (cell, data[i, j]);
            //如果是日期，则设置日期显示的格式
            if (obj.GetType () == typeof (DateTime)) {
                cell.CellStyle = dateStyle;
            }
            //如果要根据内容自动调整列宽，需要先setCellValue再调用
            //sheet.AutoSizeColumn(j);
        }
    }
    //合并单元格，如果要合并的单元格中都有数据，只会保留左上角的
    //CellRangeAddress(0, 2, 0, 0)，合并0-2行，0-0列的单元格
    CellRangeAddress region = new CellRangeAddress (0, 2, 0, 0);
    sheet.AddMergedRegion (region);
    try {
        FileStream fs = File.OpenWrite (filePath);
        wb.Write (fs); //向打开的这个Excel文件中写入表单并保存。 
        fs.Close ();
    } catch (Exception e) {
        Debug.WriteLine (e.Message);
    }
}