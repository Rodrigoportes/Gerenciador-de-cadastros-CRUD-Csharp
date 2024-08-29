using CamadaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class ListaMemoria : IRepositorio
    {
        private List<Funcionario> funcionarios = new List<Funcionario>();

        public void Salvar(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }


        public List<Funcionario> Listar()
        {
            return funcionarios;
        }


        public void Remover(int num)
        {
            var funcionario = funcionarios.FirstOrDefault(x => x.NumeroMatricula == num);
            if (funcionario != null)
            {
                funcionarios.Remove(funcionario);
            }
        }


        public void Atualizar(Funcionario AtualizaFunci, string nome, int matricula, double salario, DateTime contrato, bool capacidade)
        {
            var funcionario = funcionarios.FirstOrDefault(x => x.NumeroMatricula == AtualizaFunci.NumeroMatricula);
            if (funcionario != null)
            {
                funcionario.Nome = nome;
                funcionario.NumeroMatricula = matricula;
                funcionario.Salario = salario;
                funcionario.InicioDoContrato = contrato;
                funcionario.Capacitado = capacidade;
            }
        }


    }
}