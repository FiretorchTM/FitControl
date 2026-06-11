using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitControl.Models
{
    /// <summary>
    /// Representa a entidade de um plano de academia no sistema.
    /// </summary>
    public class PlanoModel
    {
        private string _codigoPlano;
        private string _descricao;
        private double _valorMensalidade;
        private int _limiteAulas;

        public string CodigoPlano
        {
            get { return _codigoPlano; }
            set { _codigoPlano = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public double ValorMensalidade
        {   
            get { return _valorMensalidade; }
            set { _valorMensalidade = value; }
        } 
        public int LimiteAulas 
        {
            get { return _limiteAulas; }
            set { _limiteAulas = value; }
        }

        /// <summary>
        /// Construtor padrão da classe PlanoModel.
        /// </summary>
        public PlanoModel() { }

        /// <summary>
        /// Construtor parametrizado para inicializar um plano com dados.
        /// </summary>
        public PlanoModel(string codigoPlano, string descricao, double valorMensalidade, int limiteAulas)
        {
            this._codigoPlano = codigoPlano;
            this._descricao = descricao;
            this._valorMensalidade = valorMensalidade;
            this._limiteAulas = limiteAulas;
        }
    }
}
