using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;

namespace ControleCinema.ConsoleApp.ModuloGenero
{
    public class Genero : EntidadeBase
    {
        public string Descricao { get; set; }

        public Genero(string descricao)
        {
            Descricao = descricao;
        }
        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Descrição do Gênero: " + Descricao + Environment.NewLine;
        }
    }
}
