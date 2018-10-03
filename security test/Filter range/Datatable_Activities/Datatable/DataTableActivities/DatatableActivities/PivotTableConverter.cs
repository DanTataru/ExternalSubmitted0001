using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Presentation.Model;
using System.Data;
using System.Text;
using System.Windows.Data;

namespace DatatableActivities.Converters
{
    public class PivotTableConverter : IValueConverter
    {
        private const char RowSeprator = ';';
        private const char ColumnSeprator = ',';

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            var modelItem = value as ModelItem;
            var columns = parameter != null
                ? parameter.ToString().Split(ColumnSeprator)
                : new[] {"HeaderAreas", "Function"};

            var resultTable = new System.Data.DataTable();

            foreach (var col in columns)
                resultTable.Columns.Add(col.Trim(), typeof(string));

            if (modelItem != null)
            {
                var inArgument = modelItem.GetCurrentValue() as InArgument<string>;
                if (inArgument != null && inArgument.Expression as Literal<string> != null)
                {
                    var rows = (inArgument.Expression as Literal<string>).Value.Split(RowSeprator);
                    foreach (var row in rows)
                    {
                        var fields = row.Replace("\"",string.Empty).Split(ColumnSeprator);
                        var dataRow = resultTable.NewRow();
                        for (var n = 0; n < fields.Length; n++)
                            dataRow[n] = fields[n].Trim();

                        resultTable.Rows.Add(dataRow);
                    }
                }
            }

            return resultTable;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var dest = new StringBuilder();
                System.Data.DataTable source = null;

                if (value is System.Data.DataTable)
                {
                    source = value as System.Data.DataTable;
                }
                else if (value is DataView)
                {
                    source = (value as DataView).ToTable();
                }
                else
                {
                    return null;
                }

                foreach (DataRow row in source.Rows)
                {
                    if (row != source.Rows[0])
                    {
                        dest.Append(RowSeprator);
                    }

                    dest.Append(string.Join(ColumnSeprator.ToString(), row.ItemArray));
                }

                return new InArgument<string>(new Literal<string>(dest.ToString()));
            }

            return null;
        }

        //public static Dictionary<string, string> ToDictionary(string source)
        //{
        //    var output = new Dictionary<string, string>();

        //    if (!string.IsNullOrEmpty(source))
        //    {
        //        string[] rows = source.Split(RowSeprator);

        //        foreach (string row in rows)
        //        {
        //            string[] fields = row.Split(ColumnSeprator);

        //            output[fields[0].Trim()] = fields[1].Trim();
        //        }
        //    }

        //    return output;
        //}

        public static string[] ToArray(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return new[] { string.Empty };
            }
            return source.Split(RowSeprator);
        }
    }
}
