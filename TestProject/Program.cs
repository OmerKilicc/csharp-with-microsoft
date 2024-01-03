const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

const string openSpan = "<span>";
const string closeSpan = "</span>";

const string replacedParameter = "trade";
const string whatToReplace = "reg";

const int unwantedCharCount = 2;

string quantity = "";
string output = "";
string[] deletedParameters = new string[] { "<div>", "</div>" };

// Your work here
quantity = QuantityFinder();
output = OutputFinder(deletedParameters, replacedParameter, whatToReplace);

Console.Clear();
Console.WriteLine(quantity);
Console.WriteLine(output);

static string QuantityFinder()
{
    string quantity;

    int quantityStart = input.IndexOf(openSpan) + openSpan.Length; // + length of <span> so index at end of <span> tag
    int quantityEnd = input.IndexOf(closeSpan);
    int quantityLength = quantityEnd - quantityStart;

    quantity = input.Substring(quantityStart, quantityLength);

    return $"Quantity: {quantity}";
}

static string OutputFinder(string[] deletedParameters, string replacedParameter, string whatToReplace)
{
    string outputString = input;

    foreach (string parameter in deletedParameters)
        outputString = outputString.Replace(parameter, "");

    outputString = outputString.Replace(replacedParameter, whatToReplace);

    return outputString;
}