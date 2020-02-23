using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTW_InterviewChallenge.Functions;

namespace WTW_InterviewChallenge.Test
{
    [TestClass]
    public class EmailAddressTests
    {
        EmailAddressHelpers emailAddressHelpers = new EmailAddressHelpers();

        [TestMethod]
        public void Test_Email_OnlyUnique()
        {
            string[] emails = { "user1@somewhere.com", "user2@somewhere.com", "user3@somewhere.com", "user4@somewhere.com" };

            Assert.AreEqual(4, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_DotExclude_Single()
        {
            string[] emails = { "team1leader@somewhere.com", "team.1leader@somewhere.com", "team.1.leader@somewhere.com" };

            Assert.AreEqual(1, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_DotExclude_Multiple()
        {
            string[] emails = { "team1leader@somewhere.com", "team.1leader@somewhere.com", "team.1.leader@somewhere.com", 
                "team2leader@somewhere.com", "team.2leader@somewhere.com", "team.2.leader@somewhere.com",
                "team3leader@somewhere.com", "team.3leader@somewhere.com", "team.3.leader@somewhere.com",
                "team4leader@somewhere.com", "team.4leader@somewhere.com", "team.4.leader@somewhere.com"};

            Assert.AreEqual(4, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_PlusIgnore_Single()
        {
            string[] emails = { "team1@somewhere.com", "team1+bob@somewhere.com", "team1+jill+bob@somewhere.com" };

            Assert.AreEqual(1, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_PlusIgnore_Multiple()
        {
            string[] emails = { "team1@somewhere.com", "team1+bob@somewhere.com", "team1+jill+bob@somewhere.com",
                "team2@somewhere.com", "team2+jane@somewhere.com", "team1+fred+george@somewhere.com",
                "admins@somewhere.com", "admins+local@somewhere.com", "admins+intl@somewhere.com",
                "it@somewhere.com", "it+dba@somewhere.com", "it+server@somewhere.com", "it+dev@somewhere.com"};

            Assert.AreEqual(4, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_Variety()
        {
            string[] emails = { "team1@somewhere.com", "team1+bob@somewhere.com", "team1+jill+bob@somewhere.com",
                "team1leader@somewhere.com", "team.1leader@somewhere.com", "team.1.leader@somewhere.com",
                "team2leader+weekend@somewhere.com", "team.2leader+weekday@somewhere.com", "team.2.leader+late@somewhere.com",
                "team5leader@somewhere.com", "team.5leader+dev+qa+rel@somewhere.com", "team.5.leader+ops.coord@somewhere.com","team.5.leader+ops.coord+rel.manage@somewhere.com"};

            Assert.AreEqual(4, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_Variety_InvalidEntries()
        {
            string[] emails = { "team1-test@somewhere.com", "team1+bob@somewhere.com", "team1+jill+bob@somewhere.com",
                "team1leader@somewhere.com", "team.1,leader@somewhere.com", "team.1.leader@somewhere.com",
                "team2leader+weekend@somewhere.com", "team.2leader+weekday@somewhere.com", "team.2.leader+late@somewhere.com",
                "team5leader@somewhere.com", "team.5leader+dev+qa+rel@somewhere.com", 
                "team.5.leader+ops.coord@example.com","team.5.leader+ops.coord+rel.manage@example.com",
                "t&st.email+team@somewhere.com", "test@example^s.com"};

            Assert.AreEqual(5, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_Uppercase()
        {
            string[] emails = { "TEAM1@somewhere.com", "team1+BOB@SOMEWHERE.com", "TEAM1+JILL+bob@somewhere.com" };

            Assert.AreEqual(1, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_InvalidCharacters()
        {
            string[] emails = { "team1#dev@somewhere.com", "team2!@somewhere.com", "team3%intel%@somewhere.com" };

            Assert.AreEqual(0, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_InvalidDomain()
        {
            string[] emails = { "team1@somewhere.com-false", "team1+bob@some+where?.com", "team1+jill+bob@#somewhere#.com" };

            Assert.AreEqual(0, emailAddressHelpers.NumberOfUniqueEmailAddresses(emails));
        }

        [TestMethod]
        public void Test_Email_LargeSet()
        {
            string[] emails = GenerateEmailSet(100000);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = emailAddressHelpers.NumberOfUniqueEmailAddresses(emails);
            watch.Stop();

            Assert.IsTrue(watch.ElapsedMilliseconds <= 1000);
            Assert.AreEqual(100000, result);
        }

        private string[] GenerateEmailSet(int count)
        {
            string[] results = new string[count];
            for(int i = 0; i < count; i++)
            {
                results[i] = "user." + i + "+test@example.com";
            }
            return results;
        }
    }
}
