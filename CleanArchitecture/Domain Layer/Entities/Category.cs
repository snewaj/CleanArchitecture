namespace CleanArchitecture.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private readonly List<Product> _products = new();

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
            Name = name;
        }

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _products.Add(product);
        }
    }
}
