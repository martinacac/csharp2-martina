# TASK TRACKER (Úkolníček)

## Final Project for Czechitas course CSharp 2
----------------------------------------------

### public class Task

string Description, bool HighPriority, DateTime DueDate, bool Completed

supporting methods: ToString, WriteTaskInConsole

### public class abstract GeneralUser

string Name, string Password

1. LogOut

### public class User : GeneralUser

base(string name), base(string password)

1. ListTasks
2. FindTasks
3. MarkTaskAsCompleted

supporting methods: SaveTasks, GetTasksOfUser

### public class Manager : GeneralUser

base(name), base(password)

1. ListTasks
2. ListAllTasksGroupedByUsersWithFilter
3. FindTasks
4. AddTask
5. DeleteTask
6. SignUpManager

*before SignUpManager default setting is used:
defaultManagerName = "firstmanager"
defaultManagerPassword = "bigboss"*

supporting methods: ListUsers, GetSelectedUser

### public class Utils

1. LogInUser
2. LogInManager
3. SignUpUser
4. SignUpManager

supporting methods: EncodePassword, DecodePassword, ReadPassword, HasRequiredMinLength, ExistsTaskTrackerDirectory, ExistsAllUsersFile, ExistsAllManagersFile, ExistsUserNameFile, ExistsUserName, ExistsManagerName, WaitForEnter, PromptTaskFilterType, GetTaskFilterPredic

### public class Program

