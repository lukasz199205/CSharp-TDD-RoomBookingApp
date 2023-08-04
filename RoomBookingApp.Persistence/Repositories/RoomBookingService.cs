using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain;

namespace RoomBookingApp.Persistence.Repositories;

public class RoomBookingService : IRoomBookingService
{
    private readonly RoomBookingAppDbContext _context;

    public RoomBookingService(RoomBookingAppDbContext context)
    {
        _context = context;
    }
    public void Save(RoomBooking roomBooking)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Room> GetAvailableRooms(DateTime date)
    {
        throw new NotImplementedException();
    }
}