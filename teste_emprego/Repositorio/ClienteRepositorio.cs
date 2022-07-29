using teste_emprego.DAO;
using teste_emprego.Model;

namespace teste_emprego.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly ClienteDAO _ClienteDAO;
        private readonly Cliente _Cliente;



        public ClienteRepositorio()
        {
            _ClienteDAO = new ClienteDAO(); 
        }

        public ClienteRepositorio(Cliente Cliente)
        {
            _Cliente = Cliente;
            _ClienteDAO = new ClienteDAO(); 
        }

        public List<Cliente> GetClientes
        {
            get
            {
                return _ClienteDAO.GetClientes();
            }
        }

        public List<Cliente> GetClientesNome => _ClienteDAO.GetClientes(_Cliente);

        public void InserirCliente(Cliente Cliente)
        {
            _ClienteDAO.InserirCliente(Cliente);
        }
        public void AlterarCliente(Cliente Cliente)
        {
            _ClienteDAO.AlterarCliente(Cliente.id, Cliente.nome, Cliente.telefone);
        }

        public void DeletarCliente(Cliente Cliente)
        {
            _ClienteDAO.DeletarCliente(Cliente);
        }
    }
}
