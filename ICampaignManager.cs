using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd
{
    interface ICampaignManager
    {
        void Add(Game game);
        void Update();
        void Delete(Game game);
        void Apply();
        void Stop();
    }
}
