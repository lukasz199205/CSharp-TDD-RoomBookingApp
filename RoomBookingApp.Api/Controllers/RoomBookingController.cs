using Microsoft.AspNetCore.Mvc;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomBookingController : ControllerBase
{
    private readonly IRoomBookingRequestProcessor _roomBookingRequestProcessor;

    public RoomBookingController(IRoomBookingRequestProcessor roomBookingRequestProcessor)
    {
        _roomBookingRequestProcessor = roomBookingRequestProcessor;
    }

    public async Task<IActionResult> BookRoom(RoomBookingRequest request)
    {
        throw new NotImplementedException();
    }
}