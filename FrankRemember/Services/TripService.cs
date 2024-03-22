using FrankRemember.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankRemember.Services;

public class TripService
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
