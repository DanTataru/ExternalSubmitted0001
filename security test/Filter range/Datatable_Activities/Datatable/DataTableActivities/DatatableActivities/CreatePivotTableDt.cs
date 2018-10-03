using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using DatatableActivities.Converters;
using DatatableActivities.Helpers;
using Microsoft.Office.Interop.Excel;

namespace DatatableActivities.DataTable
{
    [Designer(typeof(PivotTableDesigner))]
    public class CreatePivotTableDt : CodeActivity
    {
        #region Variables
        [Browsable(false)]
        public InArgument<string> StrInput0 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput1 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput2 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput3 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput4 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput5 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput6 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput7 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput8 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput9 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput10 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput11 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput12 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput13 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput14 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput15 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput16 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput17 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput18 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput19 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput20 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput21 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput22 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput23 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput24 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput25 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput26 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput27 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput28 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput29 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput30 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput31 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput32 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput33 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput34 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput35 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput36 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput37 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput38 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput39 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput40 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput41 { get; set; }

        [Browsable(false)]
        public InArgument<string> StrInput42 { get; set; }
        [Browsable(false)]
        public InArgument<string> StrInput43 { get; set; }
        [Browsable(false)]
        public InArgument<string> StrInput44 { get; set; }
        [Browsable(false)]
        public InArgument<string> StrInput45 { get; set; }

        [Browsable(false)]
        public InArgument<string> InputFilters { get; set; }
        #endregion

        [Category("Input")]
        [Description("Variable name of the datatable returned from other activity")]
        [DisplayName("Input DataTable")]
        [RequiredArgument]
        public InArgument<System.Data.DataTable> InputDataTable { get; set; }

        [Category("Output")]
        [Description("Datatable in which pivot table to be created")]
        [DisplayName("Datatable")]
        [RequiredArgument]
        public OutArgument<System.Data.DataTable> OutputDatatable { get; set; }

        [DisplayName("Show Subtotal")]
        public bool ShowSubTotal { get; set; }

