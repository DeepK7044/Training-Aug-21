import * as Restaurants from './Restaurants'

interface ITableBooking
{
    BookingId:number;
    BookingDate:Date;
    RestaurantId:number;
}

export class TableBooking implements ITableBooking
{
    BookingId:number;
    BookingDate:Date;
    RestaurantId:number;    

    constructor(BookingId:number,BookingDate:Date,RestaurantId:number) {
        this.BookingId=BookingId;
        this.BookingDate=BookingDate;
        this.RestaurantId=RestaurantId;
    }
}

