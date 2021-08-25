namespace BaltaStoreMs.Order.Domain.ValueObjects
{
    public struct CreditCard
    {
        public CreditCard(string name, string number, string expiration, string cvv)
        {
            Name = name;
            Number = number;
            Expiration = expiration;
            Cvv = cvv;
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
    }
}