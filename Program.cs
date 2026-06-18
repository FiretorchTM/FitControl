using FitControl.Controllers;
using FitControl.Data;
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
            Console.Title = "Academia - FitControl"; // Muda o nome no topo da janela

            //--------------Instanciar Controllers e views
            AlunoController alunoController = new AlunoController();
            AlunoView alunoView = new AlunoView(alunoController);//Objeto

            PlanoController planoController = new PlanoController();
            PlanoView planoView = new PlanoView();

            PrincipalView menuView = new PrincipalView();
            //--------------Carregar dados iniciais do txt
            alunoController.CarregarDados();
            planoController.CarregarDados();

            string opcaoPrincipal = "";

            // Meu laço principal
            while (opcaoPrincipal != "0") 
            {
                // Mostra o menu e guarda o input do usuario
                opcaoPrincipal = menuView.ExibirMenu();

                switch (opcaoPrincipal)
                {

                    case "1":// Tela dos alunos
                        alunoController.CRUD(alunoView);
                        break;

                    case "2":// Tela dos planos
                        planoController.CRUD(planoView);
                        break;

                    
                    case "3":// Tela dos relatorios
                        menuView.Centralizar(10, 70, 17, "RELATÓRIOS: em construção...");
                        Console.ReadKey();
                        break;

                    case "4":
                        menuView.Centralizar(10, 70, 17, "Exclusão em construção...");
                        break;

                    // Saida do programa
                    case "0":
                        alunoController.SalvarDados();
                        planoController.SalvarDados();
                        menuView.Centralizar(10, 70, 17, "Encerrando o sistema. Até logo!");
                        Console.ReadKey();
                        break;

                    default:
                        // Caso o usuário digite alguma coisa que não esta no menu
                        menuView.Centralizar(10, 70, 17, "Opção invalida! tente novamente.");
                        break;
                }
            }





        }
    }
}


