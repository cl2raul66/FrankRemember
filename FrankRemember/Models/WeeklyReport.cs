using LiteDB;

namespace FrankRemember.Models;

public class WeeklyReport
{
    public ObjectId? Id { get; set; }
    public List<Trip>? Travel { get; set; }
    public double Toll { get; set; }
}
