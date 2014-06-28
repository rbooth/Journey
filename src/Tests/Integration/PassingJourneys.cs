using Journey.Core;
using NUnit.Framework;

namespace Journey.Tests.Integration
{
    [TestFixture]
    public class PassingJourneys
    {
        [Test]
        public void PassingJourney1()
        {
            UserJourney
                .For("simple test")
                .User(DoesSoemthing)
                    .Verify(TheyDidTheRightThing)
                .Run();
        }

        private void TheyDidTheRightThing()
        {
            Assert.True(true,"The user is always right");
        }

        private void DoesSoemthing()
        {
           
        }
    }
}