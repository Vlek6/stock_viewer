
using StockViewer.Frontend.Models;


namespace StockViewer.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    private readonly List<GameSummary> games = [
    new(){
            Id=1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1992, 7, 15)
        },
        new(){
            Id=2,
            Name = "League of Legends",
            Genre = "MOBA",
            Price = 25.99M,
            ReleaseDate = new DateOnly(2007, 2, 19)
        },
        new(){
            Id=3,
            Name = "The Elder Scrolls V: Skyrim",
            Genre = "RPG",
            Price = 30.99M,
            ReleaseDate = new DateOnly(2004, 6, 15)
        }
];

    private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();
    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        var GameSummary = new GameSummary()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(GameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);
        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));
        return new GameDetails
        {
            Id = id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    }

    public void UpdateGame(GameDetails updatedGame){
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);
        
        existingGame.Name = updatedGame.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate; 
        existingGame.Genre = genre.Name;

    }

    public void DeleteGameById(int Id){
        var game = GetGameSummaryById(Id);
        games.Remove(game);
    }
    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? Id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Id);
        var genre = genres.Single(genre => genre.Id == int.Parse(Id));
        return genre;
    }


}
