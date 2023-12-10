/*
string? inputFromUser;
int numberInInput;
bool validNumber = false;

Console.WriteLine("Enter an integer value between 5 and 10");

do
{
   inputFromUser = Console.ReadLine();
   validNumber = int.TryParse(inputFromUser, out numberInInput);
   
   if(!validNumber)
   {
      Console.WriteLine("Sorry, you entered an invalid number, please try again");
      continue;
   }

   else if(numberInInput < 5 || numberInInput > 10)
   {
      Console.WriteLine($"You entered {numberInInput}. Please enter a number between 5 and 10.");
      validNumber = false;
   }
   

} while (inputFromUser == null || !validNumber);

Console.WriteLine($"Your input value {(numberInInput)} has been accepted.");
*/
/*
using System.Reflection.Metadata;

string? inputFromUser;
string roleToMatch;
bool isRoleValid = false;
string[] roles = new string[3] { "Administrator", "Manager", "User" };

Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

do
{
   inputFromUser = Console.ReadLine();
   roleToMatch = inputFromUser.Trim().ToLower();

   switch (roleToMatch)
   {
      case "administrator":
      case "manager":
      case "user":
         Console.WriteLine($"Your input value ({inputFromUser.Trim()}) has been accepted.");
         isRoleValid = true;
         break;

      default:
         Console.WriteLine($"The role name that you entered, '{inputFromUser.Trim()}' is not valid. Enter your role name (Administrator, Manager, or User)");
         isRoleValid = false;
         break;

   }

} while (inputFromUser == null || !isRoleValid);
*/

string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int stringsCount = myStrings.Length;

string myString = "";
int periodLocation = 0;

for (int i = 0; i < stringsCount; i++)
{
   myString = myStrings[i];
   periodLocation = myString.IndexOf(".");

   string mySentence;

   // extract sentences from each string and display them one at a time
   while (periodLocation != -1)
   {

      // first sentence is the string value to the left of the period location
      mySentence = myString.Remove(periodLocation);

      // the remainder of myString is the string value to the right of the location
      myString = myString.Substring(periodLocation + 1);

      // remove any leading white-space from myString
      myString = myString.TrimStart();

      // update the comma location and increment the counter
      periodLocation = myString.IndexOf(".");

      Console.WriteLine(mySentence);
   }

   mySentence = myString.Trim();
   Console.WriteLine(mySentence);
}




