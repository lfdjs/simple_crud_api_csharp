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

        private CidadeRepositorio _cidadeRepositorio;

        public CidadeController() {
            _cidadeRepositorio = new CidadeRepositorio();
        }

        // GET: api/<CidadeController>
        //[Route("api/[controller]/6GetAllCidades")]
        [HttpGet]
        public JsonResult Get()
        {
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Cidades encontradas",
                data = _cidadeRepositorio.GetCidades

            };
            return new JsonResult(resultado);
        }

        // GET api/<CidadeController>/5
       // [Route("api/[controller]/GetCidadesFiltro")]
        [HttpGet("{nome}")]
        public JsonResult Get([FromBody] Cidade cidade)
        {
            _cidadeRepositorio = new CidadeRepositorio(cidade);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Cidade(s) encontrada(s)",
                data = _cidadeRepositorio.GetCidadesNome

            };
            return new JsonResult(resultado);
        }

        // POST api/<CidadeController>
       // [Route("api/[controller]/InsertCidade")]
        [HttpPost]
        public JsonResult Post([FromBody] Cidade cidade)
        {
           _cidadeRepositorio.InserirCidade(cidade); 
            var resultado = new {
                Sucesso = 1,
                Mensagem = "Adicionado com sucesso"
            }; 
            return new JsonResult(resultado); 
           
        }

        // PUT api/<CidadeController>/5
       // [Route("api/[controller]/UpdateCidade")]
        [HttpPut("{id}")] 
        public JsonResult Put([FromBody] Cidade cidade)
        {
            _cidadeRepositorio.AlterarCidade(cidade);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Alterado com sucesso"

            };
            return new JsonResult(resultado);
        }

        // DELETE api/<CidadeController>/5
      //  [Route("api/[controller]/DeleteCidade")]
        [HttpDelete("{id}")]
       
        public JsonResult Delete(Cidade cidade)
        {
            
            _cidadeRepositorio.DeletarCidade(cidade);
            var resultado = new
            {
                Sucesso = 1,
                Mensagem = "Deletado com sucesso"

            };
            return new JsonResult(resultado);
        }

        
    }
}
