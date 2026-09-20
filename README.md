# SerieTracker Backend

REST-API för SerieTracker, byggt med ASP.NET Core Web API. Hanterar serier med full CRUD och serverar data som JSON till frontenden.

## Teknik
- ASP.NET Core Web API (.NET 10)
- C#
- Swagger för dokumentation

## Tekniska val
- **In-memory-lagring** istället för databas. Fokus ligger på API och frontend-integration. Datan återställs vid omstart.
- **Validering** via data annotations (`[Required]`, `[Range]`). Ogiltiga anrop avvisas med 400.
- **CORS** tillåter anrop från frontenden på `http://localhost:5173`.

## Komma igång
```bash
dotnet run
```
API:t startar på `http://localhost:5172`. Swagger finns på `/swagger`.

## Endpoints
- `GET /api/serie` hämta alla
- `POST /api/serie` lägg till
- `PUT /api/serie/{id}` uppdatera (markera som sedd)
- `DELETE /api/serie/{id}` ta bort