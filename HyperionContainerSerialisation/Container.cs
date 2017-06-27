using System.Security;

namespace HyperionContainerSerialisation
{
    public class Container<T> : IContainer<T>
    {
        private readonly T value;
        private readonly TrustLevel trustLevel;

        public T Value => value;

        public TrustLevel TrustLevel => trustLevel;

        public Container(T value, TrustLevel trustLevel)
        {
            this.value = value;
            this.trustLevel = trustLevel;
        }
    }
}