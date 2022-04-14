using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloSessao;

namespace ControleCinema.ConsoleApp.ModuloIngresso //VENDER O INGRESSO
{
    public class Ingresso : EntidadeBase
    {
        private readonly string tipo;
        private readonly int poltrona;
        private readonly bool status = false;

        public Ingresso(string tipo)
        {
            this.tipo = tipo;
        }
        public string Tipo => tipo;
        public override string ToString()
        {

            return "Número: " + id + Environment.NewLine +
            "Tipo: " + tipo + Environment.NewLine;

        }

    }
}
