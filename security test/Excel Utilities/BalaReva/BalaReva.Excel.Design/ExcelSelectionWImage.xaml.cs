namespace BalaReva.Excel.Design
{
    using System.Activities;
    using System.Activities.Presentation;
    using System.Activities.Presentation.Model;
    using System.Windows;
    using System.Windows.Forms;

    // Interaction logic for ExcelSelectionWImage.xaml
    public partial class ExcelSelectionWImage: ActivityDesigner
    {
        public ExcelSelectionWImage()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog();
            _openFileDialog.Title = "Open XLSX File";
            _openFileDialog.Filter = "Excel Files|*.xl*;*.xlsx;*.xlsm";

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelProperty property = this.ModelItem.Properties["FilePath"];
                //property
                property.SetValue(new InArgument<string>(_openFileDialog.FileName));
            }
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            string strfilter = string.Empty;
            OpenFileDialog _openFileDialog = new OpenFileDialog();
            _openFileDialog.Title = "Open Image File";

            strfilter = "All Pictures(*.emf;*.jpg;*.jpeg;*.jfif;*.png;*.bmp;*.dib;*.rle;*.bmz;*.gif;*.gfa;*.emz;*.wmz;*.pcz;*.tif;*.cgm;*.eps;*.pct;*.pict;*.wpg;)";
            strfilter = "|*.emf;*.jpg;*.jpeg;*.jfif;*.png;*.bmp;*.dib;*.rle;*.bmz;*.gif;*.gfa;*.emz;*.wmz;*.pcz;*.tif;*.cgm;*.eps;*.pct;*.pict;*.wpg";

            _openFileDialog.Filter = strfilter;

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelProperty property = this.ModelItem.Properties["ImagePath"];
                //property
                property.SetValue(new InArgument<string>(_openFileDialog.FileName));
            }
        }
    }
}
