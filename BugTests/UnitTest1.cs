using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAssignBug()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState(), "Bug should be assigned");
        }

        [TestMethod]
        public void TestCloseBug()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState(), "Bug should be closed");
        }

        [TestMethod]
        public void TestDeferBug()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Defer();
            Assert.AreEqual(Bug.State.Defered, bug.getState(), "Bug should be deferred");
        }

        [TestMethod]
        public void TestReassignAfterDefer()
        {
            var bug = new Bug(Bug.State.Defered);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState(), "Bug should be reassigned after defer");
        }

        [TestMethod]
        public void TestIgnoreAssignWhenAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState(), "Bug should remain assigned");
        }

        [TestMethod]
        public void TestReassignAfterClose()
        {
            var bug = new Bug(Bug.State.Closed);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState(), "Bug should be reassigned after closing");
        }

        [TestMethod]
        public void TestMultipleAssignAndDefer()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Defer();
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState(), "Bug should be assigned after multiple actions");
        }

        [TestMethod]
        public void TestCloseFromDefer()
        {
            var bug = new Bug(Bug.State.Defered);
            bug.Assign();
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState(), "Bug should be closed after defer and assign");
        }

        [TestMethod]
        public void TestOpenBugState()
        {
            var bug = new Bug(Bug.State.Open);
            Assert.AreEqual(Bug.State.Open, bug.getState(), "Bug should be in Open state");
        }

        [TestMethod]
        public void TestStateTransitionSequence()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Defer();
            bug.Assign();
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState(), "Bug should follow correct state transitions and end as Closed");
        }
    }
}
