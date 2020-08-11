# TodoListBBRZ
TodoList 
Branch (V3-AddTodo)

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

TDB: (To be done)

c) ResourceVM AddTodo - right now we offer all Todos in the DropDown List.

-> Show only the not existing yet, to be able to assign the missing Todo. 

--------------------------

Homework:

Right now, all Todos are visible in the DROPDOWN List, independant if 
have already been used. 

Your task is now to reduce the DROPDOWN items to the missing tasks 
(which haven't been used yet.) for the given Resource. 


---------------------------

What we need to do now: 

1) Ask yourself, how you would implement the AddTodo? 

Well, we need to add an EXISTING Todo to a RESOURCE. 
So there are severel solutions on this. 

1a) Make a View, where you see a particular RESSOURCE and make a DROPDOWN List 
with existing TODOs to select from. Then add it to the TodosId List. 

1b) Make a Menu item in the Todos, where you want to add this TODO to a Ressource. 

...

We want to focus on the solution 1a) (One RESOURCE can hold many TODOs, so ... )
 
So let's implement: 



.) Run the APP and simulate, what we want to implement

.) We need a View, where you display one Resource and then add the DropDown List of existing Tasks 

.) So lets define a new VIEWMODEL, in order to prepare the views data to display


AddTodoViewModel: -> 

 public class AddTodoViewModel
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        [REQUIRED]
        public IEnumerable <Todos> Todos { get; set; }
    }


If you want to implement the Todos with a DropDown List, the best solution is to declare it a IEnumerable.
(you could also do it as LIST, but we only need to view the list, so this do not need all the LIST methods ...
IEnumerable is therefore easy to use.)


.) Then implement the GET View

.) Create an "EDIT" AddTodo View and change the given parameters 

.) After is it running, test it by debugging 

.) Implement the POST Part

Have fun!



