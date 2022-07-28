using teste_emprego.DAO;
using teste_emprego.Model;

namespace teste_emprego.Repositorio
{
    public class CidadeRepositorio
    {
        private readonly CidadeDAO _cidadeDAO;

        public CidadeRepositorio()
        {
            _cidadeDAO = new CidadeDAO(); ;
        }

        public List<Cidade> GetCidades {
            get {
                return _cidadeDAO.GetCidades();
            }
        }

        public void InserirCidade(Cidade cidade) {
            _cidadeDAO.InserirCidade(cidade);
        }
        public void AlterarCidade(Cidade cidade)
        {
            _cidadeDAO.AlterarCidade(cidade);
        }

        public void DeletarCidade(Cidade cidade)
        {
            _cidadeDAO.DeletarCidade(cidade);
        }

    }
}
