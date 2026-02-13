namespace BookListApi.Model.DTO;

public record BookRequestDTO(string Name, string ISBN, string Author, bool? Read, string? Universe, string? Series);