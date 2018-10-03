using System.Activities.Presentation.View;
using System.Windows;
using System.Windows.Controls;

namespace DatatableActivities.Designers
{
    // Interaction logic for FilterDesign.xaml
    public partial class FilterDesigner
    {
        public FilterDesigner()
        {
            InitializeComponent();

            foreach (var childern in pnlBoxes.Children)
                (childern as StackPanel).Visibility = Visibility.Collapsed;
        }
        private int _currentCount = 0;
        private const int MaxInputs = 20;
        private void RemoveDuplicatesDesigner_OnLoaded(object sender, RoutedEventArgs e)
        {
            _currentCount = 0;

            foreach (var childern in pnlBoxes.Children)
            {
                var showPanel = PropertiesContainValue("HeaderExpression" + _currentCount,
                    "ValueExpression" + _currentCount, "FilterOperator" + _currentCount);
                var childPanel = childern as StackPanel;
                if (childPanel != null)
                {
                    if (showPanel)
                    {
                        childPanel.Visibility = Visibility.Visible;
                        _currentCount++;
                    }
                    else
                    {
                        childPanel.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private bool PropertiesContainValue(string prop1, string prop2, string prop3)
        {
            return ModelItem.Properties[prop1].ComputedValue != null &&
                   ModelItem.Properties[prop2].ComputedValue != null &&
                   ModelItem.Properties[prop3].ComputedValue != (object)0;
        }

        private void RemoveCick(object sender, RoutedEventArgs e)
        {
            if (_currentCount > 0)
            {
                _currentCount -= 1;
                var childStackPanel = (pnlBoxes.Children[_currentCount] as StackPanel);
                if (childStackPanel != null)
                {
                    childStackPanel.Visibility = Visibility.Collapsed;

                    var textBox1 = childStackPanel.Children[0] as ExpressionTextBox;
                    textBox1.Expression = null;

                    var combo = childStackPanel.Children[1] as ComboBox;
                    combo.SelectedValue = 0;

                    var textBox2 = childStackPanel.Children[2] as ExpressionTextBox;
                    textBox2.Expression = null;
                }
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (_currentCount < MaxInputs)
            {
                var childStackPanel = (pnlBoxes.Children[_currentCount] as StackPanel);
                childStackPanel.Visibility = Visibility.Visible;
                _currentCount++;
            }
        }
    }
}
