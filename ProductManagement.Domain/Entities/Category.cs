namespace ProductManagement.Domain.Entities;

public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<Product> Products { get; set; }  

}
