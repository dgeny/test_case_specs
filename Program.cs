// функция генерации массива строк из словаря
// возвращает случайное количество слов в диапазоне от minItems до maxItems
string[] GenerateArray(int minItems, int maxItems, string[] dict)
{
    // Инициализируем массив случайной длины
    Random rnd = new Random();
    int itemsCount = rnd.Next(minItems, maxItems);
    string[] generatedArray = new string[itemsCount];

    // Заполним его случайными словами из dict

    for (int i = 0; i < itemsCount; i++)
        generatedArray[i] = dict[rnd.Next(0, dict.Length - 1)];

    return generatedArray;
}

// файл в массив слов
string[] MakeDict(string fileName)
{
    string tempString = string.Empty;
    using (System.IO.TextReader rdr = new System.IO.StreamReader(fileName))
    {
        tempString = rdr.ReadToEnd();
        rdr.Close();
    }
    return tempString.Split(
        new char[] { ' ', '\t', '\r', '\n' },
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
    );
}

// Выбираем из массива слова длиной меньше или равно lenWords
string[] GetShortsArray(string[] array, int lenWords)
{
    // Определим размер возвращаемого массива
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= lenWords)
            count++;
    }

    //Инициализируем возвращаемый массив
    string[] returnArray = new string[count];

    //а теперь count - индекс следующего незаполненного элемента возвращаемого массива
    count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= lenWords)
        {
            returnArray[count] = array[i];
            count++;
        }
    }
    return returnArray;
}

//Магия: максимальная длина слова из условия
int lenWords = 3;
// зададим параметры генератора исходного массива 
int minItems = 5, maxItems = 10;
//
// сгенерируем исходный массив
string[] initialArray = GenerateArray(minItems, maxItems,
        // чтобы не тащить ненужный словарь в проект, возьмем за основу исходное задание проверочной работы
        MakeDict("starting_task.md")
);

// найдем слова короче или равные требуемому lenWords
string[] shortsArray = GetShortsArray(initialArray, lenWords);

System.Console.WriteLine(
    "Исходный массив: ['" +
    string.Join("', '", initialArray) +
    "']"
);

System.Console.WriteLine(
    "Массив из слов длиной короче 4: ['" +
    string.Join("', '", shortsArray) +
    "']"
);
