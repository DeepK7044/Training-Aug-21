import {Table} from './Table'
import * as DiningRooms from './DiningRoom';
import * as Restaurants from './Restaurants';
import * as Reservation from './TableReservation';

interface IRestaurant
{
    RestaurantId:number;
    RestaurantName:string;
    RestaurantAddress:string;
    DiningRoom:DiningRooms.DiningRoom[];
    CountryId:number;
}

export class Restaurant implements IRestaurant
{
    RestaurantId:number;
    RestaurantName:string;
    RestaurantAddress:string;
    DiningRoom:DiningRooms.DiningRoom[];
    CountryId:number;

    constructor(RestaurantId:number,RestaurantName:string,RestaurantAddress:string,DiningRoom:DiningRooms.DiningRoom[],CountryId:number) 
    {
        this.RestaurantId=RestaurantId;
        this.RestaurantName=RestaurantName;
        this.RestaurantAddress=RestaurantAddress;
        this.DiningRoom=DiningRoom;
        this.CountryId=CountryId;
    }
}

export var TableData:Table[]=[
    {"TableId":1,"TableCapacity":2,"Isavailable":true},
    {"TableId":2,"TableCapacity":4,"Isavailable":true},
    {"TableId":3,"TableCapacity":4,"Isavailable":true},
    {"TableId":4,"TableCapacity":6,"Isavailable":true},
    {"TableId":5,"TableCapacity":4,"Isavailable":true},
    {"TableId":6,"TableCapacity":2,"Isavailable":true},
]

export var DiningRoomData:DiningRooms.DiningRoom[]=[
    {"RoomId":1,"Tables":TableData,"Isavailable":true},
    {"RoomId":2,"Tables":TableData,"Isavailable":true},
    {"RoomId":3,"Tables":TableData,"Isavailable":true},
]


export var RestaurantData:Restaurants.Restaurant[]=[
    {"RestaurantId":1,"RestaurantName":"Trupti","RestaurantAddress":"Maninager","DiningRoom":DiningRoomData,"CountryId":1},
    {"RestaurantId":2,"RestaurantName":"Trupti","RestaurantAddress":"Naroda","DiningRoom":DiningRoomData,"CountryId":2},
    {"RestaurantId":3,"RestaurantName":"Trupti","RestaurantAddress":"Dahod","DiningRoom":DiningRoomData,"CountryId":3},
]

enum Countries{
    India,
    USA,
    Canada
}


export function SearchRestaurant(CountryId:number)
{
    RestaurantData.filter((Restaurants,index,array)=>{
        if (Restaurants.CountryId==CountryId) {
            console.log(Restaurants);
        }
    })
}

export function Checkingrooms(RestorentId:number)
{
    RestaurantData.filter((Restaurants,index,array)=>{
        if (Restaurants.RestaurantId==RestorentId) {
            console.log(`Restorent Name: ${Restaurants.RestaurantName}`)
            console.log(`Restorent RestaurantAddress: ${Restaurants.RestaurantAddress}`)
            Restaurants.DiningRoom.forEach(element => {
                console.log(`Dinning Room No: ${element.RoomId}`);
                console.log('---------------------------------');
                element.Tables.forEach(element2 => {
                    console.log(element2);
                });
            });
        }
    })
}

function BookTable(RestorentId:number,DinningRoomNo:number,TableId:number)
{
    RestaurantData.filter((Restaurants,index,array)=>{
        if (Restaurants.RestaurantId==RestorentId) {
            Restaurants.DiningRoom.forEach(element => {
                element.Tables.forEach(element2 => {
                    if(element2.Isavailable)
                    {
                        element2.Isavailable=false;
                        console.log("Thank You For Booking..");
                    }
                    else
                    {
                        console.log("Please Select Available Table");
                    }
                });
            });
        }
    })
}



export function CheckValidBooking(BookingDat:string):number
{
    let CurrentDateTime:Date=new Date();
    let Month=CurrentDateTime.getMonth()+1 ;
    let Day=CurrentDateTime.getDay();
    let afterHours=CurrentDateTime.getHours();
    let BookingDate=new Date(BookingDat);
    if((BookingDate.getMonth()-Month)>=1)
    {
        console.log("Please wait for some times");
    }
    else if((BookingDate.getDay()==Day))
    {
        if((BookingDate.getHours()-afterHours)<6)
        {
            console.log("You are Late For booking");
        }else{
            BookTable(1,1,2);
            return(112);
        }
    }
}



