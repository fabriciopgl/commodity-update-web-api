using CSharpFunctionalExtensions;

namespace CommoditiesUpdate.WebApi.Domain
{
    public class Aluminium
    {
        public int Code { get; set; }
        public DateOnly Date { get; set; }
        public decimal Price { get; set; }

        public Aluminium() { }

        public Aluminium(int code, DateOnly date, decimal price)
        {
            Code = code;
            Date = date;
            Price = price;
        }

        public static Result<Aluminium> Create(int code, DateOnly date, decimal price)
        {
            if (string.IsNullOrEmpty(code.ToString()))
                return Result.Failure<Aluminium>("Código para inclusão de cotação do alumínio inválido");
            if (string.IsNullOrEmpty(date.ToString()))
                return Result.Failure<Aluminium>("Data para inclusão de cotação do alumínio inválida");

            var aluminium = new Aluminium(code, date, price);

            return aluminium;
        }
    }

}