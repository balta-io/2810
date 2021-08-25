namespace BaltaStoreMs.Order.Domain.Entities
{
    public class User
    {
        public User(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}