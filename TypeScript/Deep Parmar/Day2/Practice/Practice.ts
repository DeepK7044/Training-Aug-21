
// ----------------Optional Parameters----------------

function Greet(greeting: string, name?: string ) : string { 
    return greeting + ' ' + name + '!';
}

Greet('Hello','Steve');//OK, returns "Hello Steve!"
Greet('Hi'); 
// Greet('Hi','Bill','Gates'); //Compiler Error: Expected 2 arguments, but got 3.


// ----------------Default Parameters----------------
function Greet1(name: string, greeting: string = "Hello") : string {
    return greeting + ' ' + name + '!';
}

Greet1('Steve');//OK, returns "Hello Steve!"
Greet1('Steve', 'Hi'); // OK, returns "Hi Steve!".
Greet1('Bill'); //OK, returns "Hello Bill!"

//-------------------------enum-----------------------
enum PrintMedia {
    Newspaper = 1,
    Newsletter,
    Magazine,
    Book
  }
  
  PrintMedia.Magazine;   // returns  3
  PrintMedia["Magazine"];// returns  3
  PrintMedia[3];         // returns  Magazine

// ----------------------Union---------------------------
  function displayType(code: (string | number))
{
    if(typeof(code) === "number")
        console.log('Code is number.')
    else if(typeof(code) === "string")
        console.log('Code is string.')
}

displayType(123); // Output: Code is number.
displayType("ABC"); // Output: Code is string.
// displayType(true); //Compiler Error: Argument of type 'true' is not assignable to a parameter of type string | number
// ----------------Interface----------------
interface KeyPair {
    key: number;
    value: string;
}

let kv1: KeyPair = { key:1, value:"Steve" }; 

console.log(typeof(kv1));

// ----------Interface as Function Type------------
interface KeyValueProcessor
{
    (key: number, value: string): void;
};

function addKeyValue(key:number, value:string):void { 
    console.log('addKeyValue: key = ' + key + ', value = ' + value)
}

function updateKeyValue(key: number, value:string):void { 
    console.log('updateKeyValue: key = '+ key + ', value = ' + value)
}
    
let kvp: KeyValueProcessor = addKeyValue;
kvp(1, 'Bill'); //Output: addKeyValue: key = 1, value = Bill 

kvp = updateKeyValue;
kvp(2, 'Steve'); //Output: updateKeyValue: key = 2, value = Steve 


// --------------------Optional Property--------------------

interface IEmployeeData {
    empCode: number;
    empName: string;
    empDept?:string;
}

let empObj1:IEmployeeData = {   // OK
    empCode:1,
    empName:"Steve"
}


// --------------------Multiple interface use--------------------
interface IPerson {
    name: string;
    display():void;
}

interface IEmployee {
    empCode: number;
}

class Employee1 implements IPerson, IEmployee {
    empCode: number;
    name: string;
    
    constructor(empcode: number, name:string) {
        this.empCode = empcode;
        this.name = name;
    }
    
    display(): void {
        console.log("Name = " + this.name +  ", Employee Code = " + this.empCode);
    }
}

let per:Employee1=new Employee1(12,"Deep");
per.display();

// let per:IPerson = new Employee(100, "Bill");
// per.display(); // Name = Bill, Employee Code = 100

// let emp:IEmployee = new Employee(100, "Bill");
// emp.display();

// -----------------------------Inheritance---------------------------
class Person {
    name: string;
    
    constructor(name: string) {
        this.name = name;
    }
}

class Employees extends Person {
    empCode: number;
    
    constructor(empcode: number, name:string) {
        super(name);
        this.empCode = empcode;
    }
    
    displayName():void {
        console.log("Name = " + this.name +  ", Employee Code = " + this.empCode);
    }
}

let emp = new Employees(100, "Bill");
emp.displayName(); // Name = Bill, Employee Code = 100

// ----------------------Interface extends Class----------------------
class Person1 {
    name: string;
}

interface IEmployee extends Person1 { 
    empCode: number;
}

let empobj: IEmployee = { empCode  : 1, name:"James Bond" }


// -----------------Method Overriding--------------------------
class Car {
    name: string;
        
    constructor(name: string) {
        this.name = name;
    }
    
    run(speed:number = 0) {
        console.log("A " + this.name + " is moving at " + speed + " mph!");
    }
}

class Mercedes extends Car {
    
    constructor(name: string) {
        super(name);
    }
    
    run(speed = 150) {
        console.log('A Mercedes started')
        super.run(speed);
    }
}

class Honda extends Car {
    
    constructor(name: string) {
        super(name);
    }
    
    run(speed = 100) {
        console.log('A Honda started')
        super.run(speed);
    }
}

let mercObj = new Mercedes("Mercedes-Benz GLA");
let hondaObj = new Honda("Honda City")

mercObj.run();  // A Mercedes started A Mercedes-Benz GLA is moving at 150 mph!
hondaObj.run(); // A Honda started A Honda City is moving at 100 mph!