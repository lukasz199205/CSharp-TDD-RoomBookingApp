using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Moq;
using RoomBookingApp.Api.Controllers;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Api.Tests;

public class RoomBookingControllerTests
{
    private readonly Mock<IRoomBookingRequestProcessor> _roomBookingProcessor;
    private readonly RoomBookingController _controller;
    private readonly RoomBookingRequest _request;
    private readonly RoomBookingResult _result;

    public RoomBookingControllerTests()
    {
        _roomBookingProcessor = new Mock<IRoomBookingRequestProcessor>();
        _controller = new RoomBookingController(_roomBookingProcessor.Object);
        _request = new RoomBookingRequest();
        _result = new RoomBookingResult();

        _roomBookingProcessor.Setup(x => x.BookRoom(_request)).Returns(_result);
    }

    [Theory]
    [InlineData(1, true, typeof(OkObjectResult))]
    [InlineData(0, false, typeof(BadRequestObjectResult))]
    public async Task Should_Call_Booking_Method_When_Valid(int expectedMethodCalls, bool isModelValid,
        Type expectedActionRestulType)
    {
        //Arrange
        if (!isModelValid)
        {
            _controller.ModelState.AddModelError("Key", "Error Message");
        }
        
        //Act
        var result = await _controller.BookRoom(_request);
        
        //Assert
        result.ShouldBeOfType(expectedActionRestulType);
        _roomBookingProcessor.Verify(x => x.BookRoom(_request), Times.Exactly(expectedMethodCalls));
    }
}