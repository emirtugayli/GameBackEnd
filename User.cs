using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    public class User
    {
        public long NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string NickName { get; set; }
        public double Money { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int UserType { get; set; }
    }
}
