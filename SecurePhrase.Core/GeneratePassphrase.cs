using System.Reflection;

namespace SecurePhrase.Core;

public class GeneratePassphrase
{
    public List<string> RetrieveWordlistData()
    {
        var words = new List<string>();
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "SecurePhrase.Core.Data.eff_short_wordlist_1.txt";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream!);

        while (!reader.EndOfStream)
        {
            words.Add(reader.ReadLine()!);
        }

        return words;
    }

    public string[] SelectRandomWords(int count = 5)
    {
        var words = RetrieveWordlistData();

        string[] result = Random.Shared.GetItems(words.ToArray(), count);

        return result;
    }

    public string JoinWords(string[] words, string separator = "-")
    {
        return string.Join(separator, words);
    }

    public string Generate(int count = 5)
    {
        var words = SelectRandomWords(count);
        var passphrase = JoinWords(words, "-");

        return passphrase;
    }
}
