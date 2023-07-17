using GraphQL.Types;
using QuoteOfTheDay.Entities;

namespace QuoteOfTheDay.GraphQL.Types;

public class QuoteInputType : InputObjectGraphType<Quote>
{
    public QuoteInputType()
    {
        Name = "quoteInput";
        Field<NonNullGraphType<StringGraphType>>("author");
        Field<NonNullGraphType<StringGraphType>>("text");
        Field<NonNullGraphType<IntGraphType>>("categoryId");
    }
}