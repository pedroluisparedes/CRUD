using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class Control : Exception
    {
       public Control(string Mensaje) : base(Mensaje) { }
    }
}
