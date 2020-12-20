// *********************************************************************** Assembly :
// JackHenryTwitter.Tests Author : Chuck Created : 12-15-2020
//
// Last Modified By : Chuck Last Modified On : 12-15-2020 ***********************************************************************
// <copyright file="HomeControllerTest.cs" company="">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using JackHenryTwitter.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace JackHenryTwitter.Tests.Controllers
{
    /// <summary>
    /// Defines test class HomeControllerTest.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region Public Methods

        /// <summary>
        /// Defines the test method About.
        /// </summary>
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        /// <summary>
        /// Defines the test method Contact.
        /// </summary>
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Defines the test method Index.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion Public Methods
    }
}