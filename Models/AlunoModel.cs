using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitControl.Models
{
    /// <summary>
    /// Representa a entidade de um aluno matriculado na academia.
    /// </summary>

    public class AlunoModel
    {
        private string _matricula;
        private string _nome;
        private string _telefone;
        private string _cpf;
        private PlanoModel _planoContratado;

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public PlanoModel PlanoContratado
        {
            get { return _planoContratado; }
            set { _planoContratado = value; }
        }

        /// <summary>
        /// Construtor padrão da classe AlunoModel.
        /// </summary>
        public AlunoModel() { }

        /// <summary>
        /// Construtor parametrizado para inicializar um aluno vinculado a um objeto PlanoModel.
        /// </summary>
        public AlunoModel(string matricula, string nome, string telefone,string cpf, PlanoModel plano)
        {
            this._matricula = matricula;
            this._nome = nome;
            this._telefone = telefone;
            this._cpf = cpf;
            this._planoContratado = plano;
        }
    }
}
