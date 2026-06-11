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
            // Criação de planos-------------------------------------------------------------
            PlanoModel plano1 = new PlanoModel("01", "Plano Básico: não inclui cicling nem natação", 99.99, 1);
            PlanoModel plano2 = new PlanoModel();

            plano2.CodigoPlano = "02";
            plano2.Descricao = "Plano Intermediário: inclui cicling, mas não inclui natação";
            plano2.ValorMensalidade = 149.99;
            plano2.LimiteAulas = 3;

            PlanoModel plano3 = new PlanoModel("03", "Plano Premium: inclui cicling e natação", 199.99, 5);

            // Criação de alunos-------------------------------------------------------------
            AlunoModel aluno1 = new AlunoModel("12345", "João Silva", "11987654321", plano1);
            AlunoModel aluno2 = new AlunoModel();

                aluno2.Matricula = "67890";
                aluno2.Nome = "Maria Souza";
                aluno2.Telefone = "11912345678";
                aluno2.PlanoContratado = plano2;

            // Criação de frequências-------------------------------------------------------------
            FrequenciaModel frequencia1 = new FrequenciaModel(aluno1,DateTime.Now);
            FrequenciaModel frequencia2 = new FrequenciaModel(aluno2, DateTime.Now);



        }
    }
}
