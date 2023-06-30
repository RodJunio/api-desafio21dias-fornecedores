using api_desafio21dias.Servicos;
using api_desafio21dias_fornecedores.Models;
using EntityFrameworkPaginateCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    public class MateriaisController : ControllerBase
    {
        private readonly DbContexto _context;
        private const int QUANTIDADE_POR_PAGINA = 3;

        public MateriaisController(DbContexto context)
        {
            _context = context;
        }

        // GET: /materiais
        [HttpGet]
        [Route("/materiais")]
        public async Task<IActionResult> Index(int page = 1)
        {

            return StatusCode(200, await _context.Materiais.OrderByDescending(a => a.Id).PaginateAsync(page, QUANTIDADE_POR_PAGINA));
        }

        // GET: /materiais/5
        [HttpGet]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Materiais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return StatusCode(200, aluno);
        }

        // POST: /materiais
        [HttpPost]
        [Route("/materiais")]
        public async Task<IActionResult> Create(Material aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return StatusCode(201, aluno);
        }

        // PUT: /materiais/5
        [HttpPut]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Notas")] Material aluno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    aluno.Id = id;
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(aluno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, aluno);
            }
            return StatusCode(200, aluno);
        }

        // DELETE: /materiais/5
        [HttpDelete]
        [Route("/materiais/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Materiais.FindAsync(id);
            _context.Materiais.Remove(aluno);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(e => e.Id == id);
        }
    }
}