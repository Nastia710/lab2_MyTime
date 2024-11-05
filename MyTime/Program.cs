using System;

namespace lab2_MyTime
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть час:");
            int[] time = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime time1 = new MyTime(time[0], time[1], time[2]);

            Console.WriteLine("Кількість секунд, які пройшли від початку доби:");
            Console.WriteLine(time1.ToSecSinceMidnight());

            Console.WriteLine("Введіть скільки секунд пройшло від початку доби:");
            int seconds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Час, після додавання {seconds} секунд до початку доби:");
            Console.WriteLine(MyTime.FromSecSinceMidnight(seconds));

            Console.WriteLine("Час, після додавання одної секунди до нашого часу:");
            Console.WriteLine(time1.AddOneSecond());

            Console.WriteLine("Час, після додавання одної хвилини до нашого часу:");
            Console.WriteLine(time1.AddOneMinute());

            Console.WriteLine("Час, після додавання одної години до нашого часу:");
            Console.WriteLine(time1.AddOneHour());

            Console.WriteLine("Введіть скільки секунд додати до нашого часу:");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(time1.AddSeconds(s));

            Console.WriteLine("Введіть другий час:");
            int[] time2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime newTime = new MyTime(time2[0], time2[1], time2[2]);

            Console.WriteLine("Різниця в секундах між двома часами:");
            Console.WriteLine(time1.Difference(newTime));
          
            Console.WriteLine("Введіть новий час для перевірки діапазону:");
            int[] time3 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime newTime2 = new MyTime(time3[0], time3[1], time3[2]);

            Console.WriteLine("Введіть стартовий час:");
            int[] timeStart = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime start = new MyTime(timeStart[0], timeStart[1], timeStart[2]);

            Console.WriteLine("Введіть кінцевий час:");
            int[] timeFinish = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime finish = new MyTime(timeFinish[0], timeFinish[1], timeFinish[2]);

            Console.WriteLine(newTime2.IsInRange(start, finish) ? "Час належить заданому проміжку" : "Час не належить заданому проміжку");

            Console.WriteLine("Введіть новий час для визначення пари:");
            int[] time4 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime newTime3 = new MyTime(time4[0], time4[1], time4[2]);
            Console.WriteLine(MyTime.WhatLesson(newTime3));
        }
    }
}