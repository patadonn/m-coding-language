using MESCL;
using System;
using System.Collections.Generic;
using System.Text;

var токены = new List<Dictionary<string, (Tokenizator.ТипТокена, string)>>();

токены = Tokenizator.Токенизовать("переменная А = 192.178;\n" +
    "переменная Б = \"89\";\n" +
    "переменная Ц,Д = $пропуск#,$0,5#;\n" + 
    "если переменная (Ц == А) $ \n" +
    "отладить(\"Верно!\");\n" +
    "#\n" +
    "иначе $\n" +
    "отладить(\"Неверно!\");\n" +
    "#");

for (int i = 0; i < токены.Count; i++)
{
    foreach (var пара in токены[i])  // перебираем словарь
    {
        var (тип, значение) = пара.Value;  // распаковываем кортеж
        Console.WriteLine($"{тип}: '{значение}'");
    }
}