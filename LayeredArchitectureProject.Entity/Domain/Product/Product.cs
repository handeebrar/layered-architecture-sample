namespace LayeredArchitectureProject.Entity.Domain.Product
{
    public class Product : BaseEntity
    {
        public string DisplayName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
