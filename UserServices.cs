using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class UserServices : UserManager
    {
        public bool LogStatement = false;
        public bool UserModarateStatement = false;
        public void LogIn()
        {
            Console.Write("Kullanici adinizi yaziniz: ");
            string susNickName = Console.ReadLine();
            Console.Write("Sifrenizi giriniz: ");
            string susPass = Console.ReadLine();
            foreach (var user in users)
            {
                if (susNickName == user.NickName && susPass == user.Password)
                {
                    LogStatement = true;
                    Console.WriteLine($"Girisiniz basariyla yapilmistir. \n Hosgeldiniz {user.FirstName},");
                    if (user.UserType==2)
                    {
                        UserModarateStatement = true;
                    }
                    else
                    {
                        UserModarateStatement = false;
                    }
                }
                else
                {
                    Console.WriteLine("Sifreniz ya da kullanici isminiz yanlis.");
                }
            }


        }

        public void SignUp()
        {
            Console.Write("Kullanici Adi : ");
            string tempNickName = Console.ReadLine();
            Console.Write("Sifre : ");
            string tempPass = Console.ReadLine();
            Console.Write("Isminiz : ");
            string tempFirstName = Console.ReadLine();
            Console.Write("Soy Isminiz : ");
            string tempLastName = Console.ReadLine();
            Console.Write("Dogum Yiliniz : ");
            int tempBirthYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Tc Kimlik Numaraniz :");
            long tempTcNo = Convert.ToInt64(Console.ReadLine());

            CheckService checkService = new CheckService();
            if (checkService.Check(tempTcNo, tempFirstName, tempLastName, tempBirthYear))
            {
                LogStatement = true;
                User user = new User();
                user.FirstName = tempFirstName;
                user.LastName = tempLastName;
                user.NickName = tempNickName;
                user.Password = tempPass;
                user.NationalityId = tempTcNo;
                user.Money = 150;
                for (int i = 0; i < users.Count() + 1; i++)
                {
                    user.Id = i;
                }

                users.Add(user);


                Console.WriteLine($"Tebrikler kaydiniz basariyla tamamlanmistir. Aramiza hosgeldin {user.NickName}");
            }
            else 
            {
                Console.WriteLine("Yanlis bilgi girisi yapilmistir. Lutfen Tekrar Deneyiniz");
            }

        }
    }
}
