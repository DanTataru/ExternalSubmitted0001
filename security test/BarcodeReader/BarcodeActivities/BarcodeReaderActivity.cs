using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel.Composition;
using Spire.Barcode;
using System.ComponentModel;
using System.Windows.Media;
using System.Drawing;

namespace BarcodeActivities
{
    public class BarcodeReaderActivity:CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ImagePath { get; set; }


        [Category("Output")]
        public OutArgument<string> BarcodeValue { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string imageFileName = (ImagePath.Get(context)).ToString();
            var IsCheck = true;
            string strcode = BarcodeScanner.ScanOne(imageFileName, IsCheck);
            BarcodeValue.Set(context, strcode);

        }


    }
}
