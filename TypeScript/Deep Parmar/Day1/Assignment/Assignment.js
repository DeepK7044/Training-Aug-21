// Store 5 employees’ data in one array (ID,FirstName,LastName,Address,Salary). 
// Do the operation searching by indexnumber, EmployeeID, Insert the employee, delete the employee from the Array. 
// Create one more array emp and join the value with above array. 
// When display list combine firstname and lastname as fullname, From the address field flatnumber,city,state and should be splited.
// PF should be computed and total salary should be display.
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
// Store 5 employees’ data in one array
var employee = [
    { "ID": 1, "FirstName": "Deep", "LastName": "Parmar", "Address": "i-401 Ozone city,Ahmedabad,Gujrat", "Salary": 30000 },
    { "ID": 2, "FirstName": "Dhruvesh", "LastName": "Parmar", "Address": "m-1 New maninagar,Ahmedabad,Gujrat", "Salary": 30000 },
    { "ID": 3, "FirstName": "meet", "LastName": "Panchal", "Address": "c-38 ishwernagar society,Ahmedabad,Gujrat", "Salary": 20000 },
    { "ID": 4, "FirstName": "jignesh", "LastName": "Patel", "Address": "a-504 GLiter Society,surat,Gujrat", "Salary": 10000 },
    { "ID": 5, "FirstName": "Darshan", "LastName": "Thakkar", "Address": "L-501 Surya Garden,Botad,Gujrat", "Salary": 15000 }
];
employee.forEach(function (element) {
    console.log(element);
});
// Do the operation searching by indexnumber, EmployeeID, Insert the employee, delete the employee from the Array. 
console.log("-------------searchElement_indexnumber---------------");
var searchElement_indexnumber = employee[1];
console.log(searchElement_indexnumber);
console.log("--------------searchElement_ID--------------");
var searchElement_ID = employee[2].ID;
console.log("ID Of 2rd Employee IS ".concat(searchElement_ID));
console.log("--------------Insert the employee--------------");
var NewEmployee = { "ID": 6, "FirstName": "Ramesh", "LastName": "Patel", "Address": "Gokuldham Society,Vadodra,Gujrat", "Salary": 30000 };
employee.push(NewEmployee);
employee.forEach(function (element) {
    console.log(element);
});
console.log("--------------Delete the employee--------------");
employee.pop();
employee.forEach(function (element) {
    console.log(element);
});
// Create one more array emp and join the value with above array. 
console.log("--------join Array-----------------");
var NewArray = [{ "ID": 6, "FirstName": "Ramesh", "LastName": "Patel", "Address": "Gokuldham Society,Vadodra,Gujrat", "Salary": 30000 }];
// employee=employee.concat(NewArray);
employee = __spreadArray(__spreadArray([], employee, true), NewArray, true);
for (var _i = 0, employee_1 = employee; _i < employee_1.length; _i++) {
    var item = employee_1[_i];
    console.log(item);
}
// When display list combine firstname and lastname as fullname, From the address field flatnumber,city,state and should be splited.
var emptyArray = [];
for (var _a = 0, employee_2 = employee; _a < employee_2.length; _a++) {
    var item = employee_2[_a];
    emptyArray.push({ "ID": item.ID, "Name": item.FirstName + " " + item.LastName, "Address": item.Address.split(","), "Salary": item.Salary, "PF": item.Salary * 0.12 });
}
emptyArray.forEach(function (element) {
    console.log(element);
});
