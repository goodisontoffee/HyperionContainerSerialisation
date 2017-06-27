namespace HyperionContainerSerialisation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    using Akka.Actor;

    public class ProvisioningActor : ReceiveActor
    {
        private readonly Name bob;
        private readonly Name jane;
        private readonly Name fred;
        private readonly Name sandra;

        public ProvisioningActor()
        {
            bob = new Name(new Container<string>("Mr", TrustLevel.Partial), new Container<string>("Bob", TrustLevel.Partial), new Container<string>("Smith", TrustLevel.Suspicious));
            jane = new Name(new Container<string>("Mrs", TrustLevel.Suspicious), new Container<string>("Jane", TrustLevel.Suspicious), new Container<string>("Smith", TrustLevel.Suspicious));
            fred = new Name(new Container<string>("Master", TrustLevel.Fully), new Container<string>("Fred", TrustLevel.Fully), new Container<string>("Smith", TrustLevel.Fully));
            sandra = new Name(new Container<string>("Miss", TrustLevel.Partial), new Container<string>("Sandra", TrustLevel.Partial), new Container<string>("Smith", TrustLevel.Suspicious));

            Receive<NameRequestMessage>(m => ProvideNames(m));
            Receive<DateRequestMessage>(m => ProvideDates(m));
        }

        private void ProvideNames(NameRequestMessage message)
        {
            var names = new List<Name>
            {
                bob,
                jane,
                fred,
                sandra
            };

            var provisioningResultMessage = new ProvisioningResultMessage<IEnumerable<Name>>(names.ToImmutableArray());
            Sender.Tell(provisioningResultMessage);
        }

        private void ProvideDates(DateRequestMessage message)
        {
            var currentDate = DateTime.UtcNow.Date;

            var yesterday = new Container<DateTime?>(currentDate.AddDays(-1), TrustLevel.Fully);
            var today = new Container<DateTime?>(currentDate, TrustLevel.Fully);
            var tomorrow = new Container<DateTime?>(currentDate.AddDays(1), TrustLevel.Fully);

            var dates = new List<IContainer<DateTime?>>
            {
                yesterday,
                today,
                tomorrow
            };

            var provisioningResultMessage = new ProvisioningResultMessage<IEnumerable<IContainer<DateTime?>>>(dates.ToImmutableArray());
            Sender.Tell(provisioningResultMessage);
        }
    }
}
