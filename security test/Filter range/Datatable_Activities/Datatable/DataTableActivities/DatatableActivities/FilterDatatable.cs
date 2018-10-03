using System;
using System.Activities;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DatatableActivities.Designers;
using DatatableActivities.Helpers;
using Utility.Models;

namespace DatatableActivities.DataTable
{
    [Designer(typeof(FilterDesigner))]
    [DisplayName("Filter Datatable")]
    public class FilterDatatable : CodeActivity
    {
        private readonly Dictionary<string, string> _variables;

        #region inputfields
        [Browsable(false)]
        public InArgument<string> HeaderExpression0 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression0 { get; set; }
        [Browsable(false)]
        public int FilterOperator0 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression1 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression1 { get; set; }
        [Browsable(false)]
        public int FilterOperator1 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression2 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression2 { get; set; }
        [Browsable(false)]
        public int FilterOperator2 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression3 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression3 { get; set; }
        [Browsable(false)]
        public int FilterOperator3 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression4 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression4 { get; set; }
        [Browsable(false)]
        public int FilterOperator4 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression5 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression5 { get; set; }
        [Browsable(false)]
        public int FilterOperator5 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression6 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression6 { get; set; }
        [Browsable(false)]
        public int FilterOperator6 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression7 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression7 { get; set; }
        [Browsable(false)]
        public int FilterOperator7 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression8 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression8 { get; set; }
        [Browsable(false)]
        public int FilterOperator8 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression9 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression9 { get; set; }
        [Browsable(false)]
        public int FilterOperator9 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression10 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression10 { get; set; }
        [Browsable(false)]
        public int FilterOperator10 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression11 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression11 { get; set; }
        [Browsable(false)]
        public int FilterOperator11 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression12 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression12 { get; set; }
        [Browsable(false)]
        public int FilterOperator12 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression13 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression13 { get; set; }
        [Browsable(false)]
        public int FilterOperator13 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression14 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression14 { get; set; }
        [Browsable(false)]
        public int FilterOperator14 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression15 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression15 { get; set; }
        [Browsable(false)]
        public int FilterOperator15 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression16 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression16 { get; set; }
        [Browsable(false)]
        public int FilterOperator16 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression17 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression17 { get; set; }
        [Browsable(false)]
        public int FilterOperator17 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression18 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression18 { get; set; }
        [Browsable(false)]
        public int FilterOperator18 { get; set; }

        [Browsable(false)]
        public InArgument<string> HeaderExpression19 { get; set; }
        [Browsable(false)]
        public InArgument<Array> ValueExpression19 { get; set; }
        [Browsable(false)]
        public int FilterOperator19 { get; set; }
        #endregion

        private List<FilterExpressionRow> filterRows { get; set; }

        [Category("Input")]
        [Description("Input Datatable")]
        [DisplayName("DataTable")]
        [RequiredArgument]
        public InArgument<System.Data.DataTable> InputDataTable { get; set; }

        [Category("Output")]
        [Description("Datatable which will contain filtered values")]
        [DisplayName("Datatable")]
        [RequiredArgument]
        public OutArgument<System.Data.DataTable> OutputDatatable { get; set; }

        public FilterDatatable()
        {
            _variables = new Dictionary<string, string>();
        }

        protected override void Execute(CodeActivityContext context)
        {
            filterRows = new List<FilterExpressionRow>();
            _variables.Clear();

            var dc = context.DataContext;
            foreach (var p in dc.GetProperties())
            {
                var value = ((PropertyDescriptor)p).GetValue(dc);
                if (value != null)
                    _variables.Add(((PropertyDescriptor)p).Name, value.ToString());
            }

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression0.Get(context),
                ValueExpression = ValueExpression0.Get(context),
                FilterOperator = FilterOperator0
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression1.Get(context),
                ValueExpression = ValueExpression1.Get(context),
                FilterOperator = FilterOperator1
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression2.Get(context),
                ValueExpression = ValueExpression2.Get(context),
                FilterOperator = FilterOperator2
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression3.Get(context),
                ValueExpression = ValueExpression3.Get(context),
                FilterOperator = FilterOperator3
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression4.Get(context),
                ValueExpression = ValueExpression4.Get(context),
                FilterOperator = FilterOperator4
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression5.Get(context),
                ValueExpression = ValueExpression5.Get(context),
                FilterOperator = FilterOperator5
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression6.Get(context),
                ValueExpression = ValueExpression6.Get(context),
                FilterOperator = FilterOperator6
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression7.Get(context),
                ValueExpression = ValueExpression7.Get(context),
                FilterOperator = FilterOperator7
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression8.Get(context),
                ValueExpression = ValueExpression8.Get(context),
                FilterOperator = FilterOperator8
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression9.Get(context),
                ValueExpression = ValueExpression9.Get(context),
                FilterOperator = FilterOperator9
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression10.Get(context),
                ValueExpression = ValueExpression10.Get(context),
                FilterOperator = FilterOperator10
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression11.Get(context),
                ValueExpression = ValueExpression11.Get(context),
                FilterOperator = FilterOperator11
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression12.Get(context),
                ValueExpression = ValueExpression12.Get(context),
                FilterOperator = FilterOperator12
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression13.Get(context),
                ValueExpression = ValueExpression13.Get(context),
                FilterOperator = FilterOperator13
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression14.Get(context),
                ValueExpression = ValueExpression14.Get(context),
                FilterOperator = FilterOperator14
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression15.Get(context),
                ValueExpression = ValueExpression15.Get(context),
                FilterOperator = FilterOperator0
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression16.Get(context),
                ValueExpression = ValueExpression16.Get(context),
                FilterOperator = FilterOperator16
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression17.Get(context),
                ValueExpression = ValueExpression17.Get(context),
                FilterOperator = FilterOperator17
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression18.Get(context),
                ValueExpression = ValueExpression18.Get(context),
                FilterOperator = FilterOperator18
            });

            filterRows.Add(new FilterExpressionRow()
            {
                HeaderExpression = HeaderExpression19.Get(context),
                ValueExpression = ValueExpression19.Get(context),
                FilterOperator = FilterOperator19
            });

            foreach (var row in filterRows)
            {
                var directHead = (row.HeaderExpression.Expression) as Literal<string>;
                if (directHead != null)
                    row.HeaderText = directHead.Value != null ? directHead.Value.Trim() : null;

                var directVal = row.ValueExpression.Expression as Literal<Array>;
                if (directVal != null)
                    row.ValueArray = directVal.Value;
            }

            filterRows =
                new List<FilterExpressionRow>(
                    filterRows.Where(
                        r =>
                            r.HeaderText != null &&
                            r.ValueArray != null &&
                            r.FilterOperator != 0
                        ));

            var inputTable = InputDataTable.Get(context);

            System.Data.DataTable outputTable = null;
            try
            {
                var rowFilters = HelperFunction.GetFilterCondition(filterRows);
                
                inputTable.DefaultView.RowFilter = string.Join(" AND ", rowFilters);

                if (OutputDatatable != null && OutputDatatable.Expression != null)
                    outputTable = inputTable.DefaultView.ToTable();

                inputTable.DefaultView.RowFilter = "";

                OutputDatatable.Set(context, outputTable);
            }
            catch
            {
                throw new Exception("There was an error while applying the filter");
            }
        }
    }
}
