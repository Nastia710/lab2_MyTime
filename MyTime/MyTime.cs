using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_MyTime
{
    public class MyTime
    {
        protected int hour, minute, second;

        public MyTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }

        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        public override string ToString()
        {
            return $"{hour:D2}:{minute:D2}:{second:D2}";
        }

        // перетворюватиме вказаний час у кількість секунд, що пройшли від початку доби;
        public int ToSecSinceMidnight()
        {
            return hour * 3600 + minute * 60 + second;
        }

        //перетворюватиме кількість секунд, що пройшли від початку доби, у час у форматі MyTime;
        public static MyTime FromSecSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t %= secPerDay;
            // приводимо t до проміжку, можливого в межах однієї доби,
            // враховуючи, що початкове значення t може бути й від’ємним
            if (t < 0)
                t += secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }

        // додає 1 секунду до нашого часу
        public MyTime AddOneSecond()
        {
            return AddSeconds(1);
        }

        // додає 1 хвилину до нашого часу
        public MyTime AddOneMinute()
        {
            return AddSeconds(60);
        }

        // додає 1 годину до нашого часу
        public MyTime AddOneHour()
        {
            return AddSeconds(3600);
        }

        // додає певну кількість секунд до нашого часу
        public MyTime AddSeconds(int seconds)
        {
            int totalSeconds = ToSecSinceMidnight() + seconds;
            return FromSecSinceMidnight(totalSeconds);
        }

        // знаходить різницю в секундах між заданими часами
        public int Difference(MyTime other)
        {
            return ToSecSinceMidnight() - other.ToSecSinceMidnight();
        }

        // перевіряє, чи знаходиться заданий час у вказаному проміжку
        public bool IsInRange(MyTime start, MyTime finish)
        {
            int startSeconds = start.ToSecSinceMidnight();
            int finishSeconds = finish.ToSecSinceMidnight();
            int timeSeconds = ToSecSinceMidnight();

            if (startSeconds <= finishSeconds)
            {
                return timeSeconds >= startSeconds && timeSeconds <= finishSeconds;
            }
            else
            {
                return timeSeconds <= startSeconds && timeSeconds >= finishSeconds;
            }
        }

        // якій парі/перерві відповідає заданий час
        public static string WhatLesson(MyTime mt)
        {
            int[] startLessons = { 8 * 3600, 9 * 3600 + 40 * 60, 11 * 3600 + 20 * 60, 13 * 3600, 14 * 3600 + 40 * 60, 16 * 3600 + 10 * 60, 17 * 3600 + 40 * 60 };
            int[] finishLessons = { 9 * 3600 + 20 * 60, 11 * 3600, 12 * 3600 + 40 * 60, 14 * 3600 + 20 * 60, 16 * 3600, 17 * 3600 + 30 * 60 };

            int ourTime = mt.ToSecSinceMidnight();

            if (ourTime < startLessons[0])
            {
                return "Пари ще не почалися";
            }

            if (ourTime >= finishLessons[finishLessons.Length - 1])
            {
                return "Пари вже закінчилися";
            }

            for (int i = 0; i < startLessons.Length - 1; i++)
            {
                if (ourTime >= startLessons[i] && ourTime < finishLessons[i])
                {
                    return $"{i + 1}-а пара";
                }

                if (ourTime >= finishLessons[i] && ourTime < startLessons[i + 1])
                {
                    return $"Перерва між {i + 1}-ю та {i + 2}-ю парами";
                }
            }

            return "Пари вже закінчилися";
        }
    }
}
