﻿namespace RoomBookingApp.Core;

public class RoomBookingRequestProcessor
{
    public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
    {
        return new RoomBookingResult
        {
            FullName = bookingRequest.FullName,
            Email = bookingRequest.Email,
            Date = bookingRequest.Date
        };
    }
}