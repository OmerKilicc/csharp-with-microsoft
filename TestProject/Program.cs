/*
   This code reverses a message, counts the number of times 
   a particular character appears, then prints the results
   to the console window.
 */

string originalMessage = "The quick brown fox jumps over the lazy dog.";

char[] messageGroup = originalMessage.ToCharArray();
Array.Reverse(messageGroup);

int letterCount = 0;

foreach (char i in messageGroup) 
{
     if (i == 'o') 
        letterCount++; 
}

string reverseMessage = new String(messageGroup);

Console.WriteLine(reverseMessage);
Console.WriteLine($"'o' appears {letterCount} times.");