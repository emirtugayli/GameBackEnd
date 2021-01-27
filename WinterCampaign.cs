using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    class WinterCampaign : ICampaignManager
    {
 
        private double discountPercent = 0.40;
        public List<Game> SaleWinterList = new List<Game> { };
        public bool SaleSituation = false; 

        public void Add(Game game)
        {
            SaleWinterList.Add(game);
            Console.WriteLine("Istenen oyun indirim listesine eklendi");
        }

        public void Apply()
        {
            foreach (var game in SaleWinterList)
            {
                game.Price = game.Price - (game.Price * discountPercent);
            }
            SaleSituation = true;
            Console.WriteLine("Kis indirimleri uygulanmaya baslanmistir");
        }

        public void Delete(Game game)
        {
            SaleWinterList.Remove(game);
            Console.WriteLine("Oyun Kis Indirim Listesinden Kaldirilmistir.");
        }

        public void Stop()
        {
            foreach (var game in SaleWinterList)
            {
                game.Price = game.Price + (game.Price * discountPercent);
            }
            SaleSituation = false;
            Console.WriteLine("Kis indirimleri durdurulmustur");
        }

        public void Update()
        {
            try
            {
                Console.Write("Yeni indirim oranini yaziniz :");
                double newDiscountPercent = Convert.ToDouble(Console.ReadLine());
                discountPercent = newDiscountPercent;
            }
            catch (Exception)
            {
                Console.WriteLine("Lutfen indirim oranini ONDALIK seklinde yaziniz !");
            }
           
        }
    }
}
