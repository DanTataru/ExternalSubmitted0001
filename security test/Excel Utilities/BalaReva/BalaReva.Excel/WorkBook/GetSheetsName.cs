using BalaReva.Excel.Design;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaReva.Excel.WorkBook
{
    [DisplayName("Get Sheets Name")]
    [Designer(typeof(ExcelSelection))]
    public class GetSheetsName : BaseExcelNew
    {
        public GetSheetsName()
        {
            this.SheetName = new InArgument<string>("EmptySheet");
        }

        [Browsable(false)]
        public new InArgument<string> SheetName
        {
            get
            {
                return base.SheetName;
            }
            set
            {
                base.SheetName = value;
            }
        }

        [Category("Output")]
        [Description("Sheets Name")]
        [DisplayName("Sheets Name")]
        public OutArgument<string[]> SheetsName { get; set; }

        private List<string> lstResult { get; set; } = new List<string>();

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                base.LoadWorkBookVariables(context);

                this.DoGetSheetName();

                this.SheetsName.Set(context, lstResult.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DoGetSheetName()
        {
            try
            {
                this.InitWorkBook();

                if (base.xlWorkBook != null)
                {
                    // to get the sheet index
                    for (Int16 i = 1; i <= xlWorkBook.Worksheets.Count; i++)
                    {
                        lstResult.Add(xlWorkBook.Worksheets[i].Name);
                    }

                    base.SaveWorkBook(false);
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
