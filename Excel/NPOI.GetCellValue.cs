//获取cell的数据，并设置为对应的数据类型
//NPOI插件的使用NPOI 使用 HSSFWorkbook 类来处理 xls，XSSFWorkbook 类来处理 xlsx，
//它们都继承接口 IWorkbook，因此可以通过 IWorkbook 来统一处理 xls 和 xlsx 格式的文件。
//特别注意的是CellType中没有Date，而日期类型的数据类型是Numeric，其实日期的数据在Excel中也是以数字的形式存储。
//可以使用DateUtil.IsCellDateFormatted方法来判断是否是日期类型。有了GetCellValue方法，
//写数据到Excel中的时候就要有SetCellValue方法，缺的类型可以自己补。
public object GetCellValue(ICell cell)
{
    object value = null;
    try
    {
        if (cell.CellType != CellType.Blank)
        {
            switch (cell.CellType)
            {
                case CellType.Numeric:
                    // Date comes here
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        value = cell.DateCellValue;
                    }
                    else
                    {
                        // Numeric type
                        value = cell.NumericCellValue;
                    }
                    break;
                case CellType.Boolean:
                    // Boolean type
                    value = cell.BooleanCellValue;
                    break;
                case CellType.Formula:
                    value = cell.CellFormula;
                    break;
                default:
                    // String type
                    value = cell.StringCellValue;
                    break;
            }
        }
    }
    catch (Exception)
    {
        value = "";
    }
    return value;
}
