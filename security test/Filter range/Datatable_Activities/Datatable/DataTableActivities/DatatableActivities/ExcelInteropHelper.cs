using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace DatatableActivities.Helpers
{
    public class ExcelInteropHelper
    {
        private Application _xlApp = null;

        public Workbook CreateWorkBook(string workBookName, int numberOfSheets = 2)
        {
            Workbook xlWorkBook = null;
            try
            {
                if (_xlApp == null)
                    _xlApp = new Application();

                _xlApp.SheetsInNewWorkbook = numberOfSheets;
                xlWorkBook = _xlApp.Workbooks.Add(Type.Missing);
                xlWorkBook.SaveAs(Filename: workBookName,
                                                FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
                                                Password: "",
                                                WriteResPassword: "",
                                                ReadOnlyRecommended: false,
                                                CreateBackup: false);

                return xlWorkBook;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating the workbook");
            }
        }

        public Worksheet WriteDataToWorkSheet(string sheetName, Workbook xlWorkBook,
            System.Data.DataTable sheetData, int sheetNumber)
        {
            try
            {
                //Create sheet
                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Sheets[sheetNumber];
                if (sheetName.Length > 31)
                {
                    var tempSheetName = string.Format("{0}...", sheetName.Substring(0, 25));
                    int i = 0;
                    var sheetNames = (from Worksheet sheet in xlWorkBook.Sheets select sheet.Name).ToList();

                    while (sheetNames.Contains(tempSheetName))
                    {
                        i++;
                        tempSheetName = string.Format("{0}({1})...", sheetName.Substring(0, 25), i);
                    }
                    xlWorkSheet.Name = tempSheetName;
                }
                else
                    xlWorkSheet.Name = sheetName;

                // Write datatable data to array and pass array to excel sheet
                WriteDataToWorksheet(xlWorkSheet, sheetData);

                //Add Sheet to workBook
                xlWorkBook.Save();
                return xlWorkSheet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding data to worksheet");
            }
        }

        public Worksheet CreateWorkSheet(string sheetName, Workbook xlWorkBook,
            int sheetNumber)
        {
            try
            {
                //Create sheet
                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Sheets[sheetNumber];
                if (sheetName.Length > 31)
                {
                    var tempSheetName = string.Format("{0}...", sheetName.Substring(0, 25));
                    int i = 0;
                    var sheetNames = (from Worksheet sheet in xlWorkBook.Sheets select sheet.Name).ToList();

                    while (sheetNames.Contains(tempSheetName))
                    {
                        i++;
                        tempSheetName = string.Format("{0}({1})...", sheetName.Substring(0, 25), i);
                    }
                    xlWorkSheet.Name = tempSheetName;
                }
                else
                    xlWorkSheet.Name = sheetName;

                //Add Sheet to workBook
                xlWorkBook.Save();
                return xlWorkSheet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding data to worksheet");
            }
        }

        public bool Cleanup(Workbook workBook)
        {
            bool ret = true;
            try
            {
                workBook.Close(SaveChanges: false);
                _xlApp.Quit();
                Marshal.FinalReleaseComObject(workBook);
                Marshal.FinalReleaseComObject(_xlApp);
                _xlApp = null;
                workBook = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while cleanup");
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// This function will convert datatable in a array which will be passed to excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="sheetData"></param>
        private static void WriteDataToWorksheet(Worksheet worksheet, System.Data.DataTable sheetData)
        {
            var rows = sheetData.Rows.Count;
            var columns = sheetData.Columns.Count;
            var data = new object[rows + 1, columns];

            // Add column headers to array
            for (var column = 1; column <= columns; column++)
            {
                data[0, column - 1] = sheetData.Columns[column - 1].ColumnName;
            }
            // Add data to array
            if (rows > 0)
            {
                for (var row = 1; row <= rows; row++)
                {
                    for (var column = 1; column <= columns; column++)
                    {
                        data[row, column - 1] = sheetData.Rows[row - 1][column - 1];
                    }
                }
            }
            //set the value of the entire target range at once
            var startCell = (Range)worksheet.Cells[1, 1];
            var endCell = (Range)worksheet.Cells[rows + 1, columns];
            var writeRange = worksheet.Range[startCell, endCell];
            writeRange.Value2 = data;				//sets the cell value.
        }
    }
}
