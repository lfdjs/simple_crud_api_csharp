using teste_emprego.DAO;
using teste_emprego.Model;

namespace teste_emprego.Repositorio
{
    public class CidadeRepositorio
    {
        private readonly CidadeDAO _cidadeDAO; 
        private readonly Cidade _cidade;



        public CidadeRepositorio()
        {
            _cidadeDAO = new CidadeDAO(); ;
           
        }

        public CidadeRepositorio(Cidade cidade)
        {
            _cidade = cidade; 
            _cidadeDAO = new CidadeDAO(); ;

        }

        public List<Cidade> GetCidades {
            get {
                return _cidadeDAO.GetCidades();
            }
        }

        public List<Cidade> GetCidadesNome => _cidadeDAO.GetCidades(_cidade);

        public void InserirCidade(Cidade cidade) {
            _cidadeDAO.InserirCidade(cidade);
        }
        public void AlterarCidade(Cidade cidade)
        {
            _cidadeDAO.AlterarCidade(cidade.id, cidade.nome);
        }

        public void DeletarCidade(Cidade cidade)
        {
            _cidadeDAO.DeletarCidade(cidade);
        }

    }
}
