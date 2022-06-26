using JessieApp;

var path = "gettysburg_address.txt";

var result = Utility.ReadGettysburgFile(path);

Console.WriteLine("Top 10 words are: ");

foreach (KeyValuePair<string, int> pair in result.Words)
{    
    Console.WriteLine("Word: {0}, Frenquency is {1}", pair.Key, pair.Value);
}

Console.WriteLine("Top 10 letters are: ");
foreach (KeyValuePair<string, int> pair in result.Letters)
{
    Console.WriteLine("Letter: {0}, Frenquency is {1}", pair.Key, pair.Value);
}

