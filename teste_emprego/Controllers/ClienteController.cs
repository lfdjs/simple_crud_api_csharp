using Microsoft.AspNetCore.Mvc;
using teste_emprego.Model;
using teste_emprego.Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teste_emprego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteRepositorio _clienteRepositorio;

        public ClienteController()
        {
            _clienteRepositorio = new ClienteRepositorio();
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public JsonResult Get()
        {
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Clientes encontradas",
                data = _clienteRepositorio.GetClientes

            };
            return new JsonResult(resultado);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{nome}")]
        public JsonResult Get([FromBody] Cliente Cliente)
        {
            _clienteRepositorio = new ClienteRepositorio(Cliente);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Cliente(s) encontrada(s)",
                data = _clienteRepositorio.GetClientesNome

            };
            return new JsonResult(resultado);
        }


        // POST api/<ClienteController>
        [HttpPost]
        public JsonResult Post([FromBody] Cliente Cliente)
        {
            _clienteRepositorio.InserirCliente(Cliente);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Adicionado com sucesso"
            };
            return new JsonResult(resultado);

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] Cliente Cliente)
        {
            _clienteRepositorio.AlterarCliente(Cliente);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Alterado com sucesso"

            };
            return new JsonResult(resultado);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Cliente Cliente)
        {

            _clienteRepositorio.DeletarCliente(Cliente);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Deletado com sucesso"

            };
            return new JsonResult(resultado);
        }
    }
}
