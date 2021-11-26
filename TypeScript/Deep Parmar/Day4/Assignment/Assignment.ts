// Store 5 Employee Data(ID,Name,City,DOJ) in one Array. Search the employee with ID.
// Search the employees who has joined after year 2020
// Search the employee who has joined after year 2020 and stays in Mumbai city

let CityName=new Map();
CityName.set(1,"Ahmedabad")
CityName.set(2,"Botad")
CityName.set(3,"Mumbai");

interface IEmployee
{
    ID:number;
    Name:string;
    City:string;
    DOJ:Date;
}

//Employee Array
let Employee:IEmployee[]=[
    {ID:1,Name:"Deep",City:CityName.get(1),DOJ:new Date("2021-01-16")},
    {ID:2,Name:"Pintu",City:CityName.get(2),DOJ:new Date("2018-01-16")},
    {ID:3,Name:"Dhruvesh",City:CityName.get(1),DOJ:new Date("2021-01-16")},
    {ID:4,Name:"Heer",City:CityName.get(3),DOJ:new Date("2021-01-16")},
    {ID:5,Name:"Mahi",City:CityName.get(3),DOJ:new Date("2020-01-16")}
];

function SearchEmployee(EmpId:number)
{
    Employee.filter((Employee,index,array)=>{
        if(Employee.ID==EmpId)
        {
            console.log(Employee);
        }
    });
}

function SearchEmpByYear(year:number)
{
    Employee.filter((Employee,index,array)=>{
        if(Employee.DOJ.getFullYear()>year)
        {
            console.log(Employee);
        }
    });
}

function SearchEmpByYearAndCity(year:number,City:number)
{
    Employee.filter((Employee,index,array)=>{
        if(Employee.DOJ.getFullYear()>year && Employee.City==CityName.get(City))
        {
            console.log(Employee);
        }
    });
}

//1. Search the employee with ID.
//2. Search the employees who has joined after year 2020
//3. Search the employee who has joined after year 2020 and stays in Mumbai city

let Choice:number=3;

switch (Choice) {
    case 1:
        SearchEmployee(1);
        break;
    case 2:
        SearchEmpByYear(2020);
        break;
    case 3:
        SearchEmpByYearAndCity(2020,3);
        break;

    default:
        break;
}