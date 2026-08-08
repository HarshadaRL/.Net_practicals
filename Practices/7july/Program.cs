//datatype varaiblename = value;
//-------- value type
//numeric = int 4, Long 8
//decimal = float 4, double 8, decimal 16
//char 2
//bool 1
//-------- reference type these stores references(memory addr)
// string, object, class, array, interface

// --- Examples ---
// int age = 21;
// double gpa = 8.8;
// string name = "Gitesh Pawar";
// bool isStudent = true;
// long adhar = 111111111111;

// Console.WriteLine($"Name = {name}");
// Console.WriteLine($"Age = {age}");
// Console.WriteLine($"GPA = {gpa}");
// Console.WriteLine($"Is a student= {isStudent}");
// Console.WriteLine($"Adhar= {adhar}");

// Console.WriteLine("Arithmatic Operators");
// int a = 10;
// int b = 20;

// Console.WriteLine($"Addition a + b = {a+b}");
// Console.WriteLine($"Subtraction a - b = {a-b}");
// Console.WriteLine($"Multiplication a * b = {a*b}");
// Console.WriteLine($"division a / b = {(double)a/b}");

// Console.WriteLine("Logical Operatiors");
// bool a1= true;
// bool b1= false;

// Console.WriteLine($"Logical &&  {a1 && b1}");
// Console.WriteLine($"Logical ||  {a1 || b1}");

// Console.WriteLine("Comparision Operatiors");

// Console.WriteLine($"Compare a > b = {a>b}");
// Console.WriteLine($"Compare a < b = {a<b}");
// Console.WriteLine($"Compare a == b = {a==b}");
// Console.WriteLine($"Compare a <= b = {a<=b}");
// Console.WriteLine($"Compare a >= b = {a>=b}");

// Console.WriteLine("Increment Decrement");
// Console.WriteLine($"Post-Increment a++ = {a++}");
// Console.WriteLine($"Post-Derrement a-- = {a--}");
// Console.WriteLine($"Pre-Increment ++a = {++a}");
// Console.WriteLine($"Pre-Decrement --a = {--a}");

int marks = 30;
if (marks >= 90){
    Console.WriteLine($"Marks {marks} Grade : A");
}
else if ( marks >=80){
    Console.WriteLine($"Marks {marks} Grade : B");
}
else if ( marks >=70){
    Console.WriteLine($"Marks {marks} Grade : C");
}
else if ( marks >=60){
    Console.WriteLine($"Marks {marks} Grade : D");
}
else if ( marks >=50){
    Console.WriteLine($"Marks {marks} Grade : E");
}
else if ( marks >=40){
    Console.WriteLine($"Marks {marks} Grade : F");
}
else{
    Console.WriteLine($"Marks {marks} Failed try next time ...");
}



