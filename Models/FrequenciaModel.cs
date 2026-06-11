using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitControl.Models
{
    /// <summary>
    /// Representa a entidade das frequencias dos alunos academia no sistema.
    /// </summary>
    public class FrequenciaModel
    {
       private AlunoModel _aluno;
       private DateTime _dataHora;


       public AlunoModel Aluno
        {
           get { return _aluno; }
           set { _aluno = value; }
        }

        public DateTime DataHora 
        {
            get { return _dataHora; }
            set { _dataHora = value; }
        }


        /// <summary>
        /// Construtor padrão da classe FrequenciaModel.
        /// </summary>
        public FrequenciaModel() { }

        /// <summary>
        /// Construtor parametrizado para inicializar a frequência de um aluno.
        /// </summary>
        public FrequenciaModel(AlunoModel aluno, DateTime dataHora)
        {
            this._aluno= aluno;
            this._dataHora = dataHora;
        }

    }
}
