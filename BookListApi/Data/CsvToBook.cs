using BookListApi.Model.DTO;

namespace BookListApi.Data;

public static class CsvToBook
{
    public static BookRequestDTO ParseLine(string line)
    {
        string[] parts = line.Split(',');

        int.TryParse(parts[4], out int positionInSeries);

        return new BookRequestDTO(parts[0], parts[1], parts[5], false, parts[2], parts[3], positionInSeries);
    }
}