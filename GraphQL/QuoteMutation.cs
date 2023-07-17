using GraphQL;
using GraphQL.Types;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Entities;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL;

public class QuoteMutation : ObjectGraphType
{
    public QuoteMutation(QuoteRepository quoteRepository)
    {
        Field<QuoteType>("createQuote",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<QuoteInputType>> { Name = "quote" }),
                resolve: context =>
                {
                    var quote = context.GetArgument<Quote>("quote");
                    return quoteRepository.AddQuote(quote);
                });

        Field<QuoteType>("updateQuote",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<QuoteInputType>> { Name = "quote" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "quoteId" }),
                resolve: context =>
                {
                    var quote = context.GetArgument<Quote>("quote");
                    var quoteId = context.GetArgument<int>("quoteId");

                    quote.Id = quoteId;

                    return quoteRepository.UpdateQuote(quote);
                });
    }
}