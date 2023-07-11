using GraphQL.Types;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL;

public class QuoteQuery : ObjectGraphType
{
    public QuoteQuery(QuoteRepository quoteRepository) => Field<ListGraphType<QuoteType>>(
            "quotes",
            resolve: context => quoteRepository.GetAll());
}