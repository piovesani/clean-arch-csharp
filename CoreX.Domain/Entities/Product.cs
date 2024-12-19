using CoreX.Domain.Entities;
using CoreX.Domain.Validation;

public sealed class Product : Base
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Product(
        string name, 
        string description, 
        decimal price, 
        int stock, 
        string image)
    {
        ValidateDomain(name, description, price, stock, image);
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public Product(
        int id, 
        string name, 
        string description, 
        decimal price, 
        int stock, 
        string image) : this(name, description, price, stock, image)
    {
        DomainExceptionValidation.When(
            id < 0, "Id não pode ser negativo.");
        Id = id;
    }

    public void Update(
        string name, 
        string description, 
        decimal price, 
        int stock, 
        string image, 
        int categoryId
        )
    {
        ValidateDomain(name, description, price, stock, image);
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
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
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateStock(stock);
        ValidateImage(image);
    }

    private void ValidateName(string name)
    {
        DomainExceptionValidation.When(
            string.IsNullOrWhiteSpace(name), 
            "Nome não pode ser vazio ou nulo."
            );

        DomainExceptionValidation.When(
            name.Length < 3, 
            "Nome deve ter no mínimo 3 caracteres."
            );

        DomainExceptionValidation.When(
            name.Length > 50, 
            "Nome não pode exceder 50 caracteres."
            );
    }

    private void ValidateDescription(string description)
    {
        DomainExceptionValidation.When(
            string.IsNullOrWhiteSpace(description), 
            "Descrição não pode ser vazia ou nula."
            );

        DomainExceptionValidation.When(
            description.Length < 5, 
            "Descrição deve ter no mínimo 5 caracteres."
            );
    }

    private void ValidatePrice(decimal price)
    {
        DomainExceptionValidation.When(
            price < 0, "Preço não pode ser negativo.");
    }

    private void ValidateStock(int stock)
    {
        DomainExceptionValidation.When(
            stock < 0, "Estoque não pode ser negativo.");
    }

    private void ValidateImage(string image)
    {
        DomainExceptionValidation.When(
            image.Length > 250, 
            "O nome da imagem não pode exceder 250 caracteres."
            );
    }
}