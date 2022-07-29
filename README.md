Mut_Accout
This is a program created for recording daily activities. New or returning users can record daily events they want to keep track of and be scored on at any part of the day.
 
The Main objective of the project is to turn it into an app that multiple users can use no matter what OS they are on. Also to track that record of completion to see where you rank while your follow users.
 
Some of the options are shown below:
 
Main Menu:
    New Members - If the user is New to the program.
    Returning Members - For Returning Members to either add new Daily Activities or Complete the Activities Entered.
    Daily Percentage - This shows the completion of your Daily Activities.
 
New Members:
    First Name - First Name of the New User.
    Last Name - Last Name of the New User.
    Email - Email of the New User.
 
Returning Members:
    New Daily Entries - This allows you to enter 3 New Entries from the Activity List.
    Complete Entries  - This allows us to Complete the Activities that have been entered for the day.
 
Daily Percentage:
    Will show how many activities completed and the percentage of the completed activities for the day.
 
This is still in the early days of creation.. Thank you for your patience!!!

The Features that are in this project are the following:

A Master Loop - If an option from the Main Menu is used, after that the selection is completed of the program it will send you back to the Main Menu.

Reading from a .txt- There is a on information.txt in the Bin Release/Debug net6.0 that gives the information show above to the user and is pulled in the Info.cs.

The use of regex - This is use in EmailValid.cs to insure that an email address is entered is a vaild email.

Connecting to a Database Read and Write - This whole project is to store the information that is enter from diferent users using it. The Database is an Azure SQL with three different tables (Daily_Entry, List_Activities, User) that play a role in different parts of the project.      
    1)Stores new users that are starting out shown in MemberInput.cs NewMember(). This will also validate that if the email is an email or if it has already been entered. 
    2)Returning users can just enter the eamil that has been enter from them shown in MemberIput.cs ReturnMember().
    3)Pull a list of activities that is stored on database to be enter as daily events by the user shown in Acctlist.cs NewAcct().
    4)Able to let the user input the activities shown in Acctlist.cs NewAcct()
    5)Able for a user to pull the entrys that use enter and display them shown in ListDataTable.cs Dtable().
    6)Gives the options if the user is wanting to continue to enter if the completion of the selected Activity shown in Memberinput.cs near the botttom of the code.
    7)After the entering of Completion is finish the user is able to go back and see the score and percentage of the day shown in EntryMath.cs





