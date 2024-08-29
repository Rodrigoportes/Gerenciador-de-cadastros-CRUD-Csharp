using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDeNegocio;

namespace CamadaDeDados
{
    public class ListaArquivo : IRepositorio
    {
        private static string path = "funcionarios.txt";
        private List<Funcionario> funcionarios;

        public ListaArquivo()
        {
            if (File.Exists(path))
            {
                var linhas = File.ReadAllLines(path);
                funcionarios = new List<Funcionario>();
                foreach (var linha in linhas)
                {
                    var valores = linha.Split(',');
                    var funcionario = new Funcionario
                    {
                        Nome = valores[0],
                        NumeroMatricula = int.Parse(valores[1]),
                        Salario = double.Parse(valores[2]),
                        InicioDoContrato = DateTime.Parse(valores[3]),
                        Capacitado = bool.Parse(valores[4])
                    };
                    funcionarios.Add(funcionario);
                }
            }
            else
            {
                funcionarios = new List<Funcionario>();
            }
        }


        public void Salvar(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            SalvarArquivo();
        }

        public List<Funcionario> Listar()
        {
            return funcionarios;
        }

        public void Atualizar(Funcionario AtualizaFunci, string nome, int matricula, double salario, DateTime contrato, bool capacidade)
        {
            var funcionarioExistente = funcionarios.FirstOrDefault(f => f.NumeroMatricula == AtualizaFunci.NumeroMatricula);
            if (funcionarioExistente != null)
            {

                funcionarioExistente.Nome = AtualizaFunci.Nome;
                funcionarioExistente.NumeroMatricula = AtualizaFunci.NumeroMatricula;
                funcionarioExistente.Salario = AtualizaFunci.Salario;
                funcionarioExistente.InicioDoContrato = AtualizaFunci.InicioDoContrato;
                funcionarioExistente.Capacitado = AtualizaFunci.Capacitado;
                SalvarArquivo();
            }
            else
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }
        }

        public void Remover(int numeroMatricula)
        {
            var funcionarioExistente = funcionarios.FirstOrDefault(f => f.NumeroMatricula == numeroMatricula);
            if (funcionarioExistente != null)
            {
                funcionarios.Remove(funcionarioExistente);
                SalvarArquivo();
            }
            else
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }
        }

        private void SalvarArquivo()
        {

            var linhas = funcionarios.Select(funcionario =>
                $"{funcionario.Nome},{funcionario.NumeroMatricula},{funcionario.Salario},{funcionario.InicioDoContrato},{funcionario.Capacitado}")
                .ToList();

            File.WriteAllLines(path, linhas);
        }





    }
}
