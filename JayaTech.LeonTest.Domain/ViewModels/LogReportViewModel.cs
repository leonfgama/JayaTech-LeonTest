using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JayaTech.LeonTest.Domain.ViewModels
{
    public class LogReportViewModel
    {
        public long AvgDuration { get; set; }
        public string AvgTime { get; set; }
        public int Count { get; set; }
        public int LogType { get; set; }
        public string LogTypeTitle { get; set; }
    }
}
