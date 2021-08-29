using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.HelperModels
{
    class ExcelCellParameters
    {
        public Worksheet Worksheet { get; set; }
        public string ColumnName { get; set; }
        public uint RowIndex { get; set; }
        public UInt32Value StyleIndex { get; set; }
        public string Text { get; set; }
        public SharedStringTablePart ShareStringPart { get; set; }
        public string CellReference => $"{ColumnName}{RowIndex}";
    }
}
