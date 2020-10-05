using System;
using System.Threading.Tasks;
using CloudAcademy.Bitcoin;

namespace CloudAcademy.Bitcoin.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var converter = new ConverterSvc();

            try{
                //var version = converter.GetVersion();
                var amountUSD = await converter.ConvertBitcoins("USD", 5);
                var amountNZD = await converter.ConvertBitcoins("NZD", 3);

                //Console.WriteLine("Version: {0}", version);
                Console.WriteLine("USD : {0}", amountUSD);
                Console.WriteLine("NZD : {0}", amountNZD);
            }
            catch {
                Console.WriteLine("Error converting...");
            }
        }
    }
}
