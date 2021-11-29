"use strict";
// Online table reservation in the restaurant for specific date and time. This will
// Provide the list of restaurants in the country so that the user can choose accordingly.
// Provide the list of tables available for online reservation at different dining rooms in the restaurant.
// Mention the number of guests that can be accommodated on the particular table.
// Accept the booking for tables.
// Online table reservations are done 6hrs in advance for the current date.
// Table reservation can be done up to one month in advance.
// Give a token number to the customer as an acknowledgement of booking.
exports.__esModule = true;
var Restaurants = require("./Restaurants");
var Choice = 2;
switch (Choice) {
    // 1.Provide the list of restaurants in the country so that the user can choose accordingly.
    case 1:
        Restaurants.SearchRestaurant(1);
        break;
    case 2:
        //2. Provide the list of tables available for online reservation at different dining rooms in the restaurant.
        Restaurants.Checkingrooms(1);
        break;
    case 3:
        //3. Mention the number of guests that can be accommodated on the particular table.
        // SearchEmpByYearAndCity(2020,3);
        break;
    default:
        break;
}
