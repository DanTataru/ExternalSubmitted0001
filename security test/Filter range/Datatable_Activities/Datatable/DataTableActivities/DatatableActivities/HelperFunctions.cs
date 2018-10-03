using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Utility.Enum;

namespace DatatableActivities.Helpers
{
    public class HelperFunctions
    {
        public static void AddFields(PivotTable pivotTable, IEnumerable<string[]> fieldList,
            XlPivotFieldOrientation orientation,
            bool showSubTotal = false)
        {
            if (fieldList != null)
            {
                int i = 1;
                foreach (var field in fieldList)
                {
                    PivotField fieldQ = pivotTable.PivotFields(field[0]);
                    fieldQ.Orientation = orientation;
                    if (orientation == XlPivotFieldOrientation.xlRowField)
                    {
                        fieldQ.LayoutSubtotalLocation = XlSubtototalLocationType.xlAtBottom;
                        fieldQ.Subtotals[1] = showSubTotal;
                    }
                    if (orientation == XlPivotFieldOrientation.xlDataField)
                        fieldQ.Function = GetAggregrate(field[2]);

                    fieldQ.Position = i++;
                }
            }
        }

        private static XlConsolidationFunction GetAggregrate(string aggregrateList)
        {
            if (!string.IsNullOrEmpty(aggregrateList))
            {
                switch (Int32.Parse(aggregrateList.ToLower()))
                {
                    case (int)Function.Count:
                        return XlConsolidationFunction.xlCount;
                    case (int)Function.Sum:
                        return XlConsolidationFunction.xlSum;
                    case (int)Function.Maximum:
                        return XlConsolidationFunction.xlMax;
                    case (int)Function.Minimum:
                        return XlConsolidationFunction.xlMin;
                    case (int)Function.Average:
                        return XlConsolidationFunction.xlAverage;
                    default:
                        return XlConsolidationFunction.xlSum;
                }
            }
            return XlConsolidationFunction.xlSum;
        }

        public static System.Data.DataTable ConvertListToDataTable(object[,] list)
        {
            var rows = list.GetLength(0);
            var columns = list.GetLength(1);
            var myDataTable = new System.Data.DataTable();

            // create columns
            var blankColumn = " ";
            for (int i = 0; i < columns; i++)
            {
                myDataTable.Columns.Add(new DataColumn(
                    list[1, i + 1] != null
                        ? list[1, i + 1].ToString()
                        : blankColumn += " "));
            }

            for (int j = 1; j < rows; j++)
            {
                var row = myDataTable.NewRow();
                for (int i = 0; i < columns; i++)
                {
                    row[i] = list[j + 1, i + 1];
                }
                // add the current row to the DataTable
                myDataTable.Rows.Add(row);
            }
            return myDataTable;
        }
    }
}
