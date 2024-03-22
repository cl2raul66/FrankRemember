using FrankRemember.Models;
using LiteDB;

namespace FrankRemember.Services;

public interface ITripService
{
    bool Exist { get; }

    bool Delete(ObjectId id);
    IEnumerable<Trip> GetAll();
    Trip GetAllByDateRange(ObjectId id);
    IEnumerable<Trip> GetAllByEndDateRange(DateTime startDate, DateTime endDate);
    Trip GetAllById(ObjectId id);
    string Insert(Trip Trip);
    bool Update(Trip Trip);
}

public class TripService : ITripService
{
    readonly ILiteCollection<Trip> collection;

    public TripService()
    {
        var cnx = new ConnectionString()
        {
            Filename = Path.Combine(FileSystem.Current.AppDataDirectory, "CargoTrips.db")
        };

        LiteDatabase db = new(cnx);
        collection = db.GetCollection<Trip>();
    }

    public bool Exist => collection.Count() > 0;

    public IEnumerable<Trip> GetAll() => collection.FindAll().Reverse();

    public IEnumerable<Trip> GetAllByEndDateRange(DateTime startDate, DateTime endDate) => collection.Find(Query.And(Query.GTE("EndDate", startDate), Query.LTE("EndDate", endDate)));

    public Trip GetAllById(ObjectId id) => collection.FindById(id);

    public Trip GetAllByDateRange(ObjectId id) => collection.FindById(id);

    public string Insert(Trip Trip)
    {
        try
        {
            return collection.Insert(Trip);
        }
        catch (Exception)
        {

            return string.Empty;
        }
    }

    public bool Update(Trip Trip) => collection.Update(Trip);

    public bool Delete(ObjectId id) => collection.Delete(id);
}
