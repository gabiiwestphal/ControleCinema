using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloFilme;
using ControleCinema.ConsoleApp.ModuloFuncionario;
using ControleCinema.ConsoleApp.ModuloSala;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class Sessao : EntidadeBase
    {
        private readonly Sala sala;
        private readonly Filme filme;
        private string titulo;
        private string duracao;
        private string horarioDaSessao;
        private int IngressosDisponiveis;
        private Funcionario funcionario;

        public Sessao(Filme filme, Sala sala, string horarioDaSessao)
        {
            this.filme = filme;
            this.sala = sala;
            this.titulo = filme.titulo;
            this.horarioDaSessao = horarioDaSessao;
            this.IngressosDisponiveis = this.sala.NumeroAssentos;
            
        }
        public Sessao(Funcionario funcionario, Sala sala, Filme filme)
        {
            this.funcionario = funcionario;
            this.sala = sala;
            this.filme = filme;

        }
        public void venderIngresso(int quantidade)
        {
            if (IngressosDisponiveis >= 0)
            {
               Console.WriteLine("Os ingressos acabaram..");
            }
            else
            {
                IngressosDisponiveis -= quantidade;
            }
        }
        public override string ToString()
        {
             return "Sessão: " + id + Environment.NewLine +
                "Filme: " + filme.Titulo + Environment.NewLine +
                "Sala: " + sala.id + Environment.NewLine +
                "Quantidade de Ingressos: " + this.IngressosDisponiveis + Environment.NewLine;


        }
    }
}
