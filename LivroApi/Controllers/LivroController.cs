using CP2.Business;
using LivroModel;

using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _livroService;

    public LivrosController(LivroService livroService)
    {
        _livroService = livroService;
    }

    // GET: api/livros
    [HttpGet]
    public IActionResult Get()
    {
        var livros = _livroService.ListarTodos();
        if (!livros.Any())
            return NoContent();

        return Ok(livros);
    }

    // GET: api/livros/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var livro = _livroService.ObterPorId(id);
        if (livro == null)
            return NotFound();

        return Ok(livro);
    }


    // POST: api/livros
    [HttpPost]
    public IActionResult Post([FromBody] Livro livro)
    {
        if (livro == null || string.IsNullOrWhiteSpace(livro.Titulo))
            return BadRequest("Dados inválidos. Título é obrigatório.");

        var novoLivro = _livroService.Criar(livro);
        return CreatedAtAction(nameof(GetById), new { id = novoLivro.Id }, novoLivro);
    }

    // PUT: api/livros/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Livro livro)
    {
        if (livro == null || id != livro.Id)
            return BadRequest("Dados inconsistentes.");

        var atualizado = _livroService.Atualizar(livro);
        return atualizado ? NoContent() : NotFound();
    }

    // DELETE: api/livros/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var removido = _livroService.Remover(id);
        return removido ? NoContent() : NotFound();
    }
}