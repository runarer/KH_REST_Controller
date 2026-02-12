
using BookListApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookListApi.Model.Context;

public class BookListContext(DbContextOptions<BookListContext> options) : DbContext(options)
{
    public DbSet<BookEntity> BookList => Set<BookEntity>();
}