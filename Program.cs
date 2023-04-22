string[] ResizeArray(string[] old, string word)
{
    string[] buffer = new string[old.Length + 1];

    old.CopyTo(buffer, 0);
    buffer[old.Length] = word;

    return buffer;
}

string[] CollectArray()
{
    string[] dummy = Array.Empty<string>();

    while(true)
    {
        Console.WriteLine("Введите любую строку:");
        string? word = Console.ReadLine();

        if (word != null && word != "")
        {
            if (word == "0")
            {
                return dummy;
            }
            else
            {
                dummy = ResizeArray(dummy, word);
            }
        }
    }
}

void Welcome()
{
    Console.WriteLine("Добро пожаловать в мою программу!");
    Console.WriteLine("Она умеет генерировать массив из введенных строк, по заданному количество символов.");
    Console.WriteLine("Начните вводить строки, программа их будет запоминать.");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Как только вы захотите закончить, введите цифру 0 и нажмите Enter");
    Console.ResetColor();
}

string[] FilterArrayByCharactersCount(string[] array, int count = 3)
{
    string[] buffer = Array.Empty<string>();

    for(var i = 0; i < array.Length; i++)
    {
        var word = array[i];

        if (word.Length <= count)
        {
            buffer = ResizeArray(buffer, word);
        }
    }

    return buffer;
}

void Print(string[] array)
{
    for(var i = 0; i < array.Length; i++)
    {
        if((i % 2) == 0)
        {
            Console.WriteLine();
        }

        Console.Write($"\t{i} => {array[i]}");
    }

    Console.WriteLine();
    Console.WriteLine();
}

void entry()
{
    Welcome();

    var buffer = CollectArray();
    Console.WriteLine("Введенный массив: ");
    Print(buffer);

    Console.WriteLine("По какому кол-ву символов хотите отфильтровать ? (по умолчанию 3)");
    var str = Console.ReadLine();
    
    if(string.IsNullOrEmpty(str)) 
    {
        str = "0";
    }

    var count = Convert.ToInt32(str);

    if (count <= 0)
    {
        count = 3;
    }

    buffer = FilterArrayByCharactersCount(buffer, count);

    Console.WriteLine("Отфильтрованный массив: ");

    Print(buffer);

    Console.ReadKey();
}

entry();