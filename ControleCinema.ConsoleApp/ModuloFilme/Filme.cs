using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    public class Filme : EntidadeBase
    {
        private readonly Genero genero;
        public string titulo;
        public int duracao;

        public Filme(string titulo, int duracao, Genero generoSelecionado)
        {
            this.titulo = titulo;
            this.duracao = duracao;
            genero = generoSelecionado;
        }
        public string Titulo => titulo;
        public int Duracao => duracao;
        public Genero Genero => genero;
        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Título: " + titulo + Environment.NewLine +
                "Duraçao: " + duracao + Environment.NewLine +
                "Genero: " + genero.Descricao + Environment.NewLine;
        }
    }
}
