"use strict";
exports.__esModule = true;
var TableBooking = /** @class */ (function () {
    function TableBooking(BookingId, BookingDate, RestaurantId, UserID) {
        this.BookingId = BookingId;
        this.BookingDate = BookingDate;
        this.RestaurantId = RestaurantId;
        this.UserId = UserID;
    }
    return TableBooking;
}());
// function CheckValidBooking(TableBookingDate:Date):boolean
// {
//     let CurrentDateTime:Date=new Date();
//     if(CurrentDateTime.getMonth()+1<=TableBookingDate.getMonth())
//     {
//     }
// }
