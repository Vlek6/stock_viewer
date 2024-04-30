using System.ComponentModel.DataAnnotations;

namespace StockViewer.Frontend.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Login {get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Password {get; set;}
    public List<StockSummary>? Stocks {get; set;}
    public string? GetLogin(){
        return Login;
    }
}
