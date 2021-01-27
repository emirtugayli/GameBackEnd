using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class UserManager
    {
        public List<User> users = new List<User> { };
        public void Add(User user)
        {
            users.Add(user);
            Console.WriteLine($"Sevgili {user.FirstName},Uyeliginiz basariyla olusturulmustur.");
        }


        public void Update(User user)
        {
            Console.WriteLine("Yeni kullanici adinizi ekrana giriniz...");
            string newNickName = Console.ReadLine();
            user.NickName = newNickName;
            Console.WriteLine($"Kullanici adiniz basariyla degistirildi , Yeni Kullanici Adiniz : {user.NickName}");
        }

        public void Delete(User user)
        {
            users.Remove(user);
            Console.WriteLine($"{user.NickName} isimli kullanici kayitlarimizdan silinmistir . Kendine iyi bak !");
        }

        public void GetAll()
        {
            Console.WriteLine("Kullanicilar Ekrana Yazdiriliyor...");
            Console.WriteLine("..........");
            foreach (var user in users)
            {

                Console.WriteLine($"Isim : {user.FirstName}");
                Console.WriteLine($"Soyisim : {user.LastName}");
                Console.WriteLine($"Kullanici Adi : {user.NickName}");
                Console.WriteLine($"Dogum Yili : {user.BirthYear}");
                Console.WriteLine($"Tc No : {user.NationalityId}");
                Console.WriteLine($"Id : #{user.Id}");
                Console.WriteLine("////////////////////");
            }
        }
    }
}
