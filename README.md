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


TDB: (To be done)

f) Simple authentication (with Pepper and Salt) 


--------------------------

Lets start: 

f) Simple authentication (with Pepper and Salt) 

So, we yould like to LOGIN and LOGOUT with a certain password. 
This password needs to be stored with SALT and PEPPER. In real life, 
never store the passwords within the source code, neither store any 
hint verbally. Matter of fact, within the algorithmns, we can of course 
foresee the way to solve the riddle. This is now a "draft" approach 
how you can implement the authentication in a simple way. 

.) We need a model first. 
- Id
- UserId
- Password
- Role
- SessionID

Your task now is to create the corresponding CRUD functions: 
1) AuthorizationController 
2) Index View
3) Create View
4) Details View
5) Delete View 
6) --- we skip the Modify View

Add an "Logout" Menu entry in the _Layout.cshtml to access it. 

See you at the next chapter ... 

_ 








