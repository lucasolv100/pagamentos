namespace Payments.Domain.Entities
{
    public class Account : Base
    {
        public Account(string name, string document, bool isLegalPerson)
        {
            Name = name;
            Document = document;
            IsLegalPerson = isLegalPerson;
        }

        private Account()
        {
            
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public bool IsLegalPerson { get; private set; }
        
    }
}