namespace QuoteOfTheDay.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<Quote> Quotes { get; set; } = default!;
}
