using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]

    public class JobTests
    {

        [TestMethod]
        public void TestSettingJobId()
        {
            //Each Job object should contain a unique ID number, and these should also be sequential integers.
            Job obj1_test = new Job();
            Job obj2_test = new Job();
            Assert.AreNotEqual(obj1_test.Id, obj2_test.Id);
            Assert.AreEqual(1, obj2_test.Id - obj1_test.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            //The constructor correctly assigns the value of each field.
            Employer ACME = new Employer("ACME");
            Location Desert = new Location("Desert");
            PositionType Quality_control = new PositionType("Quality control");
            CoreCompetency Persistence = new CoreCompetency("Persistence");

            Job obj3_test = new Job("Product tester", ACME, Desert, Quality_control, Persistence);

            Assert.AreEqual("Product tester", obj3_test.Name);
            Assert.AreEqual(ACME, obj3_test.EmployerName);
            Assert.AreEqual(Desert, obj3_test.EmployerLocation);
            Assert.AreEqual(Quality_control, obj3_test.JobType);
            Assert.AreEqual(Persistence, obj3_test.JobCoreCompetency);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            //Two objects are NOT equal if their id values differ, even if all the other fields are identical.
            Employer ACME = new Employer("ACME");
            Location Desert = new Location("Desert");
            PositionType Quality_control = new PositionType("Quality control");
            CoreCompetency Persistence = new CoreCompetency("Persistence");

            Job obj4_test = new Job("Product tester", ACME, Desert, Quality_control, Persistence);
            Job obj5_test = new Job("Product tester", ACME, Desert, Quality_control, Persistence);

            Assert.IsFalse(Equals(obj4_test, obj5_test));
        }

        [TestMethod]
        public void TestToStringFirstAndLastLines()
        {
            Employer ACME = new Employer("ACME");
            Location Desert = new Location("Desert");
            PositionType Quality_control = new PositionType("Quality control");
            CoreCompetency Persistence = new CoreCompetency("Persistence");
            Job obj6_test = new Job("Product tester", ACME, Desert, Quality_control, Persistence);

            List<string> list1 = obj6_test.ToString().Split("\n").ToList();

            //Should return a string that contains a blank line before the job information.
            Assert.AreEqual("", list1[0]);
            //Should return a string that contains a blank line after the job information.
            Assert.AreEqual("", list1[7]);
            //Only 8 items in the list
            Assert.AreEqual(8, list1.Count);
        }

        [TestMethod]
        public void TestToStringData()
        {
            Employer ACME = new Employer("ACME");
            Location Desert = new Location("Desert");
            PositionType Quality_control = new PositionType("Quality control");
            CoreCompetency Persistence = new CoreCompetency("Persistence");
            
            //we reset nextId to make sure data is not polluted.
            Job.ResetNextId();
            
            Job obj7_test = new Job("Product tester", ACME, Desert, Quality_control, Persistence);

            List<string> list1 = obj7_test.ToString().Split("\n").ToList();

            //The string should contain a label for each field, followed by the data stored in that field. Each field should be on its own line.
            Assert.AreEqual("ID: 1", list1[1]);
            Assert.AreEqual("Name: Product tester", list1[2]);
            Assert.AreEqual("Employer: ACME", list1[3]);
            Assert.AreEqual("Location: Desert", list1[4]);
            Assert.AreEqual("Position Type: Quality control", list1[5]);
            Assert.AreEqual("Core Competency: Persistence", list1[6]);
        }

        [TestMethod]
        public void TestToStringDataNotAvailable()
        {
            Location Desert = new Location("Desert");
            PositionType Quality_control = new PositionType("Quality control");
            CoreCompetency Persistence = new CoreCompetency("Persistence");

            Employer Empty = new Employer("");
            Job obj8_test = new Job("Product tester", Empty, Desert, Quality_control, Persistence);

            List<string> list2 = obj8_test.ToString().Split("\n").ToList();

            //If a field is empty, the method should add, “Data not available” after the label.
            Assert.AreEqual("Employer: Data not available", list2[3]);
        }

        [TestMethod]
        public void TestToStringSetsOnlyId()
        {
            Employer Empty = new Employer("");
            Location empLoc = new Location("");
            PositionType empPos = new PositionType("");
            CoreCompetency empComp = new CoreCompetency("");
            Job obj9_test = new Job("", Empty, empLoc, empPos, empComp);

            //If a Job object ONLY contains data for the id field, the method should return, “OOPS! This job does not seem to exist.”
            Assert.AreEqual("OOPS! This job does not seem to exist.", obj9_test.ToString());
        }
    }
}
