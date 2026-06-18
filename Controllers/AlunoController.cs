using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitControl.Models;
using FitControl.Data;
using System.IO;
using FitControl.Views;

namespace FitControl.Controllers
{
    public class AlunoController : BaseCRUD<AlunoModel>
    {
        /// <summary>
        /// Busca um aluno na lista através da sua matrícula (Chave Primária).
        /// Corresponde ao requisito do professor: "Método de busca que percorre a lista interna".
        /// </summary>
        
        public AlunoModel Ler(string matricula)
        {
            foreach (AlunoModel aluno in _dados)
            {
                if(aluno.Matricula == matricula)
                {
                    return aluno;
                }
            }
            return null;// Se não achar
        }

        /// <summary>
        /// Atualiza os dados de um aluno existente na lista.
        /// </summary>
        
        public void Alterar(AlunoModel dadosAtualizados)
        {
            // Reutiliza o método de busca para achar o aluno antigo na lista
            AlunoModel alunoAntigo = this.Ler(dadosAtualizados.Matricula);

            if(alunoAntigo != null)
            {
                // Substitui os dados antigos pelos novos menos matricula que é PK
                alunoAntigo.Nome = dadosAtualizados.Nome;
                alunoAntigo.Telefone = dadosAtualizados.Telefone;
                alunoAntigo.CPF = dadosAtualizados.CPF;
            }
        }

        // Define o nome do arquivo que será salvo na pasta do seu projeto
        private const string CaminhoArquivo = "alunos.txt";

        /// <summary>
        /// Salva a lista de alunos no arquivo .txt.
        /// </summary>
        public void SalvarDados()
        {
            // O StreamWriter é a caneta do C# que escreve em arquivos
            using (StreamWriter sw = new StreamWriter(CaminhoArquivo))
            {
                foreach (AlunoModel aluno in _dados) // _dados vem da sua BaseCRUD
                {
                    // Escreve uma linha no formato: Matricula;Nome;Telefone;CPF
                    sw.WriteLine($"{aluno.Matricula};{aluno.Nome};{aluno.Telefone};{aluno.CPF}");
                }
            }
        }

        /// <summary>
        /// Carrega os alunos do arquivo .txt para a lista ao iniciar o programa.
        /// </summary>
        public void CarregarDados()
        {
            // Só tenta ler se o arquivo existir (para não dar erro na primeira vez que rodar)
            if (File.Exists(CaminhoArquivo))
            {
                // Lê todas as linhas do bloco de notas
                string[] linhas = File.ReadAllLines(CaminhoArquivo);

                foreach (string linha in linhas)
                {
                    // Corta a linha onde tem o ponto e vírgula
                    string[] partes = linha.Split(';');

                    // Se a linha tiver as 4 partes (Matricula, Nome, Telefone, CPF)
                    if (partes.Length == 4)
                    {
                        // Reconstrói o aluno (O 5º parâmetro é nulo por enquanto, que seria o Plano)
                        AlunoModel aluno = new AlunoModel(partes[0], partes[1], partes[2], partes[3], null);

                        // Adiciona na lista da BaseCRUD
                        this.Adicionar(aluno);
                    }
                }
            }
        }

        public void CRUD(AlunoView view)
        {
            view.ShowForm();
            AlunoModel alunoPesquisa = view.EnterData("PK");
            AlunoModel alunoEncontrado = this.Ler(alunoPesquisa.Matricula);

            if (alunoEncontrado != null)
            {
                view.ShowData(alunoEncontrado);

                while (true)
                {
                    view.LimparArea(12, 18, 90, 18);
                    Console.SetCursorPosition(12, 18);
                    Console.Write("Aluno encontrado! Deseja (A)lterar, (E)xcluir ou (V)oltar? ");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao == "A")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        AlunoModel novosDados = view.EnterData("DT");
                        novosDados.Matricula = alunoEncontrado.Matricula;

                        this.Alterar(novosDados);

                        Console.SetCursorPosition(12, 18);
                        Console.Write("Dados alterados com sucesso! Pressione qualquer tecla...");
                        Console.ReadKey();
                        break;
                    }
                    else if (opcao == "E")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        Console.SetCursorPosition(12, 18);
                        Console.Write("Tem certeza que deseja excluir? (S/N): ");
                        if (Console.ReadLine().ToUpper() == "S")
                        {
                            this.Excluir(alunoEncontrado);
                            Console.SetCursorPosition(12, 18);
                            Console.Write("Aluno excluído com sucesso! Pressione qualquer tecla...");
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if (opcao == "V")
                    {
                        return;
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
            else
            {
                while (true)
                {
                    view.LimparArea(12, 18, 90, 18);
                    Console.SetCursorPosition(12, 18);
                    Console.Write("Aluno não encontrado! Deseja (I)ncluir novo ou (V)oltar? ");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao == "I")
                    {
                        view.LimparArea(12, 18, 90, 18);
                        AlunoModel novoAluno = view.EnterData("DT");
                        novoAluno.Matricula = alunoPesquisa.Matricula;

                        this.Adicionar(novoAluno);

                        Console.SetCursorPosition(12, 18);
                        Console.Write("Aluno cadastrado com sucesso! Pressione qualquer tecla...");
                        Console.ReadKey();
                        break;
                    }
                    else if (opcao == "V")
                    {
                        return;
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
