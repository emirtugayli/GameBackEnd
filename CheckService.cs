using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class CheckService
    {
        public bool Check(long NatId , string Name , string LastName , int BirthYear )
        {
            ConsoleApp1.TcDogrulaService.KPSPublicSoapClient client = new ConsoleApp1.TcDogrulaService.KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(NatId , Name , LastName , BirthYear);
        }
        
        
    }
}
