using CoreX.Domain.Entities;
using CoreX.Domain.Validation;

public sealed class Category : Base
{
    private readonly List<Product> _products = new();

    public string? Name { get; private set; }
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Category(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public Category(int id, string name) : this(name)
    {
        DomainExceptionValidation.When(
            id < 0, "Id não pode ser negativo.");
        Id = id;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void AddProduct(Product product)
    {
        DomainExceptionValidation.When(
            product == null, "Produto não pode ser nulo.");

        if (product != null)
        {
            _products.Add(product);
        }
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
}