using System.Text.RegularExpressions;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

try
{
    Task1();
    //Task2();
    //Task3();
    //Task4();
    //Task5();
    //Task6();
    //Task7();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine(ex.Message);
    Console.ResetColor();
}
static void Task1()
{
    //номер мобільного телефону
    string pattern = @"\+\d{2}\(\d{3}\)-\d{2}-\d{2}-\d{3}";

    Regex regex = new Regex(pattern, RegexOptions.Multiline);

    string text = "Подзвоніть за номером +38(093)-12-34-567";

    Match match = regex.Match(text);
    Console.WriteLine(match.ToString());
}
static void Task2()
{
    //паспорт громадянина України
    //Пастопорт за зразком "Дві букви, шість цифр"

    string pattern = @"[А-Я][А-Я]\d{6}";

    Regex regex = new Regex(pattern, RegexOptions.Multiline);

    string text = "Громадянин-нелегал загубив свої паспорти з такими даними:\nАВ134934\nАW874635\nаУ123456\nШк723977\nИБ345089";
    Console.WriteLine(text + "\n");

    Console.WriteLine("Результат: ");
    MatchCollection matches = regex.Matches(text);
    foreach (Match match in matches)
        Console.WriteLine(match);
}
static void Task3()
{
    //перевірка належності п’ятизначного числа діапазону [10311;89645]
    int Count1 = 0;
    for (int i = 10311; i <= 89645; i++)
        Count1++;
    Console.WriteLine(Count1);

    string pattern = @"(1031[1-9]|103[2-9]\d|10[4-9]\d{2}|1[1-9]\d{3}|[2-7]\d{4}|[8][0-8]\d{3}|89[0-5]\d{2}|896[0-3]\d|8964[0-5])";

    Regex regex = new Regex(pattern, RegexOptions.Multiline);

    int Count2 = 0;
    for (int i = 10311; i <= 89645; i++)
    {
        if (!regex.IsMatch(i.ToString())) break;
        Count2++;
    }

    Console.WriteLine(Count2);

    if (Count1 == Count2)
        Console.WriteLine("Тест пройдено");
    else Console.WriteLine("Тест провалено");
}
static void Task4()
{
    //перевірки правильності введення імені користувача українською мовою.
    //Ім’я має вводитись з великої літери, далі всі літери мають записуватися у нижньому
    //регістрі. (Наприклад Олег, Олег-Олександр)

    string pattern = @"\b[А-ЯЇҐІ]{1}[a-яїґі]+[А-ЯЇҐІa-яїґі\-]+\b";
    Regex regex = new Regex(pattern, RegexOptions.Multiline);

    string text = "олег Олег Олег-Олександр богдан Богдан Богдан-Ігор оЛег боГдан Ївга";
    Console.WriteLine(text + "\n");

    Console.WriteLine("Результат: ");
    MatchCollection matches = regex.Matches(text);
    foreach (Match match in matches)
        Console.WriteLine(match);
}
static void Task5()
{
    //перевірка коректність запису часу у форматі ГГ: ХХ: СС.
    string pattern = @"\b([01]\d|2[0-3]):([0-5]\d)\b";

    Regex regex = new Regex(pattern, RegexOptions.Multiline);

    string text = "12:34 67:43 33:32 15:59 92:12 14:43 45:01";
    Console.WriteLine(text + "\n");

    Console.WriteLine("Результат: ");
    MatchCollection matches = regex.Matches(text);
    foreach (Match match in matches)
        Console.WriteLine(match);
}
static void Task6()
{
    //перевірка чи введене число (може бути додатне, від’ємне, ціле, дробове)

    string PositiveDoublePattern = @"^(\d+\,\d+)$";
    string NegativeDoublePattern = @"^(-\d+\,\d+)$";
    string PositiveIntegerPattern = @"^\d+$";
    string NegativeIntegerPattern = @"^-\d+$";

    double Number;
    Console.Write("Введіть число: "); Number = double.Parse(Console.ReadLine());

    if (Regex.IsMatch(Number.ToString(), PositiveDoublePattern))
        Console.WriteLine("Число додатне дробове");
    if (Regex.IsMatch(Number.ToString(), NegativeDoublePattern))
        Console.WriteLine("Число від'ємне дробове");
    if(Regex.IsMatch(Number.ToString(), PositiveIntegerPattern))
        Console.WriteLine("Число додатне ціле");
    if(Regex.IsMatch(Number.ToString(), NegativeIntegerPattern))
        Console.WriteLine("Число від'ємне ціле");
}
static void Task7()
{
    //перевірити чи дата лежить в межах від 01.01.1900 року до 31.12.2021 року

    string pattern = @"^(0?[1-9]|[12][0-9]|3[01])\.(0?[1-9]|1[012])\.((19\d\d|20[01][0-9]|202[01]))$";

    int day, month, year;
    Console.Write("Введіть день: "); day = int.Parse(Console.ReadLine());
    Console.Write("Введіть місяць: "); month = int.Parse(Console.ReadLine());
    Console.Write("Введіть рік: "); year = int.Parse(Console.ReadLine());

    string text = "";
    text += day.ToString();
    text += ".";
    text += month.ToString();
    text += ".";
    text += year.ToString();
    Console.WriteLine("Дата: " + text);

    if(Regex.IsMatch(text, pattern))
        Console.WriteLine("Дата входить в діапазон");
    else Console.WriteLine("Дата не входить в діапазон");
}