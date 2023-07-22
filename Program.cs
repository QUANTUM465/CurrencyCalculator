using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using PostDataResponce;
using System.IO;


namespace ConsoleСurrencyCalculator
{

    internal class Program
    {

        public static List<Currency> currencies = GetCurrency();
        /// <summary>
        /// The Dictionary that contains code of currency and that meaning 
        /// </summary>
        public static Dictionary<int, String> currencyName = new Dictionary<int, String>()
        {
            {980, "Українська гривня" },
            {840, "Долар США" },
            {978, "Євро" },
            {826, "Фунти Стерлінгів" },
            {392, "Японська єна" },
            {756, "Швейцарський франк" },
            {156, "Китайський юань" },
            {643, "Москальський рубль" },
            {784, "Дірхам ОАЕ" },
            {971, "Афганський афгані" },
            {8, "Албанський лек" },
            {51, "Вірменський драм" },
            {973, "Ангольська кванза" },
            {32, "Аргентинський песо" },
            {36, "Австралійський долар" },
            {944, "Азербайджанський манат" },
            {50, "Бангладешська така" },
            {975, "Болгарський лев" },
            {48, "Бахрейнський динар" },
            {108, "Бурундійський франк" },
            {96, "Брунейський долар" },
            {68, "Болівійський болівіано" },
            {986, "Бразильський реал" },
            {72, "Ботсванська пула" },
            {933, "Білоруський рубль" },
            {124, "Канадський долар" },
            {976, "Конголезький франк" },
            {152, "Чилійський песо" },
            {170, "Колумбійський песо" },
            {188, "Костариканський колон" },
            {192, "Кубинський песо" },
            {203, "Чеська крона" },
            {262, "Джибутійський франк" },
            {208, "Датська крона" },
            {12, "Алжирський динар" },
            {818, "Єгипетський фунт" },
            {230, "Ефіопський бір" },
            {981, "Грузинський ларі" },
            {936, "Ганський седи" },
            {270, "Гамбійський далас" },
            {324, "Гвінейський франк" },
            {344, "Гонконгський долар" },
            {191, "Хорватська куна" },
            {348, "Угорський форинт" },
            {360, "Індонезійська рупія" },
            {376, "Ізраїльський шекель" },
            {356, "Індійська рупія" },
            {368, "Іракський динар" },
            {364, "Іранський ріал" },
            {352, "Ісландська крона" },
            {400, "Йорданський динар" },
            {404, "Кенійський шилінг" },
            {417, "Киргизький сом" },
            {116, "Камбоджійський рієль" },
            {408, "Північно-корейська вона (КНДР)" },
            {410, "Південно-корейська вона (Корея)" },
            {414, "Кувейтський динар" },
            {398, "Казахстанський тенге" },
            {418, "Лаоський кіп" },
            {422, "Ліванський фунт" },
            {144, "Шрі-ланкійська рупія" },
            {434, "Лівійський динар" },
            {504, "Марокканський дирхам" },
            {498, "Молдовський лей" },
            {969, "Малагасійський аріарі" },
            {807, "Македонський денар" },
            {496, "Монгольський тугрик" },
            {478, "Мавританська вугія" },
            {480, "Маврикійська рупія" },
            {462, "Мальдівська руфія" },
            {454, "Малавійська квача" },
            {484, "Мексиканські песо" },
            {458, "Малайзійські ринггіті" },
            {943, "Мозамбіцький метикал" },
            {516, "Намібійський долар" },
            {566, "Нігерійська найра" },
            {558, "Нікарагуанська Кордоба" },
            {578, "Норвезькі крони" },
            {524, "Непальська рупія" },
            {554, "Новозеландські долари" },
            {512, "Оманський ріал" },
            {604, "Перуанська соль" },
            {608, "Філіппінський песо" },
            {586, "Пакистанська рупія" },
            {985, "Польські злоті" },
            {600, "Парагвайський гуарані" },
            {634, "Катарський ріал" },
            {946, "Новий румунський лей" },
            {941, "Сербський динар" },
            {682, "Саудівський ріал" },
            {690, "Сейшельська рупія" },
            {938, "Суданський фунт" },
            {752, "Шведські крони" },
            {702, "Сингапурські долари" },
            {694, "Сьєрра-Леоне Леоне" },
            {706, "Сомалійський шилінг" },
            {968, "Суринамський долар" },
            {760, "Сирійські фунти" },
            {748, "Свазілендський лілангені" },
            {764, "Тайський бат" },
            {972, "Сомоні таджицькі сомоні" },
            {795, "Туркменські манати" },
            {788, "Туніський динар" },
            {949, "Нова турецька ліра" },
            {901, "Тайванський долар" },
            {834, "Танзанійський шилінг" },
            {800, "Угандійські шилінги" },
            {858, "Уругвайський песо" },
            {860, "Узбецький сум" },
            {937, "Венесуельський болівар" },
            {704, "В'єтнамські донги" },
            {950, "Франки КФА (Центральна Африка)" },
            {960, "SPZ" },
            {952, "Франки КФА (Західна Африка)" },
            {886, "Єменський ріал" },
            {710, "Південноафриканський ранд" },
            {894, "Замбійська квача" }
        };


        /// <summary>
        /// This method create List<String> that contains name of currencies
        /// </summary>
        /// <returns>List of objects type String</returns>
        public static List<String> ListCurrencies()
        {
            List<String> values = new List<String>();
            foreach (Currency item in currencies)
            {
                values.Add(currencyName[item.CurrencyCodeA]);
            }
            values.Add("Українська гривня");
            values = values.Distinct().ToList();
            return values;
        }

        /// <summary>
        /// This method search the value beetwen two currencies. 
        /// Accept two parameters, codeA is a key of currency from first listbox, codeB is a key of currency from second listbox
        /// </summary>
        /// <param name="codeA"></param>
        /// <param name="codeB"></param>
        /// <returns>
        /// Return exchange rate of two currencies, if there is no data return 0
        /// </returns>
        public static float FindCurrency(int codeA, int codeB)
        {
            Currency currency = null;
            try
            {
                foreach (Currency item in currencies)
                {
                    if (item.RateCross == 0 && item.RateBuy != 0 && item.RateSell != 0)
                    {
                        item.RateCross = (item.RateBuy + item.RateSell) / 2;
                    }
                    else
                    {
                    if (item.CurrencyCodeA == codeA && item.CurrencyCodeB == codeB)
                    {
                            return item.RateCross;
                    }
                    else
                    {
                            foreach (Currency element in currencies)
                        {
                                if (item.CurrencyCodeA == codeA && element.CurrencyCodeB == 980)
                                {
                            float temporaryRateCross = item.RateCross;
                                    if (element.CurrencyCodeA == codeB && element.CurrencyCodeB == 980)
                                    {
                                        float result = temporaryRateCross / element.RateCross;
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
                throw;
            }
            //HACK:: For this method null is default value to return
        }

        //UNDONE:: Server throw exception if requestі is too often
        //TODO:: Timer or Dispatcher to do request every 5 min

        /// <summary>
        /// Get and deserialaize the data from JSON.
        /// </summary>
        /// <returns>
        ///  List of objects type Currency
        /// </returns>
        public static List<Currency> GetCurrency()
        {
            var url = "https://api.monobank.ua/bank/currency";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result; // get response by address
            var json = response.Content.ReadAsStringAsync().Result;

            var currencies = JsonConvert.DeserializeObject<List<Currency>>(json); // Parsing String and add data to List
            return currencies;
        }

    }
}
