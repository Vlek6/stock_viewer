using System.Text.Json.Nodes;

namespace StockViewer.Frontend.Models;

public class StockChartData
{
    public long date { get; set; }
    public decimal open { get; set; }
    public decimal high { get; set; }
    public decimal low { get; set; }
    public decimal close { get; set; }
}
