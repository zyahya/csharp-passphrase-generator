using PassphraseGenerator;

var gen = new GeneratePassphrase();
string passphrase;

try
{
    int count = int.Parse(args[0]);
    passphrase = gen.Generate(count);
}
catch
{
    passphrase = gen.Generate();
}

Console.WriteLine(passphrase);
