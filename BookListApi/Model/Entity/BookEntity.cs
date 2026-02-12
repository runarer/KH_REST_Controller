using System.ComponentModel.DataAnnotations;

namespace BookListApi.Model.Entity;

public class BookEntity
{
    [Key]
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string ISBN { get; set; }
    public required string Author { get; set; }
    public bool Read { get; set; }
    public string? Universe { get; set; }
    public string? Series { get; set; }
}

