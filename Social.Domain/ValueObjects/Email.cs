using Flunt.Validations;
using Social.Shared.ValueObjects;

namespace Social.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(address, "email", "Endereço de email é obrigatório")
                .IsEmail(address, "email", "Endereço de email inválido")
                );
            Address = address;
        }
    }
}
