using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core;

public class RoomBookingRequestProcessorTest
{
    private readonly RoomBookingRequestProcessor _processor;

    public RoomBookingRequestProcessorTest()
    {
        _processor = new RoomBookingRequestProcessor();
    }
    [Fact]
    public void Should_Return_Room_Booking_Response_With_Request_Values()
    {
        //Arrange
        var bookingRequest = new RoomBookingRequest
        {
            FullName = "Test Name",
            Email = "test@request.com",
            Date = new DateTime(2021, 10, 20)
        };
        

        //Act
        RoomBookingResult result = _processor.BookRoom(bookingRequest);

        //Assert

        Assert.NotNull(result);
        Assert.Equal(bookingRequest.FullName, result.FullName);
        Assert.Equal(bookingRequest.Email, result.Email);
        Assert.Equal(bookingRequest.Date, result.Date);

        result.ShouldNotBeNull();
        result.FullName.ShouldBe(bookingRequest.FullName);
        result.Email.ShouldBe(bookingRequest.Email);
        result.Date.ShouldBe(bookingRequest.Date);
    }
    
    [Fact]
    public void Should_Throw_Exception_For_Null_Request()
    {
        //Assert.Throws<ArgumentNullException>(() => processor.BookRoom(null));
        var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
        exception.ParamName.ShouldBe("bookingRequest");
    }
}