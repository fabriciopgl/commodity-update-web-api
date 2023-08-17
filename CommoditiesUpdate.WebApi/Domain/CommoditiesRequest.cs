namespace CommoditiesUpdate.WebApi.Domain
{
    public class CommoditiesRequest
    {
        public DateTime Data { get; set; }
        public decimal Cobre { get; set; }
        public decimal Zinco { get; set; }
        public decimal Aluminio { get; set; }
        public decimal Chumbo { get; set; }
        public decimal Estanho { get; set; }
        public decimal Niquel { get; set; }
        public decimal Dolar { get; set; }

        public CommoditiesRequest(DateTime date, decimal cobre, decimal zinco, decimal aluminio, decimal chumbo, decimal estanho, decimal niquel, decimal dolar)
        {
            Data = date;
            Cobre = cobre;
            Zinco = zinco;
            Aluminio = aluminio;
            Chumbo = chumbo;
            Estanho = estanho;
            Niquel = niquel;
            Dolar = dolar;
        }

        public CommoditiesRequest(){}
    }

}