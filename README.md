# TodoListBBRZ
TodoList 
Branch (V5-Cookies-Sessions-Authorization)

Project TODOList - >

Implementation of a TODO List so far with
- 1:1 relationship
- 1:n relationship

"Musterlösung"

DONE: 

a) ResourceVM DeleteTodo -> needs a inquiry, if you really want to "DEACTIVATE"
the TODO regarding this particular Resource.

b) ResourceVM AddTodo -> We need to implement AddTodo to associate exisiting Todos
to this Resource.

c) ResourceVM AddTodo - right now we offer all Todos in the DropDown List.

-> Show only the not existing yet, to be able to assign the missing Todo. 

d) Implement Cookies (Last online time)

e) Implement Sessions (Have a unique runtime ID)

f) Simple authentication - encryption missing with salt and pepper


TDB: (To be done)

f2) encryption with salt and pepper and use case for authorization


--------------------------

Lets continue: 

f) Simple authentication (with Pepper and Salt) 

So that we have now realized the basic idea of authorization, 
we still should "store" the passwords encrypted. 

We use salt and pepper to make hacking much more difficult. 

We remember the rainbow table. 

--------------------------

So let's encrypt the password for a new user. 

We implement a hashing algorythm "GenerateHash" in the global.asax.cs - whenever we 
have a readable password to decypher or a cyphered password to check, 
we use this ... 

https://github.com/Olio72AT/TodoListBBRZ/blob/V8-Authorization-Salt-Pepper/TODO04ListAP03/TODOListAP03/TODOListAP03/Global.asax.cs

So let's use it for new users ... See the Logout Index View now ... 

----------------------------

Next steps to do: 

g) As logged on user, you should be able to logout, so we add a LOGOUT to the active line and 
implement the code for it. 

h) Whenever the user is logged out, we should display LOGIN instead of LOGOUT in the main menu. 

i) When we press LOGIN, we should be able to login as the certain user. 
So lets create the login view. (Choose if you like a view model or the plain authorization model)

----------------------------

but before we do this - YOUR TASK IS NOW TO: 

Create 2 dummy users with the password for Oliver and Martha. 

Remember the salted and peppered password, so that you 
can easily take them over in the global.asax.cs from now on. 

For the demo ... use "123" as the pepper value.  

See you in the next lession ... 












