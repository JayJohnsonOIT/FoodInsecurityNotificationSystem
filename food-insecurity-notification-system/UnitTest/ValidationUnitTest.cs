using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InputValidation;

namespace UnitTest
{
    /*
     * Maxwell Robinson
     * 11/12/22
     * 
     * Test methods for the Validate class
     */
    [TestClass]
    public class ValidationUnitTest
    {
        [TestMethod]
        public void TestValidateUserName()
        {
            Assert.AreEqual(true, AccountValidation.validateUsername("Username"));
            Assert.AreEqual(false, AccountValidation.validateUsername(""));
        }

        [TestMethod]
        public void TestValidatePassword()
        {
            Assert.AreEqual(true, AccountValidation.validatePassword("Password123"));
            Assert.AreEqual(false, AccountValidation.validatePassword("password123"));
            Assert.AreEqual(false, AccountValidation.validatePassword("PASSWORD"));
        }

        [TestMethod]
        public void TestValidateEmail()
        {
            Assert.AreEqual(true, AccountValidation.validateEmail("TestEmail@website.com"));
            Assert.AreEqual(false, AccountValidation.validateEmail("badformat.com"));
            Assert.AreEqual(false, AccountValidation.validateEmail("bad@format"));
        }

        [TestMethod]
        public void TestValidateName()
        {
            Assert.AreEqual(true, AccountValidation.validateName("John Test"));
            Assert.AreEqual(false, AccountValidation.validateName("a"));
        }
    }
}
