using System;
using System.Activities;
namespace Utility.Models
{
    public class FilterExpressionRow
    {
        #region properties

        private InArgument<string> _headerExpression;
        public InArgument<string> HeaderExpression
        {
            get { return _headerExpression; } 
            set { _headerExpression = value; }
        }

        private InArgument<Array> _valueExpression;
        public InArgument<Array> ValueExpression
        {
            get { return _valueExpression; }
            set { _valueExpression = value; }
        }

        public int FilterOperator { get; set; }
        public string HeaderText;
        public Array ValueArray;
        public int HeaderIndex;

        #endregion
    }

}
