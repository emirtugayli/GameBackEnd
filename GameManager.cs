using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class GameManager 
    {
        public List<Game> games = new List<Game> {};
        public void Add(Game game)
        {
            games.Add(game);
            Console.WriteLine($"'{game.Name}' markete eklenmistir.");
        }
        public void Delete(Game game)
        {
            games.Remove(game);
            Console.WriteLine($"'{game.Name}' marketten kaldirilmistir.");
        }

        public void Update(Game game)
        {
            Console.WriteLine("Guncellemek istediginiz bilgiyi seciniz...");
            Console.WriteLine("1-Oyun Fiyati 2-Oyun Aciklamasi 3-Oyun Ismi");
            try
            {
                int islem = Convert.ToInt32(Console.ReadLine());
                if (islem == 1)
                {
                    Console.WriteLine("Urunun yeni ismini giriniz... \n");
                    string newName = Console.ReadLine();
                    game.Name = newName;
                    Console.WriteLine($"Urunun yeni ismi '{game.Name}' olarak guncellenmistir.");
                }
                else if (islem == 2)
                {
                    Console.WriteLine("Urunun yeni aciklamasini yaziniz... \n");
                    string newDesc = Console.ReadLine();
                    game.Description = newDesc;
                    Console.WriteLine("Urunun yeni aciklamasi assagidadir. \n" + game.Description);
                }
                else if (islem == 3)
                {
                    Console.WriteLine("Urunun yeni ismini yaziniz... \n");
                    string newName = Console.ReadLine();
                    game.Name = newName;
                    Console.WriteLine($"Urunun yeni ismi '{game.Name}' ");
                }
                else
                {
                    Console.WriteLine("Geçersiz bir sayi girdiniz.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Lutfen bir sayi girisi yapiniz");
            }

        }

        public void GetAll()
        {
            foreach (var game in games)
            {
                Console.WriteLine($"Id = #{game.Id}");
                Console.WriteLine($"Oyun Ismi : {game.Name}");
                Console.WriteLine($"Fiyati : {game.Price}");
                Console.WriteLine($"Yayinci : {game.Publisher}");
                Console.WriteLine(game.Description);
                Console.WriteLine("////////////////////");
            }
        }


    }



}
