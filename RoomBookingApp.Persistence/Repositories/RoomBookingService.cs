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
        //var unAvailableRooms = _context.RoomBookings.Where(q => q.Date == date).Select(q => q.RoomId).ToList();
        //var availableRooms = _context.Rooms.Where(q => unAvailableRooms.Contains(q.Id) == false).ToList();
        return _context.Rooms.Where(q => q.RoomBookings.All(x => x.Date != date)).ToList();
    }
}