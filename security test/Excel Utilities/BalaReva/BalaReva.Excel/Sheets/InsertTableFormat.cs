namespace BalaReva.Excel.Sheets
{
    using Design;
    using Enums;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Activities;
    using System.ComponentModel;
    using ExcelObjx = Microsoft.Office.Interop.Excel;

    [DisplayName("Insert Table Format")]
    [Designer(typeof(ExcelSelection))]
    public class InsertTableFormat : BaseExcelNew
    {
        [Category("Input"), RequiredArgument]
        [Description("Cell Range")]
        [DisplayName("Cell Range")]
        public InArgument<string> CellRange { get; set; }

        [Category("Input"), RequiredArgument]
        [Description("Table Format Style")]
        [DisplayName("Table Format Style")]
        public TableFormatEnum TableFormatStyle { get; set; } = TableFormatEnum.TableStyleMedium17;

        private string vCellRange { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                base.LoadVariables(context);

                vCellRange = CellRange.Get(context);

                this.DoFormatTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DoFormatTable()
        {
            try
            {
                base.InitWorkSheet();

                if (base.xlWorkSheet != null)
                {
                    base.xlWorkSheet.AutoFilterMode = false;
                    base.xlWorkSheet.EnableAutoFilter = false;

                    ExcelObjx.Range tRange = base.GetSheetRange(vCellRange);

                    ExcelObjx.ListObject listObject = base.xlWorkSheet.ListObjects.Add(
                                    XlListObjectSourceType.xlSrcRange, tRange, Type.Missing, XlYesNoGuess.xlYes, Type.Missing);

                    string strTableStyle = TableFormatStyle.ToString();
                    listObject.TableStyle = strTableStyle; // ;

                    base.SaveWorkBook(true);
                }
            }
            catch (Exception ex)
            {
                base.ClearObject();
                throw ex;
            }
        }
    }
}

