using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDeNegocio;

namespace CamadaDeDados
{
    public interface IRepositorio
    {
        void Salvar(Funcionario funcionario);

        List<Funcionario> Listar();

        void Remover(int numNumeroMatricula);

        void Atualizar(Funcionario AtualizaFunci, string nome, int matricula, double salario, DateTime contrato, bool capacidade);
    }
}

