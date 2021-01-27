using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class InterfaceManager
    {
        GameManager gameManager = new GameManager();
        BlackFridayCampaign bfCampaign = new BlackFridayCampaign();
        WinterCampaign wtCampaign = new WinterCampaign();
        UserManager userManager = new UserManager();
        UserServices userServices = new UserServices();
        User user = new User();

        public void StartScreen()
        {
            Console.WriteLine("============================================================== \n Yapmak Istediginiz Islemi Seciniz ; 1 - Giris Yap 2 - Kayit Ol \n==============================================================");
            int islem = Convert.ToInt32(Console.ReadLine());
            UserServices userService = new UserServices();
            if (islem == 1)
            {
                userService.LogIn();
            }
            else if (islem == 2)
            {
                userService.SignUp();
            }
            else
            {
                Console.WriteLine("Hatali giris yaptiniz lutfen 1'i ya da 2'yi tuslayiniz");
            }

        }
        public void GetGame()
        {
            gameManager.GetAll();
            try
            {
                int getId = Convert.ToInt32(Console.ReadLine());
                foreach (var game in gameManager.games)
                {
                    if (getId == game.Id && user.Money >= game.Price)
                    {
                        Console.WriteLine("Oyun basariyla kutuphanenize eklenmistir!");
                        user.Money = user.Money - game.Price;
                        Console.WriteLine($"Guncel Bakiyeniz :{user.Money}");
                        Console.ReadLine(); 
                    }
                    else
                    {
                        Console.WriteLine("Lutfen tekrar deneyiniz!");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Lutfen ID giriniz");
            }
           

        }
        public void GetSaleList()
        {
            var SalesList = wtCampaign.SaleWinterList.Concat(bfCampaign.BfGamesList).ToList();
            Console.WriteLine("Indirimdeki Urunler Listeleniyor... \n--------------------------");
            foreach (var game in SalesList)
            {

                Console.WriteLine($"Id = #{game.Id}");
                Console.WriteLine($"Oyun Ismi : {game.Name}");
                Console.WriteLine($"Indirimli Fiyati : {game.Price}");
                Console.WriteLine($"Yayinci : {game.Publisher}");
                Console.WriteLine(game.Description);
                Console.WriteLine("--------------------------");
            }
            Console.ReadLine();

        }
        public void GetUserPanel()
        {
            try
            {
                Console.WriteLine("Kullanici Yonetim Paneli'ne Hosgeldiniz !");
                Console.WriteLine("Yapmak istediginiz islemi seciniz ; 1-Nickname degistir 2-Uyeligimi Sil ");
                int GetIslem = Convert.ToInt32(Console.ReadKey());
                if (GetIslem == 1)
                {
                    userManager.Update(user);
                }
                else if (GetIslem == 2)
                {
                    userManager.Delete(user);
                }
                else
                {
                    Console.WriteLine("Sadece yukaridaki rakamlarla islem belirtebilirsiniz !");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Sadece yukaridaki rakamlarla islem belirtebilirsiniz !");
            }
           
        }
        public void GetAdminPanel()
        {
            Console.WriteLine("Yonetici Paneline Hosgeldiniz !");
            Console.WriteLine("Yapmak Istediginiz Islemi Seciniz ; \n 1-Oyun Ekle 2-Oyun Sil 3-Oyun Bilgisi Guncelle \n 4-Kampanyaya Oyun Ekle 5-Kampanyadan Oyun Sil 6-Kampanyayi Baslat 7-Kampanyayi Durdur 8-Kampanya Bilgisi Guncelle ");
            int GetIslem = Convert.ToInt32(Console.ReadKey());
            if (GetIslem == 1)
            {
                try
                {
                    var tempGameId = gameManager.games.Count + 1;
                    Console.WriteLine("Oyun Ismi : ");
                    var tempGameName = Console.ReadLine();
                    Console.WriteLine("Oyun Ucreti : ");
                    var tempGamePrice = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Oyun Aciklamasi : ");
                    var tempGameDescription = Console.ReadLine();
                    Console.WriteLine("Oyunu Yayinlayan : ");
                    var tempGamePublisher = Console.ReadLine();

                    Game newGame = new Game();
                    newGame.Id = tempGameId;
                    newGame.Name = tempGameName;
                    newGame.Price = tempGamePrice;
                    newGame.Publisher = tempGamePublisher;
                    newGame.Description = tempGamePublisher;

                    gameManager.games.Add(newGame);
                    Console.WriteLine("Oyun basariyla magazaya eklenmistir!");

                }
                catch (Exception)
                {
                    Console.WriteLine("Lutfen bilgileri istenilen formda giriniz");
                }

            }
            else if (GetIslem == 2)
            {
                Console.WriteLine("Silmek istediginiz oyunun ID'sini giriniz \n ----------------------------");
                gameManager.GetAll();
                int GetId = Convert.ToInt32(Console.ReadKey());
                for (int i = 0; i < gameManager.games.Count(); i++)
                {
                    if (GetId == gameManager.games[i].Id)
                    {
                        gameManager.Delete(gameManager.games[i]);
                    }
                    else
                    {
                        Console.WriteLine("Yanlis Oyun ID'si girisi yapilmistir");
                    }
                }
            }
            else if (GetIslem == 3)
            {
                Console.WriteLine("Guncellemek Istediginiz Oyunun ID'sini giriniz.");
                var GetId = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < gameManager.games.Count(); i++)
                {
                    if (GetId == gameManager.games[i].Id)
                    {
                        var game = gameManager.games[i];
                        gameManager.Update(game);
                    }
                    else
                    {
                        Console.WriteLine("Yanlis Id Girisi Yapilmistir!");
                    }
                }
            }
            else if (GetIslem == 4)
            {
                Console.WriteLine("1-Winter Sale 2-Black Friday Sale");
                Console.WriteLine("Hangi Kampanyaya Oyun Eklemek Istiyorsunuz ?");
                var GetId = Convert.ToInt32(Console.ReadLine());
                if (GetId == 1)
                {
                    Console.Write("Eklemek istediginiz oyunun ID'sini yaziniz :");
                    gameManager.GetAll();
                    var GameID = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < gameManager.games.Count(); i++)
                    {
                        if (GameID == gameManager.games[i].Id)
                        {
                            wtCampaign.SaleWinterList.Add(gameManager.games[i]);
                            Console.WriteLine("Istenen oyun basariyla listeye eklenmistir !");
                        }
                        else
                        {
                            Console.WriteLine("Yanlis oyun ID'si girilmistir!");
                        }
                    }
                }
                else if (GetId == 2)
                {
                    Console.Write("Eklemek istediginiz oyunun ID'sini yaziniz :");
                    gameManager.GetAll();
                    var GameID = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < gameManager.games.Count(); i++)
                    {
                        if (GameID == gameManager.games[i].Id)
                        {
                            bfCampaign.Delete(gameManager.games[i]);

                        }
                        else
                        {
                            Console.WriteLine("Yanlis oyun ID'si girilmistir!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Yanlis islem secimi yaptiniz !");
                }

            }
            else if (GetIslem == 5)
            {
                Console.WriteLine("1-Winter Sale 2-Black Friday Sale");
                Console.WriteLine("Hangi Kampanyaya Oyun Silmek Istiyorsunuz ?");
                var CampaignId = Convert.ToInt32(Console.ReadLine());
                if (CampaignId == 1)
                {
                    Console.Write("Eklemek istediginiz oyunun ID'sini yaziniz :");
                    gameManager.GetAll();
                    var GameID = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < gameManager.games.Count(); i++)
                    {
                        if (GameID == gameManager.games[i].Id)
                        {
                            wtCampaign.Add(gameManager.games[i]);

                        }
                        else
                        {
                            Console.WriteLine("Yanlis oyun ID'si girilmistir!");
                        }
                    }
                }
                else if (CampaignId == 2)
                {
                    Console.Write("Eklemek istediginiz oyunun ID'sini yaziniz :");
                    gameManager.GetAll();
                    var GameID = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < gameManager.games.Count(); i++)
                    {
                        if (GameID == gameManager.games[i].Id)
                        {
                            wtCampaign.Delete(gameManager.games[i]);

                        }
                        else
                        {
                            Console.WriteLine("Yanlis oyun ID'si girilmistir!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Yanlis islem secimi yaptiniz !");
                }
            }
            else if (GetIslem == 6)
            {
                Console.WriteLine("1-Winter Sale 2-Black Friday Sale");
                Console.WriteLine("Hangi Kampanyaya Aktif Etmek Istiyorsunuz ?");
                var CampaignId = Convert.ToInt32(Console.ReadLine());
                if (CampaignId == 1)
                {
                    wtCampaign.Apply();
                }
                else if (CampaignId == 2) 
                {
                    bfCampaign.Apply();
                }
                else
                {
                    Console.WriteLine("Yanlis kampanya secimi yaptiniz !");
                }
            }
            else if (GetIslem == 7)
            {
                Console.WriteLine("1-Winter Sale 2-Black Friday Sale");
                Console.WriteLine("Hangi Kampanyaya Durdurmak Istiyorsunuz ?");
                var CampaignId = Convert.ToInt32(Console.ReadLine());
                if (CampaignId == 1)
                {
                    wtCampaign.Stop();
                }
                else if (CampaignId == 2)
                {
                    bfCampaign.Stop();
                }
                else
                {
                    Console.WriteLine("Yanlis kampanya secimi yaptiniz !");
                }
            }
            else if (GetIslem == 8)
            {
                Console.WriteLine("1-Winter Sale 2-Black Friday Sale");
                Console.WriteLine("Hangi Kampanyayi Guncellemek Istiyorsunuz ?");
                var CampaignId = Convert.ToInt32(Console.ReadLine());
                if (CampaignId == 1)
                {
                    wtCampaign.Update();
                }
                else if (CampaignId == 2)
                {
                    bfCampaign.Update();
                }
                else
                {
                    Console.WriteLine("Yanlis kampanya secimi yaptiniz !");
                }
            }
            else
            {
                Console.WriteLine("Yanlis islem girisi yaptiniz !");
            }


        }
    }
}
