using CoreX.Domain.Validation;

namespace CoreX.Domain.Entities
{
    public sealed class Product : Base
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }

        public Product(
            int id,
            string name,
            string description,
            decimal price,
            int stock,
            string image
            )
        {
            DomainExceptionValidation.When(id < 0, "Valor inválido de id");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(
            string name,
            string description,
            decimal price,
            int stock,
            string image
            )
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(
            int id,
            string name,
            string description,
            decimal price,
            int stock,
            string image,
            int categoryId
            )
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(
            string name,
            string description,
            decimal price,
            int stock,
            string image
            )
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido, Nome deve ser preenchido!!");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido, Nome deve ter no mínimo 3 caracteres!!");

            DomainExceptionValidation.When(name.Length > 50,
                "Nome inválido, Nome não deve passar de 50 caracteres!!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválido, Descrição deve ser preenchido!!");

            DomainExceptionValidation.When(description.Length < 5,
                "Descrição inválido, Descrição deve ter no mínimo 5 caracteres!!");

            DomainExceptionValidation.When(price < 0, "Preço com valor inválido!!!");

            DomainExceptionValidation.When(stock < 0, "Estoque com valor inválido!!!");

            DomainExceptionValidation.When(image.Length > 250,
                "Imagem inválido, O nome da imagem não deve passar de 250 caracteres!!");

            Name = name;  
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
