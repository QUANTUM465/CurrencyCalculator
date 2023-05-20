namespace PostDataResponce
{
    public class Currency
    {
        private int currencyCodeA;
        private int currencyCodeB;
        private long date;
        private float rateBuy;
        private float rateCross;
        private float rateSell;
 
        public Currency(int currencyCodeA, int currencyCodeB, long date, float rateSell, float rateBuy, float rateCross)
        {
            CurrencyCodeA = currencyCodeA;
            CurrencyCodeB = currencyCodeB;
            Date = date;
            RateSell = rateSell;
            RateBuy = rateBuy;
            RateCross = rateCross;
        }
        public int CurrencyCodeA { get => currencyCodeA; set => currencyCodeA = value; }
        public int CurrencyCodeB { get => currencyCodeB; set => currencyCodeB = value; }
        public long Date { get => date; set => date = value; }
        public float RateSell { get => rateSell; set => rateSell = value; }
        public float RateBuy { get => rateBuy; set => rateBuy = value; }
        public float RateCross { get => rateCross; set => rateCross = value; }
        public override string ToString() 
        {
            string text =
                 $"Код валюти рахунку відповідно ISO 4217: {currencyCodeA}" + '\n'+
                 $"Код валюти рахунку відповідно ISO 4217: {currencyCodeB}" + '\n' +
                 $"Час курсу в секундах в форматі Unix time: {date}" + '\n' +
                 $"Курс продажу: {rateSell}" + '\n' +
                 $"Курс покупки: {rateBuy}" + '\n' +
                 $"Середній курс: {rateCross}";
            return text;
        }
    }

}
