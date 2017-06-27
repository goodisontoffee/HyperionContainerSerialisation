namespace HyperionContainerSerialisation
{
    public class Name
    {
        private readonly IContainer<string> title;
        private readonly IContainer<string> givenName;
        private readonly IContainer<string> familyName;

        public IContainer<string> Title => title;

        public IContainer<string> GivenName => givenName;

        public IContainer<string> FamilyName => familyName;

        public Name(IContainer<string> title, IContainer<string> givenName, IContainer<string> familyName)
        {
            this.title = title;
            this.givenName = givenName;
            this.familyName = familyName;
        }
    }
}