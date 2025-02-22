// greeting = "Hello TypeScript";
// console.log(greeting); //Prints Hello World!

// import * as Emp from "./Employee"
// console.log(Emp.age); // 20
// let empObj = new Emp.Employee("Bill Gates" , 2);
// empObj.displayEmployee(); 


import {Employee as EmployeeData} from "./Employee"
let obj=new EmployeeData("Deep",7044);
obj.displayEmployee();

// /// <reference path = "Employee.ts" />  
  
// let TotalFee = studentCalc.AnualFeeCalc(1500, 4);  
  
// console.log("Output: " +TotalFee);  


function displayType<T, U>(id:T, name:U): void { 
    console.log(typeof(id) + ", " + typeof(name));  
  }
  
  displayType<number, string>(1, "Steve"); 

  class KeyValuePair<T,U>
{ 
    private key: T;
    private val: U;

    setKeyValue(key: T, val: U): void { 
        this.key = key;
        this.val = val;
    }

    display():void { 
        console.log(`Key = ${this.key}, val = ${this.val}`);
    }
}

let kvp1 = new KeyValuePair<number, string>();
kvp1.setKeyValue(1, "Steve");
kvp1.display(); //Output: Key = 1, Val = Steve 