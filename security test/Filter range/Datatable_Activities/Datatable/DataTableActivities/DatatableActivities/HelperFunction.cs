using System;
using System.Collections.Generic;
using DatatableActivities.Enum;
using DatatableActivities.Extensions;
using Utility.Models;

namespace DatatableActivities.Helpers
{
    public class HelperFunction
    {
        public static T GetValue<T>(object valueToParse, string fieldName)
        {
            T value = default(T);
            var type = typeof(T);

            try
            {
                //if (type.IsEnum) // Parse enum value
                //    value = EnumExtensions.GetEnum<T>(valueToParse);
                //else 
                if (type == typeof(bool)) // parse boolean value
                    value = (T)Convert.ChangeType((valueToParse.ToString().ToUpper()) == "TRUE", type);
                else // Parse other value types
                {
                    // Conversion for nullable types where value is null is now supported
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        if (valueToParse.Equals(DBNull.Value))
                        {
                            return default(T);
                        }
                        type = Nullable.GetUnderlyingType(type);
                    }
                    else if (valueToParse == null || valueToParse.Equals(DBNull.Value))
                    {
                        return default(T);
                    }
                    value = (T)Convert.ChangeType(valueToParse, type);
                }
            }
            catch (Exception)
            {
                //throw new ParseException(sheetName, row, column, type, valueToParse, fieldName);
            }
            return value;
        }

        private static List<string> ArrayToList(Array arr, string header, bool notLike = false)
        {
            var list = new List<string>();
            foreach (var val in arr)
            {
                list.Add(string.Format("[{0}] {1} LIKE '*{2}*'", header, notLike ? "NOT" : string.Empty, val));
            }
            return list;
        }

        public static List<string> GetFilterCondition(List<FilterExpressionRow> filterRows)
        {
            var rowFilters = new List<string>();
            foreach (var row in filterRows)
            {
                switch (EnumExtensions.GetEnum<FilterOperator>(row.FilterOperator))
                {
                    case FilterOperator.Equals:
                        rowFilters.Add(string.Format("[{0}] = '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Does_Not_Equal:
                        rowFilters.Add(string.Format("[{0}] <> '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Begins_With:
                        rowFilters.Add(string.Format("[{0}] LIKE '{1}*'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Does_Not_Begin_With:
                        rowFilters.Add(string.Format("[{0}] NOT LIKE '{1}*'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Ends_With:
                        rowFilters.Add(string.Format("[{0}] LIKE '*{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Does_Not_End_With:
                        rowFilters.Add(string.Format("[{0}] NOT LIKE '*{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Contains:
                        rowFilters.Add(string.Format("({0})",
                            string.Join(" OR ", ArrayToList(row.ValueArray, row.HeaderText))));
                        break;
                    case FilterOperator.Does_Not_Contain:
                        rowFilters.Add(string.Format("({0})",
                            string.Join(" AND ", ArrayToList(row.ValueArray, row.HeaderText, true))));
                        break;
                    case FilterOperator.Is_Greater_Than:
                        rowFilters.Add(string.Format("[{0}] > '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Is_Greater_Than_Or_Equal_To:
                        rowFilters.Add(string.Format("[{0}] >= '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Is_Less_Than:
                        rowFilters.Add(string.Format("[{0}] < '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                    case FilterOperator.Is_Less_Than_Or_Equal_To:
                        rowFilters.Add(string.Format("[{0}] <= '{1}'", row.HeaderText,
                            row.ValueArray.GetValue(0)));
                        break;
                }
            }
            return rowFilters;
        }

        public static void AppendToDt(System.Data.DataTable outputDt, string value, string splitCharacter)
        {
            // If output datatable is defined, then add the value to datatable as well
            if (outputDt != null)
            {
                var row = outputDt.NewRow();
                var values = value.Split(new string[] { splitCharacter }, StringSplitOptions.None);
                int i = 0;
                foreach (var val in values)
                    row[i++] = val;
                outputDt.Rows.Add(row);
            }
        }
    }
}
