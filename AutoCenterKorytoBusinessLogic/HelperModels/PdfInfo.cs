using System;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportViewModel> DataForReport { get; set; }
    }
}
