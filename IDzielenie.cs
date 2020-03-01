using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dzielenie
{
    interface iDzielenie
    {
        string wynik { get; set; }
        string plikRaport { get; set; }

        void Oblicz();
    }
}
