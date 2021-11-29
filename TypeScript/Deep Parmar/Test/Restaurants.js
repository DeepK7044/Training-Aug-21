"use strict";
exports.__esModule = true;
exports.Checkingrooms = exports.SearchRestaurant = exports.RestaurantData = exports.DiningRoomData = exports.TableData = exports.Restaurant = void 0;
var Restaurant = /** @class */ (function () {
    function Restaurant(RestaurantId, RestaurantName, RestaurantAddress, DiningRoom, CountryId) {
        this.RestaurantId = RestaurantId;
        this.RestaurantName = RestaurantName;
        this.RestaurantAddress = RestaurantAddress;
        this.DiningRoom = DiningRoom;
        this.CountryId = CountryId;
    }
    return Restaurant;
}());
exports.Restaurant = Restaurant;
exports.TableData = [
    { "TableId": 1, "TableCapacity": 2, "Isavailable": true },
    { "TableId": 2, "TableCapacity": 4, "Isavailable": true },
    { "TableId": 3, "TableCapacity": 4, "Isavailable": true },
    { "TableId": 4, "TableCapacity": 6, "Isavailable": true },
    { "TableId": 5, "TableCapacity": 4, "Isavailable": true },
    { "TableId": 6, "TableCapacity": 2, "Isavailable": true },
];
exports.DiningRoomData = [
    { "RoomId": 1, "Tables": exports.TableData, "Isavailable": true },
    { "RoomId": 2, "Tables": exports.TableData, "Isavailable": true },
    { "RoomId": 3, "Tables": exports.TableData, "Isavailable": true },
];
exports.RestaurantData = [
    { "RestaurantId": 1, "RestaurantName": "Trupti", "RestaurantAddress": "Maninager", "DiningRoom": exports.DiningRoomData, "CountryId": 1 },
    { "RestaurantId": 2, "RestaurantName": "Trupti", "RestaurantAddress": "Naroda", "DiningRoom": exports.DiningRoomData, "CountryId": 2 },
    { "RestaurantId": 3, "RestaurantName": "Trupti", "RestaurantAddress": "Dahod", "DiningRoom": exports.DiningRoomData, "CountryId": 3 },
];
var Countries;
(function (Countries) {
    Countries[Countries["India"] = 0] = "India";
    Countries[Countries["USA"] = 1] = "USA";
    Countries[Countries["Canada"] = 2] = "Canada";
})(Countries || (Countries = {}));
function SearchRestaurant(CountryId) {
    exports.RestaurantData.filter(function (Restaurants, index, array) {
        if (Restaurants.CountryId == CountryId) {
            console.log(Restaurants);
        }
    });
}
exports.SearchRestaurant = SearchRestaurant;
function Checkingrooms(RestorentId) {
    exports.RestaurantData.filter(function (Restaurants, index, array) {
        if (Restaurants.RestaurantId == RestorentId) {
            console.log("Restorent Name: ".concat(Restaurants.RestaurantName));
            console.log("Restorent RestaurantAddress: ".concat(Restaurants.RestaurantAddress));
            Restaurants.DiningRoom.forEach(function (element) {
                console.log("Dinning Room No: ".concat(element.RoomId));
                console.log('---------------------------------');
                element.Tables.forEach(function (element2) {
                    console.log(element2);
                });
            });
        }
    });
}
exports.Checkingrooms = Checkingrooms;
