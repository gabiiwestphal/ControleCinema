using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloSessao;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class Sala : EntidadeBase
    {
        private int capacidade;
        private readonly int assentos;

        public Sala(int capacidade, int assentos)
        {
            this.capacidade = capacidade;
            this.assentos = assentos;
        }
        public int Capacidade => capacidade;
        public int NumeroAssentos => assentos;
        public void reservarAssentos(int quantidade)
        {
            this.capacidade -= quantidade;
        }
        public override string ToString()
        {

            return "Número: " + id + Environment.NewLine +
            "Capacidade: " + Capacidade + Environment.NewLine +
            "Número de assentos: " + NumeroAssentos + Environment.NewLine;

        }
    }
}
