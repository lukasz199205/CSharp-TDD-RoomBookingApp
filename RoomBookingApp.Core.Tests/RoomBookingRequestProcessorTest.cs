﻿using Moq;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core;

public class RoomBookingRequestProcessorTest
{
    private readonly RoomBookingRequestProcessor _processor;
    private readonly RoomBookingRequest _bookingRequest;
    private readonly Mock<IRoomBookingService> _roomBookingServiceMock;

    public RoomBookingRequestProcessorTest()
    {
        //Arrange
        _bookingRequest = new RoomBookingRequest
        {
            FullName = "Test Name",
            Email = "test@request.com",
            Date = new DateTime(2021, 10, 20)
        };
        
        _roomBookingServiceMock = new Mock<IRoomBookingService>();
        _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        
    }
    [Fact]
    public void Should_Return_Room_Booking_Response_With_Request_Values()
    {
        //Act
        RoomBookingResult result = _processor.BookRoom(_bookingRequest);

        //Assert

        Assert.NotNull(result);
        Assert.Equal(_bookingRequest.FullName, result.FullName);
        Assert.Equal(_bookingRequest.Email, result.Email);
        Assert.Equal(_bookingRequest.Date, result.Date);

        result.ShouldNotBeNull();
        result.FullName.ShouldBe(_bookingRequest.FullName);
        result.Email.ShouldBe(_bookingRequest.Email);
        result.Date.ShouldBe(_bookingRequest.Date);
    }
    
    [Fact]
    public void Should_Throw_Exception_For_Null_Request()
    {
        //Assert.Throws<ArgumentNullException>(() => processor.BookRoom(null));
        var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
        exception.ParamName.ShouldBe("bookingRequest");
    }
    
    [Fact]
    public void Should_Save_Room_Booking_Request()
    {
        RoomBooking savedBooking = null;
        _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
            .Callback<RoomBooking>(booking =>
            {
                savedBooking = booking;
            });
        
        _processor.BookRoom(_bookingRequest);

        _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once);

        savedBooking.ShouldNotBeNull();
        savedBooking.FullName.ShouldBe(_bookingRequest.FullName);
        savedBooking.Email.ShouldBe(_bookingRequest.Email);
        savedBooking.Date.ShouldBe(_bookingRequest.Date);
    }
}