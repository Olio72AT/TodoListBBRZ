# TodoListBBRZ
TodoList 
Branch (V2---DeleteTodo-/-AddTodo)

Project TODOList - >

Implementation of a TODO List so far with
- 1:1 relationship
- 1:n relationship

"Musterlösung"

DONE: 

a) ResourceVM DeleteTodo -> needs a inquiry, if you really want to "DEACTIVATE"
the TODO regarding this particular Resource.


TDB: (To be done)

b) ResourceVM AddTodo -> We need to implement AddTodo to associate exisiting Todos
to this Resource.


AUFGABE: 

1) Read and understand this approach.
2) For yourself: Try to change the ViewModel to 

 public class ResourcenTodosRemoveViewModel
    {
        public Resourcen Res { get; set; }
        public int TodoId { get; set; }

    }

....

public class ResourcenTodosRemoveViewModel
    {
        public Resourcen Res { get; set; }
        public Todos Todo { get; set; }

    }

to display also the "Kurzbeschreibung" in the Ressourcen/DeleteTodo GET View.
 
