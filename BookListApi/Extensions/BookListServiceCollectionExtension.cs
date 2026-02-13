
using BookListApi.Model.Context;
using BookListApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Extensions;

public static class BookListServiceCollectionExtension
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddBookListService(IConfiguration configuration)
        {
            collection.AddDbContext<BookListContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            collection.AddTransient<BookListService>();
            return collection;
        }
    }
}