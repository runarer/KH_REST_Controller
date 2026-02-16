namespace BookListApi.Model.DTO;

public record BookResponseDTO(int Id, string Name, string ISBN, string Author, bool Read, string? Universe, string? Series, int PositionInSeries);
