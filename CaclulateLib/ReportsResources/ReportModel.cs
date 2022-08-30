using System;
using System.Collections.Generic;
using System.Text;

namespace CaclulateLib.ReportsResources
{
    public class ReportModel
    {
        public string Xmfak { get; set; }

        public string Dust { get; set; }
        public string Range { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Title4 { get; set; }
        public string Title5 { get; set; }
      
        public IEnumerable<RowReportModel> RowReport { get; set; }
    }
}
