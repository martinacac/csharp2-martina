# TASK TRACKER (Úkolníček)

## Final Project for Czechitas course CSharp 2
----------------------------------------------

### public class Task

string Description, bool HighPriority, DateTime DueDate, bool Completed

### public class abstract GeneralUser

string Name, string Password

1. LogOut

### public class User : GeneralUser

base(string name), base(string password)

1. ListTasks
2. FindTasks
3. MarkTaskAsCompleted

### public class Manager : GeneralUser

base(name), base(password)

1. ListTasks
2. FindTasks
3. AddTask
4. DeleteTask
5. SignUpManager

before SignUpManager default setting is used:
defaultManagerName = "firstmanager"
defaultManagerPassword = "bigboss"

### public class Utils

1. LogInUser
2. LogInManager
3. SignUpUser
4. SignUpManager

### public class Program

1. EndProgram