        [DisplayName("Repeat Labels")]
        public bool RepeatLabels { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var headerFields = new List<string>
            {
                StrInput0.Get((context)),
                StrInput1.Get((context)),
                StrInput2.Get((context)),
                StrInput3.Get((context)),
                StrInput4.Get((context)),
                StrInput5.Get((context)),
                StrInput6.Get((context)),
                StrInput7.Get((context)),
                StrInput8.Get((context)),
                StrInput9.Get((context)),
                StrInput10.Get((context)),
                StrInput11.Get((context)),
                StrInput12.Get((context)),
                StrInput13.Get((context)),
                StrInput14.Get((context)),
                StrInput15.Get((context)),
                StrInput16.Get((context)),
                StrInput17.Get((context)),
                StrInput18.Get((context)),
                StrInput19.Get((context)),
                StrInput20.Get((context)),
                StrInput21.Get((context)),
                StrInput22.Get((context)),
                StrInput23.Get((context)),
                StrInput24.Get((context)),
                StrInput25.Get((context)),
                StrInput26.Get((context)),
                StrInput27.Get((context)),
                StrInput28.Get((context)),
                StrInput29.Get((context)),
                StrInput30.Get((context)),
                StrInput31.Get((context)),
                StrInput32.Get((context)),
                StrInput33.Get((context)),
                StrInput34.Get((context)),
                StrInput35.Get((context)),
                StrInput36.Get((context)),
                StrInput37.Get((context)),
                StrInput38.Get((context)),
                StrInput39.Get((context)),
                StrInput40.Get((context)),
                StrInput41.Get((context)),
                StrInput42.Get((context)),
                StrInput43.Get((context)),
                StrInput44.Get((context)),
                StrInput45.Get((context)),
            };

            var inputTable = InputDataTable.Get(context);

            var inputFilterString = InputFilters.Get(context);

            string[] inputFilters = PivotTableConverter.ToArray(inputFilterString);

            // Merge the variable list and data from grid
            for (int i = 0; i < inputFilters.GetLength(0); i++)
                inputFilters[i] = (headerFields[i] != null ? headerFields[i].Trim() : string.Empty) + "," +
                                  inputFilters[i];
            IList<string[]> inputData = inputFilters.Select(str => str.Split(',')).ToList();


            var rowFields = inputData.Where(field => field.Length == 3 && field[1].ToString() == "1").ToArray();
            var columnFields = inputData.Where(field => field.Length == 3 && field[1].ToString() == "2").ToArray();
            var valueFields = inputData.Where(field => field.Length == 3 && field[1].ToString() == "3").ToArray();
            var filterFields = inputData.Where(field => field.Length == 3 && field[1].ToString() == "4").ToArray();

            if (!rowFields.Any() && !columnFields.Any() && !valueFields.Any() && !filterFields.Any())
                throw new Exception("Cannot create pivot table, input fields not found.");

            System.Data.DataTable outputTable = null;
            var interopHelper = new ExcelInteropHelper();
            string tempExcelPath = string.Empty;
            Workbook workbook = null;
            try
            {
                tempExcelPath = Path.GetTempPath() + @"PivotWorkbook.xlsx";
                if (File.Exists(tempExcelPath))
                    File.Delete(tempExcelPath);

                workbook = interopHelper.CreateWorkBook(tempExcelPath);
                var pivotSheetInput = interopHelper.WriteDataToWorkSheet("PivotSheetInput", workbook, inputTable, 1);
                var pivotSheet = interopHelper.CreateWorkSheet("PivotSheet", workbook, 2);
                //if (InputDataTable != null && InputDataTable.Expression != null)
                //    inputSheetName = DtToExcelSheet(inputTable, workbook);

                //workbook.SetSheet(inputSheetName, false);

                var usedRange = pivotSheetInput.UsedRange;
                var address = usedRange.get_Address();

                var pCaches = workbook.PivotCaches();
                var pCache = pCaches.Create(XlPivotTableSourceType.xlDatabase,
                    string.Format("{0}!{1}", pivotSheetInput.Name, address),
                    XlPivotTableVersionList.xlPivotTableVersion14);

                pivotSheet.Activate();
                var rngDes = pivotSheet.Cells[1][1];

                var pTable = pCache.CreatePivotTable(rngDes, "PivotTable1", true,
                    XlPivotTableVersionList.xlPivotTableVersion14);

                pivotSheet.Cells[1][1].Select();

                // row fields
                HelperFunctions.AddFields(pTable, rowFields, XlPivotFieldOrientation.xlRowField,
                    ShowSubTotal);
                // column fields
                HelperFunctions.AddFields(pTable, columnFields, XlPivotFieldOrientation.xlColumnField);
                // value fields
                HelperFunctions.AddFields(pTable, valueFields, XlPivotFieldOrientation.xlDataField);
                // Filter fields
                HelperFunctions.AddFields(pTable, filterFields, XlPivotFieldOrientation.xlPageField);

                // Show in tabular format always
                pTable.RowAxisLayout(XlLayoutRowType.xlTabularRow);

                // If repeat labels?
                if (RepeatLabels)
                    pTable.RepeatAllLabels(XlPivotFieldRepeatLabels.xlRepeatLabels);
                
                workbook.Save();
                usedRange = pivotSheet.UsedRange;

                var pivotData = usedRange.Value;
                outputTable = HelperFunctions.ConvertListToDataTable(pivotData);

                // We can delete the temp output sheet at last
                //workbook.CurrentWorkbook.Sheets[outputSheetName].Delete();

                //if (ExcelHelper.SheetExists(workbook, TempInputForDatatable))
                //    workbook.CurrentWorkbook.Sheets[TempInputForDatatable].Delete();

                OutputDatatable.Set(context, outputTable);

            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating the pivot table from datatable", ex);
            }
            finally
            {
                interopHelper.Cleanup(workbook);
                if (File.Exists(tempExcelPath))
                    File.Delete(tempExcelPath);
            }
        }
    }
}
