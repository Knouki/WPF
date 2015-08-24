using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfGestionMagasinFrontOffice;

namespace DaoGestionMagasins
{
    public class GestionMagasinBuilderFactory
    {
        public static WpfGestionMagasinFrontOffice.IGestionMagasin getInterface()
        {
            return new GestionMagasin();
        }
    }
}
