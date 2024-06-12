using Flunt.Validations;
using Social.Shared.ValueObjects;

namespace Social.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastaName)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(firstName, "firstname", "O nome é obrigatório")
                .HasMinLen(firstName, 3, "firstname", "Nome deve conter no mínimo 3 caractéres")
                .HasMaxLen(firstName, 50, "firstname", "Nome deve conter no máximo 50 caractéres")
                .IsNotNullOrEmpty(lastaName, "lastname", "O sobrenome é obrigatório")
                .HasMinLen(lastaName, 3, "lastname", "Sobrenome deve conter no mínimo 3 caractéres")
                .HasMaxLen(lastaName, 50, "lastname", "Sobrenome deve conter no máximo 50 caractéres")
                );

            FirstName = firstName;
            LastaName = lastaName;
        }

        public string FirstName { get; private set; }
        public string LastaName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastaName}";
        }
    }
}
