using System;
using System.Data;
using CodingTest.Helper;
using Moq;
using NUnit;
using NUnit.Framework;

namespace CodeTestingUnitTest.HelperTests
{
    [TestFixture]
    public class ModelBinderTests
    {
        [Test]
        public void Bind_InValidData()
        {
            var csvTable = new DataTable();

            var result= ModelBinder.Bind(csvTable, 0);

            Assert.That(result, Is.Null);

        }
        //[Test]
        //public void Bind_ValidData()
        //{
        //    var csvTable = new DataTable();

        //    var result = ModelBinder.Bind(csvTable, 0);

        //    Assert.That(result, Is.Null);

        //}
    }
}
