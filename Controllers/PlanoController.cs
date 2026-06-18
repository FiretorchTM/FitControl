using System;
using System.Collections.Generic;
using System.IO;
using FitControl.Models;
using FitControl.Data;
using FitControl.Views;

namespace FitControl.Controllers
{
    // Herdando o motor genérico que você criou!
    public class PlanoController : BaseCRUD<PlanoModel>
    {
        private const string CaminhoArquivo = "planos.txt";

        public PlanoModel Ler(string codigoPlano)
        {
            foreach (PlanoModel plano in _dados)
            {
                if (plano.CodigoPlano == codigoPlano) return plano;
            }
            return null;
        }

        public void Alterar(PlanoModel dadosAtualizados)
        {
            PlanoModel planoAntigo = this.Ler(dadosAtualizados.CodigoPlano);
            if (planoAntigo != null)
            {
                planoAntigo.Descricao = dadosAtualizados.Descricao;
                planoAntigo.ValorMensalidade = dadosAtualizados.ValorMensalidade;
                planoAntigo.LimiteAulas = dadosAtualizados.LimiteAulas;
            }
        }

        public void SalvarDados()
        {
            using (StreamWriter sw = new StreamWriter(CaminhoArquivo))
            {
                foreach (PlanoModel plano in _dados)
                {
                    sw.WriteLine($"{plano.CodigoPlano};{plano.Descricao};{plano.ValorMensalidade};{plano.LimiteAulas}");
                }
            }
        }

        public void CarregarDados()
        {
            if (File.Exists(CaminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(CaminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length == 4)
                    {
                        PlanoModel plano = new PlanoModel(
                            partes[0],
                            partes[1],
                            double.Parse(partes[2]),
                            int.Parse(partes[3])
                        );
                        this.Adicionar(plano);
                    }
                }
            }
        }

        /// <summary>
        /// O coração do sistema para Planos, rodando Buscar -> Exibir -> Cadastrar/Alterar/Excluir
        /// </summary>
        public void CRUD(PlanoView view)
        {
            view.ShowForm();
            PlanoModel planoPesquisa = view.EnterData("PK");
            PlanoModel planoEncontrado = this.Ler(planoPesquisa.CodigoPlano);


            if (planoEncontrado != null)
            {
                view.ShowData(planoEncontrado);

                // O LOOP COMEÇA AQUI: Prende o usuário até ele digitar A, E ou V
                while (true)
                {
                    view.LimparArea(12, 18, 90, 18);
                    Console.SetCursorPosition(12, 18);
                    Console.Write("Plano encontrado! Deseja (A)lterar, (E)xcluir ou (V)oltar? ");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao == "A")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        PlanoModel novosDados = view.EnterData("DT");
                        novosDados.CodigoPlano = planoEncontrado.CodigoPlano;

                        this.Alterar(novosDados);

                        Console.SetCursorPosition(12, 18);
                        Console.Write("Dados alterados com sucesso! Pressione qualquer tecla...");
                        Console.ReadKey();
                        break; // Sucesso! Quebra o loop e encerra a operação.
                    }
                    else if (opcao == "E")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        Console.SetCursorPosition(12, 18);
                        Console.Write("Tem certeza que deseja excluir? (S/N): ");
                        if (Console.ReadLine().ToUpper() == "S")
                        {
                            this.Excluir(planoEncontrado);
                            Console.SetCursorPosition(12, 18);
                            Console.Write("Plano excluído com sucesso! Pressione qualquer tecla...");
                            Console.ReadKey();
                        }
                        break; // Quebra o loop após excluir (ou cancelar).
                    }
                    else if (opcao == "V")
                    {
                        return; // O return encerra o método CRUD inteiro e joga pro menu principal!
                    }
                    else
                    {
                        view.LimparArea(12, 18, 90, 18);
                        Console.SetCursorPosition(12, 18);
                        Console.Write("Opção inválida! Pressione qualquer tecla para tentar de novo...");
                        Console.ReadKey();
                        // Como não tem break aqui, o laço volta lá pro começo e repete a pergunta!
                    }
                }
            }
            else
            {
                // O LOOP DA INCLUSÃO: Prende o usuário até ele digitar I ou V
                while (true)
                {
                    view.LimparArea(12, 18, 90, 18);
                    Console.SetCursorPosition(12, 18);
                    Console.Write("Plano não encontrado! Deseja (I)ncluir novo ou (V)oltar? ");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao == "I")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        PlanoModel novoPlano = view.EnterData("DT");
                        novoPlano.CodigoPlano = planoPesquisa.CodigoPlano;

                        this.Adicionar(novoPlano);

                        Console.SetCursorPosition(12, 18);
                        Console.Write("Plano cadastrado com sucesso! Pressione qualquer tecla...");
                        Console.ReadKey();
                        break; // Sucesso! Quebra o loop.
                    }
                    else if (opcao == "V")
                    {
                        return; // Encerra o método e volta pro menu.
                    }
                    else
                    {
                        view.LimparArea(12, 18, 90, 18);
                        Console.SetCursorPosition(12, 18);
                        Console.Write("Opção inválida! Pressione qualquer tecla para tentar de novo...");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}