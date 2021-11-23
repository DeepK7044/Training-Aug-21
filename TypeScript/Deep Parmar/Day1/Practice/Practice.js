var isDone = true;
console.log(isDone);
console.log("------Number-------");
var decimal = 6;
console.log(decimal);
var hex = 0xf00d;
console.log(hex);
var binary = 10;
console.log(binary);
var octal = 484;
console.log(octal);
console.log("-------String------");
var fullName = "Bob Bobbington";
var age = 37;
var sentence = "Hello, my name is ".concat(fullName, ".\n \nI'll be ").concat(age + 1, " years old next month.");
console.log(sentence);
console.log("-----Array--------");
var list = [1, 2, 3];
var list1 = [1, 2, 3];
console.log(list);
console.log(list1);
console.log("-----Tuple--------");
var x;
x = ["Deep", 12, "abc"];
console.log(x);
console.log(x[0].substring(0, 3));
console.log("-----enum--------");
var Color;
(function (Color) {
    Color[Color["Red"] = 1] = "Red";
    Color[Color["Green"] = 2] = "Green";
    Color[Color["Blue"] = 3] = "Blue";
})(Color || (Color = {}));
var x1 = Color.Red;
var colorName = Color[2];
console.log(x1);
// Displays 'Green'
console.log(colorName);
console.log("------Function------");
function warnUser() {
    console.log("This is my warning message");
}
warnUser();
function reverse(s) {
    return s.split("").reverse().join("");
}
console.log(reverse("Deep Parmar"));
