namespace CleanArchitecture.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; } // Derived property for summary info
    }
}

