namespace BalaReva.Excel.Sheets
{
    using Design;
    using Microsoft.Office.Core;
    using System;
    using System.Activities;
    using System.ComponentModel;
    using Utilities.Objects;
    using ExcelObj = Microsoft.Office.Interop.Excel;

    [DisplayName("Insert Image")]
    [Designer(typeof(ExcelSelectionWImage))]
    public class InsertImage : BaseExcelNew
    {
        [Category("Input")]
        [Description("Image full Path")]
        [DisplayName("Image Path")]
        public InArgument<string> ImagePath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public ObjectSize Size { get; set; } = new ObjectSize();

        private string strImagePath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            base.LoadVariables(context);

            strImagePath = ImagePath.Get(context);

            this.DoProtect();
        }

        private void DoProtect()
        {
            try
            {
                base.InitWorkSheet();

                if (base.xlWorkSheet != null)
                {
                    ExcelObj.Worksheet worksheet = (ExcelObj.Worksheet)base.xlWorkSheet;

                    float vLeft = (float)Size.Left;
                    float vTop = (float)Size.Top;
                    float vWidth = (float)Size.Width;
                    float vHeight = (float)Size.Height;

                    base.xlWorkSheet.Shapes.AddPicture(strImagePath, MsoTriState.msoFalse, MsoTriState.msoTrue, vLeft, vTop, vWidth, vHeight);

                    base.SaveWorkBook(true);
                }
            }
            catch (Exception ex)
            {
                base.ClearObject();
                throw ex;
            }
        }

        private void ValidateImageFile()
        {
            if (!System.IO.File.Exists(strImagePath))
            {
                throw new Exception("Invalid Image path");
            }
        }
    }
}
