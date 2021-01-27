using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    class BlackFridayCampaign : ICampaignManager
    {
        public List<Game> BfGamesList = new List<Game> { };
        private double discountPercent = 0.20;
        public bool SaleSituation = false;

        public void Add(Game game)
        {
            BfGamesList.Add(game);
            Console.WriteLine($"{game.Name} black friday indirimleri listesine eklendi.");
        }

        public void Apply()
        {
            foreach (var game in BfGamesList)
            {
                game.Price = game.Price - (game.Price * discountPercent);
                
            }
            SaleSituation = true;
            Console.WriteLine("Black Friday indirimleri basariyla uygulanmistir.");
        }

        public void Stop()
        {
            foreach (var game in BfGamesList)
            {
                game.Price = game.Price + (game.Price * discountPercent);
            }
            SaleSituation = false;
            Console.WriteLine("Black Friday indirimleri bitirilmistir.");
        }

        public void Delete(Game game)
        {
            BfGamesList.Remove(game);
            Console.WriteLine($"{game.Name} black friday indirimleri listesinden kaldirildi");
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
