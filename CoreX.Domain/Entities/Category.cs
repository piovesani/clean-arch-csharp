using System.Xml.Linq;
using CoreX.Domain.Validation;

namespace CoreX.Domain.Entities
{
    public sealed class Category : Base
    {
        public string? Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor inválido de id");
            Id = id;
            ValidateDomain(name);
        }

        public void UpdateName(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Product>? Products { get; private set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido, Nome deve ser preenchido!!");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido, Nome deve ter no mínimo 3 caracteres!!");

            DomainExceptionValidation.When(name.Length > 50,
                "Nome inválido, Nome não deve passar de 50 caracteres!!");

            Name = name;
        }
    }
}
