using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Windows.Forms;

namespace UnitTest
{
    /*
     * Jay Johnson
     * 11/12/2022
     * 
     * This unit test class is for the notification log form
     * It should ensure that all features work as expected
     */
    [TestClass]
    public class NotificationLogUnitTest
    {
        /*
         * Verifies that the search method finds the right data
         */
        [TestMethod]
        public void testSearchNotifications()
        {
            // Arange Phase

            //year, month, day, hour, min, seconds
            DateTime from = new DateTime(2022, 10, 17, 0, 0, 0);
            DateTime to = new DateTime(2022, 10, 17, 23, 59, 59);
            DataTable actual = new DataTable();
            DataTable expected = new DataTable();

            // Act Phase
            expected.Clear();
            expected.Columns.Add("notification_id", typeof(Int32));
            expected.Columns.Add("fk_sender_id", typeof(Int32));
            expected.Columns.Add("subject");
            expected.Columns.Add("message");
            expected.Columns.Add("send_datetime", typeof(DateTime));
            expected.Columns.Add("subscribers_recieved", typeof(Int32));
            expected.Rows.Add(100, 2, "JayTest1", "Testing", " 10/17/2022 10:34:09 AM", 500);
            expected.Rows.Add(101, 3, "JayTest2", "Super cool message", "10/17/2022 11:27:02 PM", 211);

            actual = Database.ManageNotifications.searchNotifications(from, to);

            // Assert Phase

            // it found 2 rows
            Assert.IsTrue(actual.Rows.Count == 2);

            // first row
            Assert.AreEqual(expected.Rows[0][0], actual.Rows[0][0]);
            Assert.AreEqual(expected.Rows[0][1], actual.Rows[0][1]);
            Assert.AreEqual(expected.Rows[0][2], actual.Rows[0][2]);
            Assert.AreEqual(expected.Rows[0][3], actual.Rows[0][3]);
            Assert.AreEqual(expected.Rows[0][4], actual.Rows[0][4]);
            Assert.AreEqual(expected.Rows[0][5], actual.Rows[0][5]);

            // second row
            Assert.AreEqual(expected.Rows[1][0], actual.Rows[1][0]);
            Assert.AreEqual(expected.Rows[1][1], actual.Rows[1][1]);
            Assert.AreEqual(expected.Rows[1][2], actual.Rows[1][2]);
            Assert.AreEqual(expected.Rows[1][3], actual.Rows[1][3]);
            Assert.AreEqual(expected.Rows[1][4], actual.Rows[1][4]);
            Assert.AreEqual(expected.Rows[1][5], actual.Rows[1][5]);
        }

        /*
         * Verifies that using fk_sender_id to get the username works
         */
        [TestMethod]
        public void testGetUsername()
        {
            // Arrange Phase
            DataTable data = new DataTable();
            Object actual = new Object();
            Object expected = new Object();

            // Act Phase
            expected = "firsttestaccount";

            data.Clear();
            data.Columns.Add("notification_id", typeof(Int32));
            data.Columns.Add("fk_sender_id", typeof(Int32));
            data.Columns.Add("subject");
            data.Columns.Add("message");
            data.Columns.Add("send_datetime", typeof(DateTime));
            data.Columns.Add("subscribers_recieved", typeof(Int32));
            data.Rows.Add(100, 2, "JayTest1", "Testing", " 10/17/2022 10:34:09 AM", 500);

            actual = Database.ManageUsers.getUsername(data.Rows[0][1]);

            // Assert Phase
            Assert.AreEqual(expected, actual);
        }

        /*
         * Verifies that tables pulled from the database are formatted correctly for display
         */
        [TestMethod]
        public void testFormatTable()
        {
            // Arrange Phase
            DataTable data = new DataTable();
            DataTable actual = new DataTable();
            DataTable expected = new DataTable();

            // Act Phase
            data.Clear();
            data.Columns.Add("notification_id", typeof(Int32));
            data.Columns.Add("fk_sender_id", typeof(Int32));
            data.Columns.Add("subject");
            data.Columns.Add("message");
            data.Columns.Add("send_datetime", typeof(DateTime));
            data.Columns.Add("subscribers_recieved", typeof(Int32));
            data.Rows.Add(100, 2, "JayTest1", "Testing", " 10/17/2022 10:34:09 AM", 500);

            expected.Clear();
            expected.Columns.Add("Sender", typeof(String));
            expected.Columns.Add("Subject");
            expected.Columns.Add("Message");
            expected.Columns.Add("Date/Time", typeof(DateTime));
            expected.Columns.Add("Recipients", typeof(Int32));
            expected.Rows.Add("firsttestaccount", "JayTest1", "Testing", " 10/17/2022 10:34:09 AM", 500);

            actual = UIHandler.UpdateDataGridView.formatTable(data);

            // Assert Phase

            // a column was removed
            Assert.IsTrue(actual.Columns.Count == 5);

            // the column names are correct
            Assert.IsTrue(actual.Columns.Contains("Sender"));
            Assert.IsTrue(actual.Columns.Contains("Subject"));
            Assert.IsTrue(actual.Columns.Contains("Message"));
            Assert.IsTrue(actual.Columns.Contains("Date/Time"));
            Assert.IsTrue(actual.Columns.Contains("Recipients"));

            // the row is the same
            Assert.AreEqual(expected.Rows[0][0], actual.Rows[0][0]);
            Assert.AreEqual(expected.Rows[0][1], actual.Rows[0][1]);
            Assert.AreEqual(expected.Rows[0][2], actual.Rows[0][2]);
            Assert.AreEqual(expected.Rows[0][3], actual.Rows[0][3]);
            Assert.AreEqual(expected.Rows[0][4], actual.Rows[0][4]);
        }

    }
}
