let isDone: boolean = true;
console.log(isDone);

console.log("------Number-------");

let decimal: number = 6;
console.log(decimal);
let hex: number = 0xf00d;
console.log(hex);
let binary: number = 0b1010;
console.log(binary);
let octal: number = 0o744;
console.log(octal);

console.log("-------String------");

let fullName: string = "Bob Bobbington";
let age: number = 37;
let sentence: string = `Hello, my name is ${fullName}.
 
I'll be ${age + 1} years old next month.`;
console.log(sentence);

console.log("-----Array--------");
let list: number[] = [1, 2, 3];
let list1: Array<number> = [4,5,6];
list.concat(list1);
console.log(list);
console.log(list1);

console.log("-----Tuple--------");
let x:[string,number,string];
x=["Deep",12,"abc"]
console.log(x);
console.log(x[0].substring(0,3));

console.log("-----enum--------");
enum Color {
    Red = 1,
    Green,
    Blue,
  }
  let x1:Color=Color.Red;
  let colorName: string = Color[2];
  
  console.log(x1);
  // Displays 'Green'
  console.log(colorName);

  console.log("------Function------")
  function warnUser(): void {
    console.log("This is my warning message");
  }
  warnUser();

  function reverse(s:string):string{
      return s.split("").reverse().join("");
  }

  console.log(reverse("Deep Parmar"));