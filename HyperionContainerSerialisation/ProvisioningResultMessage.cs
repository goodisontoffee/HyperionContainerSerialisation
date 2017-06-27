namespace HyperionContainerSerialisation
{
    public class ProvisioningResultMessage<T>
    {
        private readonly T result;

        public T Result => result;

        public ProvisioningResultMessage(T result)
        {
            this.result = result;
        }
    }
}