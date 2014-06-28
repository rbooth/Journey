using Journey.Core;
using NUnit.Framework;

namespace Journey.Tests.UserJourneys
{
    [TestFixture]
    public class UserJourneyTests
    {
        [Test]
        public void CreatesResultForAllUserSteps()
        {
            var journey = UserJourney.For("simple test")
                .User(DoesSoemthing)
                .User(DoesSoemthingElse)
                .User(DoesAnotherThing);
            
            journey.Run();

            Assert.That(journey.Results.Count == 3);
        }

        [Test]
        public void CreatesResultForAllVerificationSteps()
        {
            var journey = UserJourney.For("simple test")
                .Verify(DoesSoemthing)
                .Verify(DoesSoemthingElse)
                .Verify(DoesAnotherThing);

            journey.Run();

            Assert.That(journey.Results.Count == 3);
        }

        [Test]
        public void CreatesResultForAllVerificationAndUserSteps()
        {
            var journey = UserJourney.For("simple test")
                .User(DoesSoemthing)
                .Verify(DoesAnotherThing);

            journey.Run();

            Assert.That(journey.Results.Count == 2);
        }

        [Test]
        public void AndsAreIncludedInResults()
        {
            var journey = UserJourney.For("simple test")
                .User(DoesSoemthing)
                .And(DoesSoemthingElse)
                .Verify(DoesAnotherThing);

            journey.Run();

            Assert.That(journey.Results.Count == 3);
        }

        private void DoesSoemthing()
        {
            var x = 2 + 2;
        }

        private void DoesSoemthingElse()
        {
            var x = 2 + 2;
        }

        private void DoesAnotherThing()
        {
            var x = 2 + 2;
        }
    }
}
