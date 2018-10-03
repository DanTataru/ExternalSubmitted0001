using System;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatatableActivities.Converters;

namespace DatatableActivities
{
    // Interaction logic for PivotTableDesigner.xaml
    public partial class PivotTableDesigner
    {
        private const int MaxInputs = 46;
        private int _currentCount = 0;

        public PivotTableDesigner()
        {
            InitializeComponent();

            CustomGridControl.BeginningEdit += OnCustomGridBeginEdit;
            CustomGridControl.RowEditEnding += CustomGridControl_OnRowEditEnding;
            CustomGridControl.PreviewKeyUp += PreviewKeyHandler;

            foreach (var childern in pnlBoxes.Children)
                (childern as ExpressionTextBox).Visibility = Visibility.Collapsed;
        }

        private void PreviewKeyHandler(object sender, KeyEventArgs e)
        {
            var grid = (DataGrid)sender;
            if (Key.Delete == e.Key && grid != null)
            {
                if (this.CustomGridControl.ItemsSource is DataView)
                {
                    //(this.CustomGridControl.ItemsSource as DataView).Table.RowDeleted +=
                    //    new DataRowChangeEventHandler(OnCustomGridChanged);

                    OnCustomGridChanged(null, null);
                }
            }
        }

        private void OnCustomGridChanged(object eventSender, DataRowChangeEventArgs eventArgs)
        {
            var view = CustomGridControl.ItemsSource as DataView;
            ModelItem.Properties["InputFilters"].ComputedValue = new PivotTableConverter().ConvertBack(view.Table, typeof(string), null, null);
        }

        private void OnCustomGridBeginEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            // Add handler to detect when custom grid changes
            if (this.CustomGridControl.ItemsSource is DataView)
            {
                (this.CustomGridControl.ItemsSource as DataView).Table.RowChanged += new DataRowChangeEventHandler(OnCustomGridChanged);
            }
        }

        private void CustomGridControl_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (this.CustomGridControl.ItemsSource is DataView)
            {
                (this.CustomGridControl.ItemsSource as DataView).Table.RowDeleted +=
                    new DataRowChangeEventHandler(OnCustomGridChanged);
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (_currentCount < MaxInputs)
            {
                if (_currentCount < MaxInputs)
                    if ((this.CustomGridControl.ItemsSource is DataView))
                    {
                        var dt = (this.CustomGridControl.ItemsSource as DataView).Table;
                        var dataRow = dt.NewRow();
                        dataRow["HeaderAreas"] = 1;
                        dataRow["Function"] = 1;
                        dt.Rows.Add(dataRow);
                        OnCustomGridChanged(null, null);
                    }
                pnlBoxes.Children[_currentCount++].Visibility = Visibility.Visible;
            }
        }

        private void RemoveCick(object sender, RoutedEventArgs e)
        {
            if ((this.CustomGridControl.ItemsSource is DataView))
            {
                if ((this.CustomGridControl.ItemsSource as DataView).Table.Rows.Count > 0)
                {
                    var dt = (this.CustomGridControl.ItemsSource as DataView).Table;
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                }
            }

            if (_currentCount > 0)
            {
                _currentCount -= 1;
                pnlBoxes.Children[_currentCount].Visibility = Visibility.Collapsed;
                var textBox = pnlBoxes.Children[_currentCount] as ExpressionTextBox;
                if (textBox != null)
                    textBox.Expression = null;
            }
        }

        private void ExtractPagesDesigner_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (this.CustomGridControl.ItemsSource is DataView)
            {
                //_currebtVarCount = (this.CustomGridControl.ItemsSource as DataView).Table.Rows.Count + 1;
            }

            foreach (var childern in pnlBoxes.Children)
            {
                var expressionTextBox = childern as ExpressionTextBox;
                if (expressionTextBox != null)
                {
                    if (expressionTextBox.Expression == null)
                        expressionTextBox.Visibility = Visibility.Collapsed;
                    else
                    {
                        expressionTextBox.Visibility = Visibility.Visible;
                        _currentCount++;
                    }
                }
            }
        }
    }
}
