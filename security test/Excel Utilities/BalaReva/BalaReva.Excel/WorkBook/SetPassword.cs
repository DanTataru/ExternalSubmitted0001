namespace BalaReva.Excel.WorkBook
{
    using Design;
    using System;
    using System.Activities;
    using System.ComponentModel;

    [DisplayName("Set Password")]
    [Designer(typeof(ExcelSelection))]
    public class SetPassword : BaseExcelNew
    {
        public SetPassword()
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

        [Category("Input")]
        [Description("New Password")]
        [DisplayName("New Password")]
        public InArgument<string> NewPassword { get; set; }

        private string vNewPass { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                base.LoadWorkBookVariables(context);

                vNewPass = NewPassword.Get(context);

                this.Do_SetPassword();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Do_SetPassword()
        {
            try
            {
                this.InitWorkBook();

                if (base.xlWorkBook != null)
                {

                    
                    base.xlWorkBook.Password = vNewPass;

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
