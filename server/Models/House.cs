namespace greglist_dotnet.Models;

public class House
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Sqft { get; set; }
    public int? Bedrooms { get; set; }
    public double? Bathrooms { get; set; }
    public string ImgURL { get; set; }
    public string Description { get; set; }
    public int? Price { get; set; }
    public string CreatorId { get; set; }
}