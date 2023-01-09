using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

/*
 *  Andrew J Marchese
 *  11/12/22
 *  
 *  Tests methods from the database-methods class
 */
namespace UnitTest
{
    [TestClass]
    public class DatabaseMethodsUnitTest
    {
        /*
         * Declare commonly used variables
         */
        private const String subject = "testSubject";
        private const String body = "testBody";
        private const String name = "testName";
        /*
         * Tests if the save button works properly
         */
        [TestMethod]
        public void saveTemplateTest()
        {
            //Initializing target variables
            String subjectTarget = "testSubject";
            String bodyTarget = "testBody";
            String nameTarget = "testName";

            //Action phase
            Database.ManageTemplates.saveTemplate(5, subject, body, name);

            //Assert Phase
            Assert.AreEqual(subjectTarget, subject);
            Assert.AreEqual(bodyTarget, body);
            Assert.AreEqual(nameTarget, name);

            //Delete test insertion
            Database.ManageTemplates.deleteTemplate(name);
        }
        /*
        * Tests if the delete button works properly
        */
        [TestMethod]
        public void deleteTemplateTest()
        {
            //Initializing target variables
            String subjectTarget = String.Empty;
            String bodyTarget = String.Empty;
            String nameTarget = String.Empty;

            //Create a template
            Database.ManageTemplates.saveTemplate(5, subject, body, name);

            //Test to make sure the template is non existant
            Assert.AreEqual(subjectTarget, String.Empty);
            Assert.AreEqual(bodyTarget, String.Empty);
            Assert.AreEqual(nameTarget, String.Empty);

            //Delete the template created above
            Database.ManageTemplates.deleteTemplate(name);
        }
        /*
         * Tests if the combo box selection retrieves the subject properly
         */
        [TestMethod]
        public void getSubjectTest()
        {
            //Initializing target variable
            String nameTarget = "testName";

            //Create a template
            Database.ManageTemplates.saveTemplate(5, subject, body, name);

            //Get the name from the template created above
            Database.ManageTemplates.fetchSubject(name);

            //Test the name to match the target name
            Assert.AreEqual(nameTarget, name);

            //Delete the template created above
            Database.ManageTemplates.deleteTemplate(name);
        }
        /*
         * Tests if the combo box selection retrieves the body properly
         */
        [TestMethod]
        public void getBodyTest()
        {
            //Initializing target variable
            String bodyTarget = "testBody";

            //Create a template
            Database.ManageTemplates.saveTemplate(5, subject, body, name);

            //Get the name from the template created above
            Database.ManageTemplates.fetchMessage(body);

            //Test the name to match the target name
            Assert.AreEqual(bodyTarget, body);

            //Delete the template created above
            Database.ManageTemplates.deleteTemplate(name);
        }
        /*
         * Tests if the combo box drop down retrieves the template names properly
         */
        [TestMethod]
        public void getNamesTest()
        {
            //Initializing target variables
            String targetName1 = "testName1";
            String targetName2 = "testName2";
            String targetName3 = "testName3"; 

            //Create a list, add variables to it, and count the length 
            List<String> testList = new List<String>();
            testList.Add("testName1");
            testList.Add("testName2");
            testList.Add("testName3");
            int listLength = testList.Count;

            //Create multiple difference templates
            for (int i = 0; i < listLength; i++)
            {
                Database.ManageTemplates.saveTemplate(5, subject, body, testList[i]);
            }

            //Get the names from the template created above
            testList = Database.ManageTemplates.loadTemplateNames();

            //Test the names in the list to match the target name
            Assert.AreEqual(targetName1, testList[testList.Count - 3]);
            Assert.AreEqual(targetName2, testList[testList.Count - 2]);
            Assert.AreEqual(targetName3, testList[testList.Count - 1]);

            //Delete the templates created above
            for (int i = testList.Count - 3; i < testList.Count; i++)
            {
                Database.ManageTemplates.deleteTemplate(testList[i]);
            }
        }
    }
}
