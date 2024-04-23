using StockViewer.Frontend.Models;

namespace StockViewer.Frontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    private readonly Genre[] genres = [
        new (){
            Id = 1,
            Name= "Fighting"
        },
        new (){
            Id = 2,
            Name= "RPG"
        },
        new (){
            Id = 3,
            Name= "MOBA"
        },
        new (){
            Id = 4,
            Name= "Sports"
        }
    ];

    public Genre[] GetGenres() => genres;

}
