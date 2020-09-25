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

f2) encryption with salt and pepper and use case for authorization
including the passwords for Oliver and Martha. 

k) Patch corretion: 
k1) Correct wrong SessionID indications / set the cookie lifetime value to 2 days.

g) As logged on user, you should be able to logout, so we add a LOGOUT to the active line and 
implement the code for it. We replaced the LOGOUT to ADMIN and added a new Menu item LOGOUT.
(Code to be implemented in point h)

h) Whenever the user is logged out, we should display LOGIN instead of LOGOUT in the main menu.

j) WE MIGHT HAVE A PROBLEM, if the session ID is not valid anymore ... so? 
We needed a static field called WHOAMI to remember me as the logged on user.
(defined now in the resource controller ...)

TDB: (To be done)

i) When we press LOGIN, we should be able to login as the certain user. 
So lets create the login view. (Choose if you like a view model or the plain authorization model)













