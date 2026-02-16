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
            Universe = string.IsNullOrWhiteSpace(book.Universe) ? null : book.Universe,
            Series = string.IsNullOrWhiteSpace(book.Series) ? null : book.Series,
            PositionInSeries = book.PositionInSeries
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

    public async Task<BookResponseDTO?> Completed(int id, bool completed)
    {
        var book = await dbContext.BookList.FindAsync(id);

        if (book is null)
            return null;

        book.Read = completed;
        await dbContext.SaveChangesAsync();
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