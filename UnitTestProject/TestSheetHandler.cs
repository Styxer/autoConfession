using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using autoConfession;

namespace UnitTestProject
{
    [TestClass]
    public class TestSheetHandler
    {
        private SpreadsheetHandling handler;
        private PrivateObject obj;

        [TestInitialize]
        public void init()
        {
            handler = new SpreadsheetHandling();
            obj = new PrivateObject(handler);
        }

        [TestMethod]
        public void testextractSheetIDFromLink()
        {
            object sheetFullllink = @"https://docs.google.com/spreadsheets/d/15HIx2tD-E-zBn6ZY4rMjv0IlE0pu_dGoc7ybuqbkXXI/edit#gid=1070981831";
            object expectedResult = @"15HIx2tD-E-zBn6ZY4rMjv0IlE0pu_dGoc7ybuqbkXXI";
            object result = obj.Invoke("extractSheetIDFromLink", new object[] { sheetFullllink });

            Assert.AreEqual(expected: expectedResult, actual: result);

        }
    }
}
