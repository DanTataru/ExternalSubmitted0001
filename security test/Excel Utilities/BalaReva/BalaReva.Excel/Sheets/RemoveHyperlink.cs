namespace BalaReva.Excel.Sheets
{
    using BalaReva.Excel.Design;
    using System;
    using System.Activities;
    using System.ComponentModel;
    using ExcelObj = Microsoft.Office.Interop.Excel;

    [DisplayName("Remove Hyperlink")]
    [Designer(typeof(ExcelSelection))]
    public class RemoveHyperlink : BaseExcelNew
    {
        [Category("Input"), RequiredArgument]
        [Description("Cell Range")]
        [DisplayName("Cell Range")]
        public InArgument<string> CellRange { get; set; }

        private string vCellRange { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                base.LoadVariables(context);

                vCellRange = CellRange.Get(context);


                this.RemoveLink();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoveLink()
        {
            try
            {
                base.InitWorkSheet();

                if (base.xlWorkSheet != null)
                {
                    base.xlWorkSheet.AutoFilterMode = false;
                    base.xlWorkSheet.EnableAutoFilter = false;

                    ExcelObj.Range tRange = base.GetSheetRange(vCellRange);

                    tRange.Hyperlinks.Delete();

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
