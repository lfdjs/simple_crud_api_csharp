using Microsoft.AspNetCore.Mvc;
using teste_emprego.Model;
using teste_emprego.Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teste_emprego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly CidadeRepositorio _cidadeRepositorio;

        public CidadeController() {
            _cidadeRepositorio = new CidadeRepositorio();
        }

        // GET: api/<CidadeController>
        [HttpGet]
        public IEnumerable<Cidade> Get()
        {
            return _cidadeRepositorio.GetCidades;
        }

        // GET api/<CidadeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CidadeController>
        [HttpPost]
        public void Post([FromBody] Cidade cidade)
        {
            _cidadeRepositorio.InserirCidade(cidade);
        }

        // PUT api/<CidadeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CidadeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
