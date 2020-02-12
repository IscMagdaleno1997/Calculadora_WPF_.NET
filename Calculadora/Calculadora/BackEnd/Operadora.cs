using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.BackEnd
{
   
    class Operadora
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public string Operacion { get; set; }
        

        public Operadora()
        {
            Numero1 = 0;
            Numero2 = 0;
            Operacion = "";
        }


        public double operacion()
        {
            double total = 0;
            switch (Operacion)
            {

                case "+":
                    total = Numero1 + Numero2;
                    return total;

                case "-":
                    total = Numero1 - Numero2;
                    return total;

                case "/":
                    total = Numero1 / Numero2;
                    return total;

                case "*":
                    total = Numero1 * Numero2;
                    return total;
            }

            return 0;
        }
    }
}
