using System;
using System.Collections.Generic;
using FitControl.Models;
using FitControl.Helpers;

namespace FitControl.Views
{
    public class PlanoView : Tela
    {
        public PlanoView() : base(ConsoleColor.DarkBlue, ConsoleColor.White) { }

        public void ShowForm()
        {
            this.PrepararTela("CADASTRO DE PLANOS", 10, 5, 70, 15);
            Console.SetCursorPosition(12, 8); Console.Write("Código    : ");
            Console.SetCursorPosition(12, 10); Console.Write("Descrição : ");
            Console.SetCursorPosition(12, 12); Console.Write("Valor (R$): ");
            Console.SetCursorPosition(12, 14); Console.Write("Lim. Aulas: ");
        }

        public PlanoModel EnterData(string which)
        {
            string codigo = "";
            string descricao = "";
            double valor = 0;
            int limite = 0;

            if (which == "PK" || which == "ALL")
            {
                this.LimparArea(24, 8, 68, 8);
                Console.SetCursorPosition(24, 8);
                codigo = Console.ReadLine();
            }

            if (which == "DT" || which == "ALL")
            {
                this.LimparArea(24, 10, 68, 10);
                Console.SetCursorPosition(24, 10);
                descricao = Console.ReadLine();

                this.LimparArea(24, 12, 68, 12);
                Console.SetCursorPosition(24, 12);
                // O TryParse tenta converter. Se o usuário digitar "abc", ele salva 0 e não quebra o sistema!
                double.TryParse(Console.ReadLine(), out valor);

                this.LimparArea(24, 14, 68, 14);
                Console.SetCursorPosition(24, 14);
                int.TryParse(Console.ReadLine(), out limite);
            }

            return new PlanoModel(codigo, descricao, valor, limite);
        }

        public void ShowData(PlanoModel plano)
        {
            Console.SetCursorPosition(24, 8); Console.Write(plano.CodigoPlano);
            Console.SetCursorPosition(24, 10); Console.Write(plano.Descricao);//ToString(F2) para formato de dinheiro
            Console.SetCursorPosition(24, 12); Console.Write(plano.ValorMensalidade.ToString("F2"));
            Console.SetCursorPosition(24, 14); Console.Write(plano.LimiteAulas);
        }

        public void ListarPlanos(List<PlanoModel> planos)
        {
            int linhaFinal = planos.Count == 0 ? 13 : 11 + planos.Count + 2;
            this.PrepararTela("LISTAGEM DE PLANOS", 10, 5, 85, linhaFinal);

            Console.SetCursorPosition(12, 8);

            if (planos.Count == 0)
            {
                Console.Write("Nenhum plano cadastrado no sistema.");
            }
            else
            {
                Console.Write($"{"CÓDIGO",-10} | {"DESCRIÇÃO",-30} | {"VALOR",-10} | {"AULAS",-10} ");
                int linhaAtual = 10;
                foreach (PlanoModel plano in planos)
                {
                    Console.SetCursorPosition(12, linhaAtual);
                    Console.Write($"{plano.CodigoPlano,-10} | {plano.Descricao,-30} | {plano.ValorMensalidade.ToString("F2"),-10} | {plano.LimiteAulas,-10} ");
                    linhaAtual++;
                }
            }

            Console.SetCursorPosition(12, linhaFinal - 1);
            Console.Write("Pressione qualquer tecla para voltar...");
        }
    }
}