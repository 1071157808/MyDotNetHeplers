using Excel = Microsoft.Office.Interop.Excel;
Excel.Application xlApp = new Excel.Application ();
Excel.Workbook xlWorkbook = xlApp.Workbooks.Open (localFileName, 0, true, 5,
    "",
    "",
    true,
    Excel.XlPlatform.xlWindows,
    "\t",
    false,
    false,
    0,
    true,
    1,
    0);
Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
Excel.Range xlRange = xlWorksheet.UsedRange;
int rowCount = xlRange.Rows.Count;
int colCount = xlRange.Columns.Count;
//iterate over the rows and columns and print to the console as it appears in the file
//excel is not zero based!!
for (int i = 3; i <= rowCount; i++) {
    for (int j = 1; j <= colCount; j++) {
        CreateOrUpdateUserInput input = new CreateOrUpdateUserInput ();
        UserEditDto dto = new UserEditDto ();
        List<string> roles = new List<string> ();
        //write the value to the console
        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null) {
            if (j == 2) {
                dto.UserName = xlRange.Cells[i, j].Value2.ToString ();
            } else if (j == 3) {
                dto.Name = xlRange.Cells[i, j].Value2.ToString ();
            } else if (j == 4) {
                dto.Surname = xlRange.Cells[i, j].Value2.ToString ();
            } else if (j == 5) {
                dto.PhoneNumber = xlRange.Cells[i, j].Value2.ToString ();
            } else if (j == 6) {
                dto.CustomCode = xlRange.Cells[i, j].Value2.ToString ();
            } else if (j == 7) {
                if (xlRange.Cells[i, j].Value2.ToString () == "1" ||
                    xlRange.Cells[i, j].Value2.ToString () == "Yes" ||
                    xlRange.Cells[i, j].Value2.ToString () == "yes") {
                    roles.Add ("Dealer");
                }

            } else if (j == 8) {
                if (xlRange.Cells[i, j].Value2.ToString () == "1" ||
                    xlRange.Cells[i, j].Value2.ToString () == "Yes" ||
                    xlRange.Cells[i, j].Value2.ToString () == "yes") {
                    roles.Add ("Mpc-CV");
                }
            } else if (j == 9) {
                if (xlRange.Cells[i, j].Value2.ToString () == "1" ||
                    xlRange.Cells[i, j].Value2.ToString () == "Yes" ||
                    xlRange.Cells[i, j].Value2.ToString () == "yes") {
                    roles.Add ("Mpc-VAN");
                }
            }
        }
        dto.Password = "P@ssw0rd";
        input.User = dto;
        input.AssignedRoleNames = roles.ToArray ();
        _userAppService.CreateOrUpdateUser (input);
    }
}
//cleanup
GC.Collect ();
GC.WaitForPendingFinalizers ();
//rule of thumb for releasing com objects:
//  never use two dots, all COM objects must be referenced and released individually
//  ex: [somthing].[something].[something] is bad
//release com objects to fully kill excel process from running in the background
Marshal.ReleaseComObject (xlRange);
Marshal.ReleaseComObject (xlWorksheet);
//close and release
xlWorkbook.Close ();
Marshal.ReleaseComObject (xlWorkbook);
//quit and release
xlApp.Quit ();
Marshal.ReleaseComObject (xlApp);