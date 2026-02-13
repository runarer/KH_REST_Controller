

using BookListApi.Model.DTO;
using BookListApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookListController(BookListService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<BookResponseDTO>> GetAsync() => await service.GetAll();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] BookRequestDTO book) => await service.Add(book) is BookResponseDTO newBook ?
                                                                                Created($"api/books/{newBook.Id}", newBook) :
                                                                                StatusCode(500, new { message = "Something when wrong when posting book!" });

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(int id) => await service.Get(id) is BookResponseDTO book ? Ok(book) : NotFound();
}