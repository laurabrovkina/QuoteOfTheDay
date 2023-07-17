using Microsoft.EntityFrameworkCore;
using QuoteOfTheDay.Entities;

namespace QuoteOfTheDay.Data;

public class QuoteRepository
{
    private readonly QuoteOfTheDayDbContext _dbContext;

    public QuoteRepository(QuoteOfTheDayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Quote> GetAll()
    {
        return _dbContext.Quotes
            .Include(q => q.Category);
    }

    public Quote GetById(int id) => _dbContext.Quotes.Include(q => q.Category)
                                                     .SingleOrDefault(q => q.Id == id);

    public Quote AddQuote(Quote quote)
    {
        _dbContext.Add(quote);
        _dbContext.SaveChanges();

        _dbContext.Entry(quote)
            .Reference(q => q.Category)
            .Load();

        return quote;
    }

    public Quote UpdateQuote(Quote quote)
    {
        _dbContext.Attach(quote);
        _dbContext.Entry(quote).State = EntityState.Modified;
        _dbContext.SaveChanges();

        _dbContext.Entry(quote)
            .Reference(q => q.Category)
            .Load();

        return quote;
    }
}