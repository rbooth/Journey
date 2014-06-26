using System;
using Journey.Core.Reporting;
using NUnit.Framework;

namespace UnitTests
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