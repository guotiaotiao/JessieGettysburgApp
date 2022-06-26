namespace JessieApp;

public static class Utility
{
    public static WordsLettersRes ReadGettysburgFile(string path)
    {
        var lines = File.ReadAllLines(path);

        var words = new Dictionary<String, int>();
        var letters = new Dictionary<String, int>();

        foreach (var line in lines)
        {
            var wordsArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var word in wordsArr)
            {
               
                char[] chars = { '.', ',' };
                string newWord = word.TrimEnd(chars);

                if (word == "--")
                {
                    continue;
                }

                if(words.ContainsKey(newWord))
                {
                    words[newWord] = words[newWord] + 1;
                } else
                {
                    words[newWord] = 1;
                }

                var lettersArr = word.ToCharArray();

                foreach (var letterChar in lettersArr)
                {
                    var letter = letterChar.ToString();
                    if (letters.ContainsKey(letter))
                    {
                        letters[letter] = letters[letter] + 1;
                    }
                    else
                    {
                        letters[letter] = 1;
                    }
                }
            }
        };

        return new WordsLettersRes(Top10(words), Top10(letters));
    }

    public static Dictionary<string, int> Top10(Dictionary<string, int> dic)
    {
      return dic.OrderByDescending(entry => entry.Value)
                      .Take(10)
                      .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public class WordsLettersRes
    {
        public WordsLettersRes(Dictionary<string, int> words, Dictionary<string, int> letters)
        {
            Words = words;
            Letters = letters;
        }

        public Dictionary<string, int> Words { get; set; }
        public Dictionary<string, int> Letters { get; set; }
    }
}