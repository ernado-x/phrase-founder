// See https://aka.ms/new-console-template for more information

using PhraseFinder.Core;

Console.WriteLine("Hello, World!");

var path = "/Users/andrew/Projects/phrase-founder/data/gec-fluency/train/source";
var files = Directory.GetFiles(path).Take(50).ToList();

var pi = "3.14159265359";

foreach (var file in files)
{
    var text = await File.ReadAllTextAsync(file);
    var results = Finder.find(text, pi);

    foreach (var result in results)
    {
        Console.WriteLine($"{result}");
    }
}