# TASK TRACKER (Úkolníček)

## Final Project for Czechitas course CSharp 2
----------------------------------------------

### public class Task

string Description, bool HighPriority, DateTime DueDate, bool Completed, string UserName

### public class abstract GeneralUser

string Name, string Password

1. LogIn
2. LogOut
3. EndProgram

### public class User : GeneralUser

base(string name), base(string password)

1. SignUpAsNewUser
2. MarkTaskAsCompleted
3. ListTasks
4. FindTasks

### public class Manager : GeneralUser

base(name), base(password)

1. AddTask
2. DeleteTask
