using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1,"Ring Rivals","Boxing",33.59M,new DateOnly(2000,2,15)),
    new(2,"Twenty Twenty","Cricket",49.99M,new DateOnly(2011,10,31)),
    new(3,"FIFA","Soccer",21.99M,new DateOnly(2014,11,30))
];

//Get list of games - /games
app.MapGet("games", () => games);

//Get game by ID - /games/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

app.Run();
