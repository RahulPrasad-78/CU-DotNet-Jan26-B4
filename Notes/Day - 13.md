**Day - 13**



we can place default value of variable in parameter

while passing the arguments we can define the variable we want to pass the value



example:



Sum(int a = 1, int b =2, int c =3){

}

Main{

 	sum(3,4,5)	// original

 	Sum(c: 5)	// only change c value and take all value by default

}





Parameter types:

 	value type or ref type

 	ref - when we want to pass value type as ref type

 	out - get value from method

 	in - passed in parameter but it is read only you can't change the value

 	named - pass some of parameters with name

 	default - provide default value on parameters



Class: (internal(default), public)

 	Data Member - private public protected and internal

 		members are private by default

 	Properties (Getters + Setters)

 	Methods (behavior)

 	Constructor

 	Events

 	Indexers

 	operators (Overloaded)

 	etc



Generally we should create an entity class in a separate file



every class is derived from object class having some overridable methods.

class object is partial datatype



Partial classes are used as combined class after compilation.



Property is a combination of getter and Setter in same block



How to create Property?

prop-full is a snippet to create full property

 	contains - data member + getter + setter



there is also Auto Implemented Property



CLR provides default constructor in class to assign default values

auto Implemented property

without any data member and business logic

CLR creates data member by default

### 

### **OOPS**



Abstraction and Abstract class

DRY - Don't Repeat Yourself





 

