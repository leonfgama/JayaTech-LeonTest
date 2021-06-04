using JayaTech.LeonTest.Mock;
using JayaTech.LeonTest.Repository;
using JayaTech.LeonTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JayaTech.LeonTest.Test
{
    [TestClass]
    public class LogTest
    {
        public LogService LogService { get; set; }        

        [TestMethod]
        public void Test()
        {
            this.LogService = new LogService(new LogRepository());

            int count = this.LogService.GetCountAsync().Result;

            this.LogService.Log(new Exception("Leon Teste"), true);

            int newCount = this.LogService.GetCountAsync().Result;

            Assert.AreEqual(count + 1, newCount);
        }
    }
}
