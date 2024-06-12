using Flunt.Validations;
using Social.Shared.ValueObjects;

namespace Social.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(number, "documentNumber", "Documento é obrigatório")
                .HasLen(number, 11, "documentNumber", "O documento deve conter 11 dígitos")
                );

            Number = number;
        }

        public string Number { get; private set; }
    }
}
