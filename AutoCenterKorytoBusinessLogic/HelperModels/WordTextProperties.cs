
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.HelperModels
{
    class WordTextProperties
    {
        public string Size { get; set; }
        public bool Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
