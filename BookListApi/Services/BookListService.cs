using BookListApi.Model.Context;
using BookListApi.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookListApi.Services;

public class BookListService(BookListContext dbContext)
{
    public async Task<List<BookResponseDTO>> GetAll() => await dbContext.BookList
        .Select(book =>
            new BookResponseDTO(book.Id,
                                book.Name,
                                book.ISBN,
                                book.Author,
                                book.Read,
                                book.Universe,
                                book.Series)
        ).ToListAsync();
}