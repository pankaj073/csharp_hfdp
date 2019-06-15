# C# Head First Design Patterns
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

4. Strive for loosely coupled designs between objects and interact.
	
	Loosely coupled designs allow us to build flexible OO systems that can handle changes
	Because they minimize the interdependency between objects

5. Classes should be open for extension, but closed for modification.



### Benefits of Patterns
* Shared pattern vocabularies are POWERFUL.
* Patterns allow you to say more with less.
* Talking at the pattern level allows you to stay "in the design" longer.
* Shared vocabularies can turbo charge your development team.
* Shared vacabularies encourage more junior developers to get up to speed.


### Design Patterns
1. The Strategy Pattern 
	> Defines a family of algorithms, encapsulates each one, makes them interchangeable.
	> Strategy lets the algorithm vary independently from clients that use it.

2. The Observer Pattern
	> Defines a one-to-many dependency between objects so that when one object changes state,
	> all of it's dependents are notified and updated automatically.

3. The Decorator Pattern
	> Attaches additional responsibilities to an object dynamically. Decorators provide a
	> flexible alternative to subclassing for extending functionality.


#### The power of Loose Coupling in Observer Pattern
	* The only thing that the subject knows about an observer is that it implements a
	Certain Interface
	* We can add new observers at any time.
	* We never need to modify the subject to add new types of observers.
	* We can reuse subjects or observers independently of each other.
	* Changes to either the subject or an observer will not affect the other.
