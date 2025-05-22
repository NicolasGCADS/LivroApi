using LivroModel;
using System.Xml.Linq;

namespace CP2.Business
{
    public class LivroService
    {
        private static readonly List<Livro> _livros = new();
        private static int _nextId = 1;

        public List<Livro> ListarTodos() => _livros;

        public Livro? ObterPorId(int id) =>
            _livros.FirstOrDefault(l => l.Id == id);

        public Livro Criar(Livro livro)
        {
            livro.Id = _nextId++;
            _livros.Add(livro);
            return livro;
        }

        public bool Atualizar(Livro livro)
        {
            var existente = ObterPorId(livro.Id);
            if (existente == null) return false;

            existente.Titulo = livro.Titulo;
            existente.Autor = livro.Autor;
            existente.Preco = livro.Preco;
            existente.AnoPublicacao = livro.AnoPublicacao;

            return true;
        }

        public bool Remover(int id)
        {
            var livro = ObterPorId(id);
            if (livro == null) return false;

            _livros.Remove(livro);
            return true;
        }


    }
}