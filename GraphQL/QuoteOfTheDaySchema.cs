using GraphQL.Types;

namespace QuoteOfTheDay.GraphQL;

public class QuoteOfTheDaySchema : Schema
{
    public QuoteOfTheDaySchema(IServiceProvider provider, QuoteQuery quoteQuery) : base(provider)
    {
        Query = quoteQuery;
    }
}