#### Model 

is entity class used to transfer data between MVC app and Db

mostly this can also be used to transfer data between controller action method and view

&#x09;

&#x09;VS



But Sometime display on view is different from entity class so we can create viewmodel

to transfer data between action method and view



ViewModel



e.g View will show List<Book> and List<Customer>



Model classes are - Book and Customer

ViewModel class is - {List<Book> \& List<Customer>}



another example is to pass data between only action method and view (no DB persistence required)



another example = Reg Page

&#x09;		User ID

&#x09;		Password

&#x09;		Confirm Password



Blur - Press tab on TextBox - leave TextBox 

&#x09;(Touch)		(Dirty - entered some value)



Form Building - we can use HTML helpers @HTML

Or we use Tag Helpers - preferred 



Suppose I want to create a new record 

Form Fill -> post action -> Save Changes -> Form Confirmation





Token Based authentication - JWT(Json web Token)



JWT token format



will we use JWT in projects? Yes

API based Application



In MVC app can we use Authentication? Yes - (not JWT auth)

&#x09;					cookies based



Register - Login - authorize - 

what user can do? Add Emp, change salary?

Role based - Admin, user, Customer

Yes, but without ant much effort,

will use build in identity Framework








































