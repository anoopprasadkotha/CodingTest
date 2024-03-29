﻿using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CodingTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeTestingUnitTest.ControllerTests
{
    [TestClass]
    public class HomecontrollerUnitTests
    {
        [TestMethod]
        public void Upload_HasNoReturnView()
        {
            HomeController controllerUnderTest = new HomeController();
            var result = controllerUnderTest.Upload() as System.Web.Mvc.ViewResult;
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void Upload_Filetype_NotCSv()
        {
         
            HomeController controllerUnderTest = new HomeController();
            string filePath = @"D:IDserver_logotransparent.jpeg";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Mock<HttpPostedFileBase> uploadedFile = new Mock<HttpPostedFileBase>();
            uploadedFile.Setup(x => x.FileName).Returns("IDserver_logotransparent.jpeg");
            uploadedFile.Setup(x => x.ContentType).Returns("image/png");
            uploadedFile.Setup(x => x.InputStream).Returns(fileStream);
            uploadedFile.Setup(x => x.ContentLength).Returns(5);
            HttpPostedFileBase httpPostedFileBases =  uploadedFile.Object ;
            var result = controllerUnderTest.Upload(httpPostedFileBases) as ViewResult;
            //Assert.IsFalse(result);
            var modelState = controllerUnderTest.ModelState;

            Assert.AreEqual(1, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("File"));
            Assert.IsTrue(modelState["File"].Errors.Count == 1);
            Assert.AreEqual("This file format is not supported", modelState["File"].Errors[0].ErrorMessage);

        }
        [TestMethod]
        public void Upload_Filetype_CSvWithNoContent()
        {

            HomeController controllerUnderTest = new HomeController();
            string filePath = @"D:Customer.csv";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Mock<HttpPostedFileBase> uploadedFile = new Mock<HttpPostedFileBase>();
            uploadedFile.Setup(x => x.FileName).Returns("customer.csv");
            uploadedFile.Setup(x => x.ContentType).Returns("csv");
            uploadedFile.Setup(x => x.InputStream).Returns(fileStream);
            uploadedFile.Setup(x => x.ContentLength).Returns(0);
           // uploadedFile.Setup(x => x.InputStream).Returns(new Stream =" ");
            HttpPostedFileBase httpPostedFileBases = uploadedFile.Object;
            var result = controllerUnderTest.Upload(httpPostedFileBases) as ViewResult;
            //Assert.IsFalse(result);
            var modelState = controllerUnderTest.ModelState;

            Assert.AreEqual(1, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("File"));
            Assert.IsTrue(modelState["File"].Errors.Count == 1);
            Assert.AreEqual("Please Upload Your file", modelState["File"].Errors[0].ErrorMessage);

        }



    }
}
