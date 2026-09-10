using MESCL;
using System;
using System.IO;

if (args.Length == 0)
{
    Console.WriteLine("Использование: MСL <путь_к_файлу.m>");
    return;
}

var path = args[0];
if (!File.Exists(path))
{
    Console.WriteLine($"Файл не найден: {path}");
    return;
}

if (Path.GetExtension(path).ToLowerInvariant() != ".m")
{
    Console.WriteLine("Ожидается файл с расширением .m");
    return;
}

var source = File.ReadAllText(path);

var tokens = Tokenizator.Токенизовать(source);
var parser = new Parser(tokens);
var ast = parser.ParseProgram();
var generated = CodeGen.GenerateCSharp(ast);

// Печать и сохранение сгенерированного C#
//Console.WriteLine("--- Сгенерированный C# код ---");
//Console.WriteLine(generated);
//var outPath = Path.ChangeExtension(path, ".cs");
//File.WriteAllText(outPath, generated);
//Console.WriteLine($"C# код сохранён в: {outPath}");

Executor.Execute(ast);
