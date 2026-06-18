using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitControl.Models;
using FitControl.Helpers;
using FitControl.Controllers;

namespace FitControl.Views
{
    public class AlunoView : Tela
    {
        /// <summary>
        /// View responsável pela interação de Alunos. Herda as funcionalidades visuais da classe Tela.
        /// </summary>
        
        private AlunoController _alunoController;

        // Construtor da classe AlunoView, recebe uma instância de AlunoController para gerenciar as operações relacionadas aos alunos. estabelece as cores de fundo e texto para a interface.
        public AlunoView(AlunoController alunoController) : base(ConsoleColor.DarkBlue, ConsoleColor.White)
        {
            _alunoController = alunoController;
        }

        /// <summary>
        /// Exibe o submenu específico para o gerenciamento de Alunos.
        /// </summary>
        public string ExibirSubMenu()
        {
            this.PrepararTela("Gerenciamento de alunos", 10, 5, 70, 20);

            List<string> opcoes = new List<string> 
            {
                "1 - Cadastrar Aluno",
                "2 - Listar Todos os Alunos",
                "3 - Alterar Dados do Aluno",
                "4 - Excluir Aluno",
                "0 - Voltar ao Menu Principal"
            };

            string opcaoEscolhida = this.MostrarMenu(22, 8, opcoes);
            return opcaoEscolhida;
        }



        /// <summary>
        /// Exibe o esqueleto do formulário na tela usando as molduras da classe Tela.
        /// </summary>
        public void ShowForm() 
        {
            // Usa o PrepararTela (que limpa tudo, desenha moldura e centraliza o título)
            // Parâmetros: Título, Coluna Inicial, Linha Inicial, Coluna Final, Linha Final
            this.PrepararTela("CADASTRO DE ALUNOS - FITCONTROL", 10, 5, 70, 15);

            // Desenha os rótulos para os campos de matrícula, nome e telefone, posicionando-os dentro da moldura.
            Console.SetCursorPosition(12, 8);
            Console.Write("Matrícula : ");

            Console.SetCursorPosition(12, 10);
            Console.Write("Nome      : ");

            Console.SetCursorPosition(12, 12);
            Console.Write("Telefone  : ");

            Console.SetCursorPosition(12, 14);
            Console.Write("CPF       : ");

        }

        /// <summary>
        /// Captura os dados que o usuário digitar nos espaços do formulário.
        /// name="which" Define se vai ler só a PK (chave primária) ou os DT (demais dados)
        /// </summary>
        public AlunoModel EnterData(string which)
        {
            string matricula = "";
            string nome = "";
            string telefone = "";
            string cpf = "";

            // Se for PK (Primary Key) OU ALL (Tudo), ele lê a matrícula
            if (which == "PK" || which == "ALL")
            {
                this.LimparArea(24,8,68,8);//Limpa só linha 8
                Console.SetCursorPosition(24, 8);
                matricula = Console.ReadLine();
            }

            // Se for DT (Data/Dados) OU ALL (Tudo), ele lê o resto
            if (which == "DT" || which == "ALL")
            {
                
                this.LimparArea(24,10,68,10);
                Console.SetCursorPosition(24, 10);
                nome = Console.ReadLine();

                this.LimparArea(24,12,68,12);
                Console.SetCursorPosition(24, 12);
                telefone = Console.ReadLine();

                this.LimparArea(24, 14, 68, 14);
                Console.SetCursorPosition(24, 14);
                cpf = Console.ReadLine();
            }
            return new AlunoModel(matricula, nome, telefone, cpf, null);
        }

        /// <summary>
        /// Exibe os dados de um aluno específico nos campos do formulário.
        /// </summary>
        public void ShowData(AlunoModel aluno)
        {
            Console.SetCursorPosition(24, 8);
            Console.Write(aluno.Matricula);

            Console.SetCursorPosition(24, 10);
            Console.Write(aluno.Nome);

            Console.SetCursorPosition(24, 12);
            Console.Write(aluno.Telefone);

            Console.SetCursorPosition(24, 14);
            Console.Write(aluno.CPF);
        }

        /// <summary>
        /// Exibe a lista de alunos cadastrados na tela.
        /// </summary>
        public void ListarAlunos(List<AlunoModel> alunos)
        {
            // Calcula o tamanho da tela baseado na quantidade de alunos (para a caixa não quebrar)
            // Se estiver vazio, a linha final é 13. Se tiver alunos, a caixa cresce.
            int linhaFinal = alunos.Count == 0 ? 13 : 11 + alunos.Count + 2;

            this.PrepararTela("LISTAGEM DE ALUNOS", 10, 5, 85, linhaFinal);

            Console.SetCursorPosition(12, 8);

            if (alunos.Count == 0)
            {
                Console.Write("Nenhum aluno cadastrado no sistema.");
            }
            else
            {
                // Cabeçalho da tabela (o sinal de - no número serve para alinhar as colunas)
                Console.Write($"{"MATRÍCULA",-10} | {"NOME",-25} | {"Contato",-11} | {"CPF",-11} ");

                int linhaAtual = 10; // Começa a listar os alunos a partir da linha 9

                foreach (AlunoModel aluno in alunos)
                {
                    Console.SetCursorPosition(12, linhaAtual);
                    // O símbolo -10 e -25 formata o texto para ocupar aquele espaço fixo, criando um visual de "Tabela"
                    Console.Write($"{aluno.Matricula,-10} | {aluno.Nome,-25} | {aluno.Telefone,-11} |{aluno.CPF,-11} ");
                    linhaAtual++;
                }
            }

            // Mensagem padrão de voltar
            Console.SetCursorPosition(12, linhaFinal - 1);
            Console.Write("Pressione qualquer tecla para voltar...");
        }
    }
}
