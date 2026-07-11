Exception Handling

what it is ? to Handle runtime exception 
every exception is a derived class of exception class

How? using try catch(es) and finally

can we have try without catch?
we can write catch or finally after try block.

if we use multiple catches, 
the last catch should be most generic catch
most generic catch can't be put 

Calling Method - Main
Called Method - Get-Div

If Called Method is generating an exception can be handled at the called method

If Called method does not handle thrown exception it is handled by calling method

every exception  may have an associated message 
Message is a property of any Exception

if we display exception obj, will display
class name, message,  stack trace

return (go back to calling method and terminate rest of the called method) 
when we can use return? only in void methods
if we terminate the execution with or without exception, finally will always executed.
	vs 
go back  to called methods with this value return 0;

throw can be used to throw an object of any exception.
use throw keyword to throw an object of objection

we can throw an exception from within a catch block
we can customize the msg  by passing a new string message in throw

may be in a case when we want to throw a new exception from catch block

User Defined Exceptions OR custom Exceptions
create a new class derived from Exception class
Create a parameter constructor with message
e.g SalaryOutOfRAngeException


















