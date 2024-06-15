using AdminDashboard.Models.Procedure;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult ViewReport(string ReportName,string list)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath($"~/Report/{ReportName}.rdlc");

            // you may comment dbContext if the report is static or needs no DB-connection
            //using (dbContext db = new dbContext())
            //{


            ReportDataSource User = new ReportDataSource(ReportName, JsonConvert.DeserializeObject<List<Spr_GetOrderInfo>>(list));
            localReport.DataSources.Add(User);


            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            string reportType = "PDF";
            string deviceInfo = "<DeviceInfo>" +
                "<OutputFormat>PDF</OutputFormat>" +
                "<PageWidth>11.69in</PageWidth>" +
                "<PageHeight>8.27in</PageHeight>" +
                "</DeviceInfo>";
            byte[] renderBytes;


            //// add report parameters here, if any
            //Microsoft.Reporting.WebForms.ReportParameter[] para = new ReportParameter[] {
            //        new ReportParameter("DateNow", DateTime.Now.ToString("dd/MM/yyy hh:mm:ss tt"))
            //    // , add more parameters if anymore exists ...
            //    };


            //localReport.SetParameters(para);

            renderBytes = localReport.Render(
                    reportType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings
                    );

            return File(renderBytes, "application/pdf");
            //} // end using
        }
    }
}