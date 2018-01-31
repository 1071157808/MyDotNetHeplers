ICellStyle unlocked = wb.CreateCellStyle ();
unlocked.IsLocked = false; //设置该单元格为非锁定
cell.SetCellValue ("未被锁定");
cell.CellStyle = unlocked;
...
//保护表单，password为解锁密码
//cell.CellStyle.IsLocked = true;的单元格将为只读
sheet.ProtectSheet ("password");