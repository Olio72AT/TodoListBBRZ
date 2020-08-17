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







