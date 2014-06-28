using System;
using NUnit.Framework;

namespace Journey.Core.Reporting
{
    [SetUpFixture]
    public class JourneyReportingFixture
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            Console.WriteLine("Starting all tests");
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            JourneyRunner.Current.RunReport();
        }
    }
}