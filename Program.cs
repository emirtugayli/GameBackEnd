using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            User admin = new User();
            admin.FirstName = "Rahmi Emir";
            admin.LastName = "Tugayli";
            admin.NickName = "Caxko";
            admin.Password = "PASSword";
            admin.NationalityId = 43411295073;
            admin.Money = 12312312313131313;
            admin.UserType = 2;

            User user1 = new User();
            user1.NickName = "Thoea";
            user1.Password = "1234567";
            user1.FirstName = "Goktuğ";
            user1.LastName = "Günçe";
            user1.NationalityId = 66331295072;
            user1.Money = 100;
            user1.UserType = 1;

            User user2 = new User();
            user2.NickName = "Savur";
            user2.Password = "1234567";
            user2.FirstName = "Ozcan";
            user2.LastName = "Savur";
            user2.NationalityId = 13229821356;
            user2.Money = 100;
            user1.UserType = 1;

            Game game1 = new Game();
            game1.Id = 1;
            game1.Name = "Valorant";
            game1.Price = 99;
            game1.Publisher = "Riot Games";
            game1.Description = "Yilin FPS Oyunu";

            Game game2 = new Game();
            game2.Id = 2;
            game2.Name = "CS:GO";
            game2.Price = 300;
            game2.Publisher = "Valve";
            game2.Description = "Yilin 2. FPS Oyunu";

            Game game3 = new Game();
            game3.Id = 3;
            game3.Name = "Hitman";
            game3.Price = 240;
            game3.Publisher = "Bilinmiyor";
            game3.Description = "En iyi Ajan Oyunu";

            UserManager userManager = new UserManager();
            var users = userManager.users;
            UserServices userServices = new UserServices();
            GameManager gameManager = new GameManager();
            var games = gameManager.games;
            InterfaceManager interfaceManager = new InterfaceManager();
            interfaceManager.StartScreen();

            if (userServices.LogStatement==true)
            {
                if (userServices.UserModarateStatement == true)
                {
                    interfaceManager.GetAdminPanel();
                }
                else
                {
                    Console.WriteLine("Sisteme Hosgeldiniz ...");
                    Console.WriteLine("Yapmak istediginiz islemi tuslayiniz : 1 - Oyun Al 2-Indirimli Oyunlari Goster 3-Uyelik Yonetim Paneline Gir");
                    int icislem = Convert.ToInt32(Console.ReadLine());
                    if (icislem == 1)
                    {
                        interfaceManager.GetGame();
                    }
                    else if (icislem == 2)
                    {
                        interfaceManager.GetSaleList();
                    }
                    else if (icislem == 3)
                    {
                        interfaceManager.GetUserPanel();
                    }
                }
            }
            else
            {
                Console.WriteLine("Lutfen Giris Yapiniz !");
                interfaceManager.StartScreen();
            }

           
           



        }
    }
}
