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


TDB: (To be done)

d) Implement Cookies (Last online time)

e) Implement Sessions (Have a unique runtime ID)

f) Simple authentication (with Pepper and Salt) 


--------------------------

Lets start: 

d) Implement Cookies (Last online time):
We want to show the last "time" when you started your app.

Therefore: What code will always been called when you start the MVC App?
Well, Global.asax is triggered at the beginning. 

The idea: 

© 2020 - Meine ASP.NET-Anwendung

Right under this line, let's output: 
Last online visit 12:12:00h. Have fun!


1) So let's read our browser cookie at startup, when it exists and display the value. 

2) Write our cookie with the current time. 

How to do that?

See: public static void CallCookieOnce() @ Global.asax

https://github.com/Olio72AT/TodoListBBRZ/blob/V5-Cookies-Sessions-Authorization/TODO04ListAP03/TODOListAP03/TODOListAP03/Global.asax.cs

-------------------------------


