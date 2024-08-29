using CamadaDeDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeApresentacao
{
    public class Program
    {

        public static void Main(string[] args)
        {

            IRepositorio repositorio = new ListaMemoria();

            Console.WriteLine("Escolha onde deseja salvar os funcionários:");
            Console.WriteLine("[1] Lista em Memoria");
            Console.WriteLine("[2] Lista em Arquivo");
            string decisao = Console.ReadLine();

            switch (decisao)
            {
                case "1":
                    repositorio = new ListaMemoria();
                    break;

                case "2":
                    repositorio = new ListaArquivo();
                    break;

                default:
                    Console.WriteLine("Escolha escolha uma opção valida para salvar os funcionários:");
                    break;
            }



            bool resposta = true;
            Operacoes menu = new Operacoes();


            while (resposta)
            {
                
                Console.WriteLine("Escolha uma das opção abaixo");
                Console.WriteLine("[1] para adicionar Funcionario na lista");
                Console.WriteLine("[2] para alterar Funcionario da lista");
                Console.WriteLine("[3] para consultar Funcionario da lista");
                Console.WriteLine("[4] para excluir Funcionario da lista");
                Console.WriteLine("[5] para saír");
                var resp = Console.ReadLine();

                if (resp == "1")
                {
                    menu.InserirFuncionario(repositorio);

                }

                else if (resp == "2")
                {
                    menu.AlterarFuncionario(repositorio);
                }

                else if (resp == "3")
                {
                    menu.ListarFuncionario(repositorio);
                }

                if (resp == "4")
                {
                    menu.RemoverFuncionario(repositorio);
                }

                else if (resp == "5")
                {
                    resposta = false;
                }
            }

        }
    }
}