using CamadaDeNegocio;
using CamadaDeDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Data.SqlTypes;

namespace CamadaDeApresentacao;

public class Operacoes
{
    public void InserirFuncionario(IRepositorio lista)
    {


        int num = 0;
        DateTime data;
        double deci = 0;
        var funcionario = new Funcionario();
        bool boleano = false;

        Console.WriteLine("Digite o NOME do funcionario:");
        funcionario.Nome = Console.ReadLine();

        Console.WriteLine("Digite o NUMERO DE CADASTRO do funcionario:");
        int.TryParse(Console.ReadLine(), out num);
        funcionario.NumeroMatricula = num;

        Console.WriteLine("Digite o SALÁRIO do funcionario:");
        double.TryParse(Console.ReadLine(), out deci);
        funcionario.Salario = deci;

        Console.WriteLine("Digite o ano de INICIO DO CONTRATO do funcionário no formato [mm/yy/aaaa]:");
        DateTime datat = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        funcionario.InicioDoContrato = datat;

        Console.WriteLine("Digite se funcionario é APTO A PROMOÇÃO NA EMPRESE :[true] para sim, [false] para não:");
        bool.TryParse(Console.ReadLine(), out boleano);
        funcionario.Capacitado = boleano;

        lista.Salvar(funcionario);
        Console.Clear();
        Console.WriteLine("Funcionario adicionado com sucesso!!");
        Console.WriteLine();
        Console.WriteLine();

    }


    public void AlterarFuncionario(IRepositorio lista)
    {
        Console.WriteLine("Informe o numero de cadastro do funcionário:");
        int verMatricula = int.Parse(Console.ReadLine());
        var pesquisa = lista.Listar();
        var MatriculaFuncio = lista.Listar().FirstOrDefault(a => a.NumeroMatricula == verMatricula);


        if (pesquisa.Any())
        {

            foreach (var funcionario in pesquisa)
            {
                Console.WriteLine("Funcionário encontrado:");
                Console.WriteLine();
                Console.WriteLine($"Número de cadastro: {funcionario.NumeroMatricula}");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"Salário: {funcionario.Salario}");
                Console.WriteLine($"Início do Contrato: {funcionario.InicioDoContrato.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Capacitado: {funcionario.Capacitado}");
                Console.WriteLine();
                Console.WriteLine();
            }

            Funcionario novoFuncionario = new Funcionario();
            Console.WriteLine("Informe os novos dados do funcionário");

            Console.WriteLine("Digite o nome do funcionário:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o número de cadastro:");
            int matricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o salário:");
            double salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de início do contrato (no formato dd/mm/yyyy):");
            DateTime contrato = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


            Console.WriteLine("Digite se funcionario é APTO A PROMOÇÃO NA EMPRESE :[true] para sim, [false] para não:");
            bool bole;
            bool.TryParse(Console.ReadLine(), out bole);

            bool capacidade = bole;



            lista.Atualizar(MatriculaFuncio, nome, matricula, salario, contrato, capacidade);
            Console.Clear();
            Console.WriteLine("Funcionario alterado com sucesso!!");
            Console.WriteLine();
            Console.WriteLine();

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nenhum funcionário encontrado.");
            Console.WriteLine();
            Console.WriteLine();
        }
        
    }



    public void ListarFuncionario(IRepositorio lista)
    {
        var funcionarios = lista.Listar();
        Console.WriteLine("Deseja consultar o funcionário pelo nome ou pelo número de cadastro");
        Console.WriteLine("[1] Nome");
        Console.WriteLine("[2] Número de cadastro");
        string resposta = Console.ReadLine();

        int contador = 0; 

        switch (resposta)
        {
            case "1":
                Console.WriteLine("Informe o nome ou parte do nome do funcionário:");
                string parteNomePesquisa = Console.ReadLine();
                Console.WriteLine("Esses são os Funcionários encontrados na lista:");

                foreach (Funcionario funcionario in funcionarios)
                {
                    if (funcionario.Nome.Contains(parteNomePesquisa, StringComparison.OrdinalIgnoreCase))
                    {
                        contador++;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"Número de cadastro: {funcionario.NumeroMatricula}");
                        Console.WriteLine($"Nome: {funcionario.Nome}");
                        Console.WriteLine($"Salário: {funcionario.Salario}");
                        Console.WriteLine($"Início do Contrato: {funcionario.InicioDoContrato.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Capacitado: {funcionario.Capacitado}");
                        Console.WriteLine();
                        
                    }
                }

                if (contador == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nenhum funcionário encontrado com a parte do nome pesquisada.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                break;

            case "2":
                Console.WriteLine("Informe o numero de cadastro do funcionário:");
                int verMatricula = int.Parse(Console.ReadLine());
                var Matricula = lista.Listar().FirstOrDefault(a => a.NumeroMatricula == verMatricula);

                if (Matricula != null)
                {
                    Console.WriteLine("Lista de funcionários");

                    foreach (var funcionario in funcionarios)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"Número de cadastro: {funcionario.NumeroMatricula}");
                        Console.WriteLine($"Nome: {funcionario.Nome}");
                        Console.WriteLine($"Salário: {funcionario.Salario}");
                        Console.WriteLine($"Início do Contrato: {funcionario.InicioDoContrato.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Capacitado: {funcionario.Capacitado}");
                        Console.WriteLine();
                        
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nenhum funcionário encontrado.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                break;

            default:
                Console.Clear();
                Console.WriteLine("Opção inválida.");
                Console.WriteLine();
                Console.WriteLine();
                break;
        }



    }


    public void RemoverFuncionario(IRepositorio lista)
    {
        var pesquisa = lista.Listar();
        Console.WriteLine("Informe o número de cadastro do funcionário:");
        int verMatricula = int.Parse(Console.ReadLine());
        var Matricula = lista.Listar().FirstOrDefault(a => a.NumeroMatricula == verMatricula);

        if (pesquisa.Any())
        {
            Console.WriteLine("Lista de funcionários");

            foreach (var funcionario in pesquisa)
            {
                Console.WriteLine();
                Console.WriteLine($"Número de cadastro: {funcionario.NumeroMatricula}");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"Salário: {funcionario.Salario}");
                Console.WriteLine($"Início do Contrato: {funcionario.InicioDoContrato.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Capacitado: {funcionario.Capacitado}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nenhum funcionário encontrado.");
            Console.WriteLine();
            Console.WriteLine();
        }


        if (Matricula != null)
        {
            Console.WriteLine("deseja mesmo excluir este funcionário: ");
            Console.WriteLine("[1] sim ");
            Console.WriteLine("[2] não");
            string decisao = Console.ReadLine();


            switch (decisao)

            {
                case "1":
                    lista.Remover(verMatricula);
                    Console.WriteLine("Funcionário removido com sucesso.");
                    break;

                case "2":
                    Console.WriteLine("Operação cancelada.");
                    break;

                default:
                    Console.WriteLine("Escolha de opção inválida!");
                    break;
            }


        }
        else
        {
            Console.Clear();
            Console.WriteLine("Numero de cadastro do funcionário não encontrado.");
        }
    }


}