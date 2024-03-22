using LiteDB;

namespace FrankRemember.Models;

public class Trip
{
    public ObjectId? Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Toll { get; set; }
    public double Freight { get; set; }
    public List<Fuel>? FuelDetail { get; set; }
    public bool IsCancelled { get; set; }
}
