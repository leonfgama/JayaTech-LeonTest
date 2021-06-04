using JayaTech.LeonTest.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JayaTech.LeonTest.Test
{   
    public interface ITestBase
    {
        [TestMethod]
        void Insert();
        [TestMethod]
        void Update();
        [TestMethod]
        void Delete();
        [TestMethod]
        void Get();
    }
}
