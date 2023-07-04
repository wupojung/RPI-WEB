using RPI_Web.Models;

namespace RPI_Web.Services;

public class VoltageService
{
    public static List<VoltageModel> _db;

    static VoltageService()
    {
        _db = new List<VoltageModel>();
        _db.Add(new VoltageModel() { Id = 1, Name = "總電源" });
        _db.Add(new VoltageModel() { Id = 2, Name = "廚房用電" });
    }

    public List<VoltageModel> List()
    {
        return _db;
    }

    public VoltageModel Get(int id)
    {
        VoltageModel result = null;
        
        var fromDb = from f in _db
            where f.Id == id
            select f;

        if (fromDb.Any())
        {
            result = fromDb.FirstOrDefault();
        }
        
        return result;
    }
}