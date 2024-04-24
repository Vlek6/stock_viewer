using System.Text.Json.Nodes;

namespace StockViewer.Frontend.Models;

public class StockData
{
    public string? symbol{ get; set; }
    public JsonArray? historical {get; set;}
}
