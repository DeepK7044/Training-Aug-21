// ----------------Optional Parameters----------------
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
function Greet(greeting, name) {
    return greeting + ' ' + name + '!';
}
Greet('Hello', 'Steve'); //OK, returns "Hello Steve!"
Greet('Hi');
// Greet('Hi','Bill','Gates'); //Compiler Error: Expected 2 arguments, but got 3.
// ----------------Default Parameters----------------
function Greet1(name, greeting) {
    if (greeting === void 0) { greeting = "Hello"; }
    return greeting + ' ' + name + '!';
}
Greet1('Steve'); //OK, returns "Hello Steve!"
Greet1('Steve', 'Hi'); // OK, returns "Hi Steve!".
Greet1('Bill'); //OK, returns "Hello Bill!"
//-------------------------enum-----------------------
var PrintMedia;
(function (PrintMedia) {
    PrintMedia[PrintMedia["Newspaper"] = 1] = "Newspaper";
    PrintMedia[PrintMedia["Newsletter"] = 2] = "Newsletter";
    PrintMedia[PrintMedia["Magazine"] = 3] = "Magazine";
    PrintMedia[PrintMedia["Book"] = 4] = "Book";
})(PrintMedia || (PrintMedia = {}));
PrintMedia.Magazine; // returns  3
PrintMedia["Magazine"]; // returns  3
PrintMedia[3]; // returns  Magazine
// ----------------------Union---------------------------
function displayType(code) {
    if (typeof (code) === "number")
        console.log('Code is number.');
    else if (typeof (code) === "string")
        console.log('Code is string.');
}
displayType(123); // Output: Code is number.
displayType("ABC"); // Output: Code is string.
var kv1 = { key: 1, value: "Steve" };
console.log(typeof (kv1));
;
function addKeyValue(key, value) {
    console.log('addKeyValue: key = ' + key + ', value = ' + value);
}
function updateKeyValue(key, value) {
    console.log('updateKeyValue: key = ' + key + ', value = ' + value);
}
var kvp = addKeyValue;
kvp(1, 'Bill'); //Output: addKeyValue: key = 1, value = Bill 
kvp = updateKeyValue;
kvp(2, 'Steve'); //Output: updateKeyValue: key = 2, value = Steve 
var empObj1 = {
    empCode: 1,
    empName: "Steve"
};
var Employee1 = /** @class */ (function () {
    function Employee1(empcode, name) {
        this.empCode = empcode;
        this.name = name;
    }
    Employee1.prototype.display = function () {
        console.log("Name = " + this.name + ", Employee Code = " + this.empCode);
    };
    return Employee1;
}());
var per = new Employee1(12, "Deep");
per.display();
// let per:IPerson = new Employee(100, "Bill");
// per.display(); // Name = Bill, Employee Code = 100
// let emp:IEmployee = new Employee(100, "Bill");
// emp.display();
// -----------------------------Inheritance---------------------------
var Person = /** @class */ (function () {
    function Person(name) {
        this.name = name;
    }
    return Person;
}());
var Employees = /** @class */ (function (_super) {
    __extends(Employees, _super);
    function Employees(empcode, name) {
        var _this = _super.call(this, name) || this;
        _this.empCode = empcode;
        return _this;
    }
    Employees.prototype.displayName = function () {
        console.log("Name = " + this.name + ", Employee Code = " + this.empCode);
    };
    return Employees;
}(Person));
var emp = new Employees(100, "Bill");
emp.displayName(); // Name = Bill, Employee Code = 100
// ----------------------Interface extends Class----------------------
var Person1 = /** @class */ (function () {
    function Person1() {
    }
    return Person1;
}());
var empobj = { empCode: 1, name: "James Bond" };
// -----------------Method Overriding--------------------------
var Car = /** @class */ (function () {
    function Car(name) {
        this.name = name;
    }
    Car.prototype.run = function (speed) {
        if (speed === void 0) { speed = 0; }
        console.log("A " + this.name + " is moving at " + speed + " mph!");
    };
    return Car;
}());
var Mercedes = /** @class */ (function (_super) {
    __extends(Mercedes, _super);
    function Mercedes(name) {
        return _super.call(this, name) || this;
    }
    Mercedes.prototype.run = function (speed) {
        if (speed === void 0) { speed = 150; }
        console.log('A Mercedes started');
        _super.prototype.run.call(this, speed);
    };
    return Mercedes;
}(Car));
var Honda = /** @class */ (function (_super) {
    __extends(Honda, _super);
    function Honda(name) {
        return _super.call(this, name) || this;
    }
    Honda.prototype.run = function (speed) {
        if (speed === void 0) { speed = 100; }
        console.log('A Honda started');
        _super.prototype.run.call(this, speed);
    };
    return Honda;
}(Car));
var mercObj = new Mercedes("Mercedes-Benz GLA");
var hondaObj = new Honda("Honda City");
mercObj.run(); // A Mercedes started A Mercedes-Benz GLA is moving at 150 mph!
hondaObj.run(); // A Honda started A Honda City is moving at 100 mph!
