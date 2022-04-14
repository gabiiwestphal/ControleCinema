﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloFilme;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class TelaCadastroSala : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Sala> _repositorioSala;
        private readonly Notificador _notificador;

        public TelaCadastroSala(IRepositorio<Sala> repositorioSala, Notificador notificador)
            : base("Cadastro de Salas")
        {
            _repositorioSala = repositorioSala;
            _notificador = notificador;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Sala");

            Sala novaSala = ObterSala();

            _repositorioSala.Inserir(novaSala);

            _notificador.ApresentarMensagem("Sala cadastrada com sucesso!", TipoMensagem.Sucesso);
        }
        public void Editar()
        {
            MostrarTitulo("Editando Sala");

            bool temSalasCadastradas = VisualizarRegistros("Pesquisando");

            if (temSalasCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sala cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroSala = ObterNumeroRegistro();

            Sala salaAtualizada = ObterSala();

            bool conseguiuEditar = _repositorioSala.Editar(numeroSala, salaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sala editada com sucesso!", TipoMensagem.Sucesso);
        }
        public void Excluir()
        {
            MostrarTitulo("Excluindo Sala");

            bool temSalasRegistradas = VisualizarRegistros("Pesquisando");

            if (temSalasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sala cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroSala = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioSala.Excluir(numeroSala);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sala excluída com sucesso1", TipoMensagem.Sucesso);
        }
        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Salas");

            List<Sala> salas = _repositorioSala.SelecionarTodos();

            if (salas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma sala disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Sala sala in salas)
                Console.WriteLine(sala.ToString());

            Console.ReadLine();

            return true;
        }
        private Sala ObterSala()
        {
            Console.Write("Digite a capacidade da sala: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o número de assentos da sala: ");
            int assentos = Convert.ToInt32(Console.ReadLine());

            return new Sala(capacidade, assentos);
        }
        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da sala que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioSala.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da sala não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

    }
}
