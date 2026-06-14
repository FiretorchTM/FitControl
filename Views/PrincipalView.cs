using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitControl.Helpers;

namespace FitControl.Views
{
    /// <summary>
    /// View responsável por exibir o menu inicial e gerenciar a navegação principal do sistema.
    /// </summary>
    internal class PrincipalView : Tela
    {
        //Construtor que mantem com o padrao visual do programa(Fundo azul escuro e fundo branco)
        public PrincipalView() : base(ConsoleColor.DarkBlue, ConsoleColor.White) { }

        /// <summary>
        /// Exibe a tela principal com as opções do sistema e retorna a escolha do usuário.
        /// </summary>
        public string ExibirMenu() 
        {
            // Limpa e prepara a tela inteira
            this.PrepararTela("SISTEMA FITCONTROL - MENU PRINCIPAL", 10, 5, 70, 20);


            // Cria a lista de opções que o método MostrarMenu exige
            List<string> opcoes = new List<string>
            {
                "1 - Gerenciar Alunos",
                "2 - Gerenciar Planos",
                "3 - Relatórios",
                "0 - Sair do Sistema"
            };

            // O metodo MostrarMenu desenha uma caixinha interna, e ja retorna a opção digitada.
            // Posicionamento no meio da tela: (coluna 29, 8, opcoes).
            string opcaoEscolhida = this.MostrarMenu(22, 8, opcoes);

            return opcaoEscolhida;
        }
    }
}
