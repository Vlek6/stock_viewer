using System.ComponentModel.DataAnnotations;

namespace StockViewer.Frontend.Models;

public class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Username {get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Password {get; set;}
    public List<StockSummary>? FollowedStocks {get; set;}
    public string? GetUsername(){
        return Username;
    }
}
