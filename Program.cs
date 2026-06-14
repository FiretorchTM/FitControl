using FitControl.Controllers;
using FitControl.Models;
using FitControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aviso: Não redimensione a janela para não quebrar o layout da classe Tela ||| Se redimencionar o primeiro input vai quebrar mas os outros não.
            Console.Title = "FitControl - Academia"; // Muda o nome no topo da janela

            AlunoController alunoController = new AlunoController();
            AlunoView alunoView = new AlunoView(alunoController);//Objeto
            PrincipalView menuView = new PrincipalView();

            string opcaoPrincipal = "";

            // Meu laço principal
            while (opcaoPrincipal != "0") 
            {
                // Mostra o menu e guarda o input do usuario
                opcaoPrincipal = menuView.ExibirMenu();

                switch (opcaoPrincipal)
                {

                    case "1":
                        //Abre a tela dos alunos
                        alunoView.ShowForm();
                        AlunoModel novoAluno = alunoView.EnterData("ALL");

                        alunoController.Adicionar(novoAluno);

                        alunoView.Centralizar(10, 70, 17, $"Aluno {novoAluno.Nome} lido com sucesso!");
                        Console.ReadKey();// Pausazinha para o aluno ler a msg
                        break;

                    // Futura tela de planos
                    case "2":
                        menuView.Centralizar(10, 70, 17, "PLANOS: em construção...");
                        Console.ReadKey();
                        break;

                    // Futura tela de relatorios
                    case "3":
                        menuView.Centralizar(10, 70, 17, "RELATÓRIOS: em construção...");
                        Console.ReadKey();
                        break;

                    case "4":
                        menuView.Centralizar(10, 70, 17, "Exclusão em construção...");
                        break;

                    // Saida do programa
                    case "0":
                        menuView.Centralizar(10, 70, 17, "Encerrando o sistema. Até logo!");
                        Console.ReadKey();
                        break;

                    default:
                        // Caso o usuário digite alguma coisa que não esta no menu
                        menuView.Centralizar(10, 70, 17, "Opção invalida! tente novamente.");
                        break;
                }
            }
            break;
        }
    }
}
