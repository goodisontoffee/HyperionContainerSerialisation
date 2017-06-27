namespace HyperionContainerSerialisation.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Akka.Actor;
    using Akka.Configuration;
    using Akka.TestKit.NUnit3;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ProvisioningActorTests : TestKit
    {
        public ProvisioningActorTests() : base(ConfigurationFactory.ParseString(HOCON.StandardTestHOCON))
        {
        }

        [Test]
        public void RequestForNamesShouldProvisionTheRightName()
        {
            // Arrange
            var sut = ActorOf<ProvisioningActor>();

            // Act
            sut.Tell(new NameRequestMessage());

            // Assert
            var result = FishForMessage<ProvisioningResultMessage<IEnumerable<Name>>>(m => true);
            result.Result.Count().Should().Be(4);
        }

        [Test]
        public void RequestForDatesShouldProvisionTheRightDates()
        {
            // Arrange
            var sut = ActorOf<ProvisioningActor>();

            // Act
            sut.Tell(new DateRequestMessage());

            // Assert
            var result = FishForMessage<ProvisioningResultMessage<IEnumerable<IContainer<DateTime?>>>>(m => true);
            result.Result.Count().Should().Be(3);
        }
    }
}
