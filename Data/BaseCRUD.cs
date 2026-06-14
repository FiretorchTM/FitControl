using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitControl.Data
{
    /// <summary>
    /// Classe genérica base para operações CRUD, é abstrata e utiliza um tipo genérico T para representar a entidade que será gerenciada.
    /// </summary>

    public abstract class BaseCRUD<T>
    {

        // A lista protegida atua como nosso Banco de Dados em memória.
        // O "protected" permite que as classes filhas (ex: AlunoController) acessem a lista.
        protected List<T> _dados = new List<T>();

        /// <summary>
        /// Adiciona uma nova entidade à lista.
        /// </summary>
        public void Adicionar(T entidade)
        {
            _dados.Add(entidade);
        }

        /// <summary>
        /// Retorna todos os registros cadastrados.
        /// </summary>
        public List<T> Listar()
        {
            return _dados;
        }


        /// <summary>
        /// Exclui uma entidade específica da lista.
        /// </summary>
        public void Excluir(T entidade)
        { 
            _dados.Remove(entidade);
        }

    }
}
