namespace HyperionContainerSerialisation
{
    public interface IContainer<out T>
    {
        T Value { get; }

        TrustLevel TrustLevel { get; }
    }
}