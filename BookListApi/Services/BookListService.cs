using BookListApi.Model.Context;
using BookListApi.Model.DTO;
using BookListApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookListApi.Services;

public class BookListService(BookListContext dbContext)
{
    public async Task<List<BookResponseDTO>> GetAll() => await dbContext.BookList
        .Select(book => CreateBookResponseDTO(book)
        ).ToListAsync();

    public async Task<BookResponseDTO> Add(BookRequestDTO book)
    {
        var newBook = new BookEntity
        {
            Name = book.Name,
            ISBN = book.ISBN,
            Author = book.Author,
            Read = book.Read is not null && book.Read.Value,
            Universe = book.Universe,
            Series = book.Series
        };
        await dbContext.BookList.AddAsync(newBook);
        await dbContext.SaveChangesAsync();
        return CreateBookResponseDTO(newBook);
    }

    public async Task<BookResponseDTO?> Get(int id)
    {
        var book = await dbContext.BookList.FindAsync(id);

        if (book is null)
            return null;
        return CreateBookResponseDTO(book);
    }

    private static BookResponseDTO CreateBookResponseDTO(BookEntity book)
    {
        return new BookResponseDTO(
            book.Id,
            book.Name,
            book.ISBN,
            book.Author,
            book.Read,
            book.Universe,
            book.Series,
            book.PositionInSeries);
    }
}