//根据数据类型设置不同类型的cell
public static void SetCellValue(ICell cell, object obj)
{
    if (obj.GetType() == typeof(int))
    {
        cell.SetCellValue((int)obj);
    }
    else if (obj.GetType() == typeof(double))
    {
        cell.SetCellValue((double)obj);
    }
    else if (obj.GetType() == typeof(IRichTextString))
    {
        cell.SetCellValue((IRichTextString)obj);
    }
    else if (obj.GetType() == typeof(string))
    {
        cell.SetCellValue(obj.ToString());
    }
    else if (obj.GetType() == typeof(DateTime))
    {
        cell.SetCellValue((DateTime)obj);
    }
    else if (obj.GetType() == typeof(bool))
    {
        cell.SetCellValue((bool)obj);
    }
    else
    {
        cell.SetCellValue(obj.ToString());
    }
}
