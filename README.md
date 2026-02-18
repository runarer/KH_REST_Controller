# KH_REST_Controller

## Kjøring

Serveren startes med `dotnet run` og åpnes for testing med http://localhost:5209/scalar.

## Endepunkter

### Liste over alle bøker (GET)

GET http://localhost:5209/api/BookList/

### Legge til en bok (POST)

POST http://localhost:5209/api/BookList/

Forslag til postdata for å legge til en bok.

```json
{
  "name": "Children of Strife",
  "isbn": "978-1-0350-5778-8",
  "author": "Adrian Tchaikovsky",
  "read": false,
  "universe": null,
  "series": "Children of Time",
  "positionInSeries": 4
}
```

`read` kan og være `null`.

Forslag til postdata som gir feilmelding

```json
{
  "name": "Not A real book",
  "isbn": "",
  "author": "",
  "read": false,
  "universe": null,
  "series": "",
  "positionInSeries": -5
}
```

### Hent informasjon on en bok (GET)

http://localhost:5209/api/BookList/12/

### Markere en bok som lest (PATCH)

http://localhost:5209/api/BookList/11/read/

### Markere en bok som ikke lest (PATCH)

http://localhost:5209/api/BookList/11/not-read/

### List alle bøker i en serie (GET)

'http://localhost:5209/api/BookList/series/The Bobiverse trilogy'
