using System.Threading.Tasks;
using EntityFrameworkCore.Model.Data;
using EntityFrameworkCore.Model.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
{
    [Route("[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly MeuDbContext _context;

        public ContatoController(MeuDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public void Index()
        {

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> Get(int id)
        {
            var contato = await _context.ObterContato(id);

            if (contato == null)
                NotFound();

            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Post([FromBody] Contato contato)
        {
            var retorno = await _context.GravarContato(contato);
            return Ok(retorno);
        }

        [HttpPut]
        public async Task<ActionResult<Contato>> Put([FromBody] Contato contato)
        {
            var retorno = await _context.AtualizaContato(contato);
            return Ok(retorno);
        }

        [HttpDelete]
        public async Task<ActionResult<Contato>> Delete([FromBody] Contato contato)
        {
            var retorno = await _context.RemoveContato(contato);
            return Ok(retorno);
        }
    }
}