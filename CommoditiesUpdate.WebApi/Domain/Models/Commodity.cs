using CSharpFunctionalExtensions;

namespace Commodities.WebApi.Domain.Models
{
    public class Commodity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public decimal Currency { get; set; }

        public Commodity() { }

        public Commodity(int code, DateOnly date, decimal price, string name)
        {
            Code = code;
            Date = date;
            Currency = price;
            Name = name;
        }

        public static Result<Commodity> Create(int code, DateOnly date, decimal currency, string name)
        {
            if (string.IsNullOrEmpty(code.ToString()))
                return Result.Failure<Commodity>("Invalid commodity code");

            if (string.IsNullOrEmpty(date.ToString()))
                return Result.Failure<Commodity>("Invalid date for creating commodity");

            if (string.IsNullOrEmpty(currency.ToString()) || currency == 0)
                return Result.Failure<Commodity>("Invalid or zero zurrency for commodity");

            return Result.Success(new Commodity(code, date, currency, name));
        }
    }
}
