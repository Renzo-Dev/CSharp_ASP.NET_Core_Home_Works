using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_4.Pages;

public class Task1 : PageModel
{
    // Task 1 -  Выведите: номер текущего дня в году, а также информацию о том, какой сейчас год, с указанием, он высокосный или нет.
    public int DayOfYear { get; private set; }
    public int CurrentYear { get; private set; }
    public bool IsLeapYear { get; private set; }
    public string Phrase { get; private set; } = "";

    public void OnGet()
    {
        // Получаем текущую дату
        var currentDate = DateTime.Now;

        // Получаем номер текущего дня в году
        DayOfYear = currentDate.DayOfYear;

        // Получаем текущий год
        CurrentYear = currentDate.Year;

        // Проверяем, является ли текущий год высокосным
        IsLeapYear = DateTime.IsLeapYear(CurrentYear);

        // Task 2 - В зависимости от случайного значения отображайте фразу, которая состоит от 5 до 10 символов английского алфавита, буквы могут быть большими и маленькими.

        var random = new Random();

        // получаем случайное значение от 5 до 10 (длина фразы)
        var lenght = random.Next(5, 11);

        var phraseChars = new char[lenght];

        for (var i = 0; i < lenght; i++)
        {
            // получаем случайное число от 0 до 1, что бы определить будет ли буква в верхнем регистре
            var isUppercase = random.Next(2) == 0;

            // Получаем случайное число от 0 до 25, которое будет соответствовать индексу буквы в английском алфавите
            var letterIndex = random.Next(26);

            // Получаем символ буквы в соответствии с индексом
            var letter = (char)(isUppercase ? 'A' + letterIndex : 'a' + letterIndex);

            // Записываем букву в массив
            phraseChars[i] = letter;
        }

        // создаем строку из массива символов
        Phrase = new string(phraseChars);
    }
}