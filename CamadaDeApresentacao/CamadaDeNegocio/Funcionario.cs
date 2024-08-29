using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocio
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public int NumeroMatricula { get; set; }
        public double Salario { get; set; }
        public DateTime InicioDoContrato { get; set; }
        public bool Capacitado { get; set; }


    }
}