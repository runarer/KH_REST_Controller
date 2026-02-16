using System.ComponentModel.DataAnnotations;

namespace BookListApi.Model.DTO;

public record BookRequestDTO(
    [Required]
    string Name,

    [Required]
    string ISBN,

    [Required]
    string Author,

    bool? Read,

    string? Universe,

    string? Series,

    [Range(0,int.MaxValue)]
    int PositionInSeries
);