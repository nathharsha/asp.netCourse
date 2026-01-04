using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new(1,"Ring Rivals","Boxing",33.59M,new DateOnly(2000,2,15)),
    new(2,"Twenty Twenty","Cricket",49.99M,new DateOnly(2011,10,31)),
    new(3,"FIFA","Soccer",21.99M,new DateOnly(2014,11,30))
];

//Get list of games - /games
app.MapGet("games", () => games);

//Get game by ID - /games/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

app.MapGet("games/test", () => "Hello its me again");

// POST /gmaes
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.Release
    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.Release
    );

    return Results.NoContent();
});

app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

app.Run();
