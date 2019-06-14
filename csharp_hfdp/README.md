# csharp-hfdp
Head First Design Patterns Implementation in C#

### Design Principles
1. Identify the aspects of your application that vary and separate them from what stays the same.
    
    Take the parts that vary and encapsulate them, so that later you can alter or extend the
    parts that vary without affecting those that don't.

2. Program to an interface, not an implementation.

    "Program to an interface" really means "Program to a supertype."
    * Programming to an implementation. e.g.
        > Dog d = new Dog();
        > d.bark();
    * Programming to an interface/supertype.
        > Animal animal = new Dog();
        > animal.makeSound();
    * Assign the concrete implementation at runtime.
        > a = getAnimal();
        > animal.makeSound();

3. Favor composition over inheritance.
	
	HAS-A can be better than IS-A

### Design Patterns
1. The Strategy Pattern 
	> Defines a family of algorithms, encapsulates each one, makes them interchangeable.
	> Strategy lets the algorithm vary independently from clients that use it.