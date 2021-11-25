// var greeting : string = "Hello World!";
// export let age : number = 20;
// export class Employee {
//     empCode: number;
//     empName: string;
//     constructor(name: string, code: number) {
//         this.empName = name;
//         this.empCode = code;
//     }
//     displayEmployee() {
//         console.log ("Employee Code: " + this.empCode + ", Employee Name: " + this.empName );
//     }
// }
// let companyName:string = "XYZ";
// var employeeSalary:number=30000;
var studentCalc;
(function (studentCalc) {
    function AnualFeeCalc(feeAmount, term) {
        return feeAmount * term;
    }
    studentCalc.AnualFeeCalc = AnualFeeCalc;
})(studentCalc || (studentCalc = {}));
