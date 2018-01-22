using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Personal
    {
        public Personal_Nivel1 Personal_Nivel1 { get; set; }
        public List<Personal_Nivel2> Personal_Nivel2 { get; set; }

        public Personal()
        {
            this.Personal_Nivel1 = new Personal_Nivel1();
            this.Personal_Nivel2 = new List<Core.Personal_Nivel2>();
        }        
    }
}
