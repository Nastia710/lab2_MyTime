using lab2_MyTime;
namespace MyTimeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            MyTime time = new MyTime(5, 30, 45);
            string tm = $"{time.Hour:D2}:{time.Minute:D2}:{time.Second:D2}";
            Assert.AreEqual(tm, time.ToString());
        }

        [Test]
        public void ToSecSinceMidnight_ShouldReturnCorrectSeconds()
        {
            MyTime time = new MyTime(1, 1, 1);
            int expectedTime = time.Hour * 3600 + time.Minute * 60 + time.Second;
            Assert.AreEqual(expectedTime, time.ToSecSinceMidnight());
        }

        [Test]
        public void FromSecSinceMidnight_ShouldHandleNormalTime()
        {
            int sec = 3661;
            int secPerDay = 60 * 60 * 24;
            sec %= secPerDay;
            if (sec < 0)
                sec += secPerDay;
            int h = sec / 3600;
            int m = (sec / 60) % 60;
            int s = sec % 60;

            MyTime expectedTime = new MyTime(h, m, s);
            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime time = MyTime.FromSecSinceMidnight(sec);
            Assert.AreEqual(tm, time.ToString());
        }

        [Test]
        public void FromSecSinceMidnight_ShouldHandleNegativeSeconds()
        {
            int sec = -1;
            int secPerDay = 60 * 60 * 24;
            sec %= secPerDay;
            if (sec < 0)
                sec += secPerDay;
            int h = sec / 3600;
            int m = (sec / 60) % 60;
            int s = sec % 60;

            MyTime expectedTime = new MyTime(h, m, s);
            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime time = MyTime.FromSecSinceMidnight(sec);
            Assert.AreEqual(tm, time.ToString());
        }

        [Test]
        public void AddOneSecond_ShouldReturnCorrectTime()
        {
            MyTime time = new MyTime(23, 59, 59);
            MyTime expectedTime = time.AddSeconds(1);

            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime newTime = time.AddOneSecond();
            Assert.AreEqual(tm, newTime.ToString());
        }

        [Test]
        public void AddOneMinute_ShouldReturnCorrectTime()
        {
            MyTime time = new MyTime(23, 59, 0);
            MyTime expectedTime = time.AddSeconds(60);

            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime newTime = time.AddOneMinute();
            Assert.AreEqual(tm, newTime.ToString());
        }

        [Test]
        public void AddOneHour_ShouldReturnCorrectTime()
        {
            MyTime time = new MyTime(23, 0, 0);
            MyTime expectedTime = time.AddSeconds(3600);

            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime newTime = time.AddOneHour();
            Assert.AreEqual(tm, newTime.ToString());
        }

        [Test]
        public void AddSeconds_ShouldReturnCorrectTime()
        {
            MyTime time = new MyTime(0, 0, 0);

            int seconds = 3661;
            int totalSeconds = time.ToSecSinceMidnight() + seconds;
            MyTime expectedTime = MyTime.FromSecSinceMidnight(totalSeconds);
            string tm = $"{expectedTime.Hour:D2}:{expectedTime.Minute:D2}:{expectedTime.Second:D2}";

            MyTime newTime = time.AddSeconds(seconds);
            Assert.AreEqual(tm, newTime.ToString());
        }

        [Test]
        public void Difference_ShouldReturnCorrectDifference()
        {
            MyTime time1 = new MyTime(2, 0, 0);
            MyTime time2 = new MyTime(1, 30, 0);

            int expectedTime = time1.ToSecSinceMidnight() - time2.ToSecSinceMidnight();
            Assert.AreEqual(expectedTime, time1.Difference(time2));
        }

        [Test]
        public void IsInRange_ShouldReturnTrueForTimeInRange()
        {
            MyTime time = new MyTime(10, 0, 0);
            MyTime start = new MyTime(9, 0, 0);
            MyTime end = new MyTime(11, 0, 0);
            Assert.IsTrue(time.IsInRange(start, end));
        }

        [Test]
        public void IsInRange_ShouldReturnFalseForTimeOutOfRange()
        {
            MyTime time = new MyTime(8, 0, 0);
            MyTime start = new MyTime(9, 0, 0);
            MyTime end = new MyTime(11, 0, 0);
            Assert.IsFalse(time.IsInRange(start, end));
        }

        [Test]
        public void WhatLesson_ShouldReturnCorrectLesson()
        {
            MyTime time1 = new MyTime(8, 0, 0);
            MyTime time2 = new MyTime(9, 30, 0);
            MyTime time3 = new MyTime(7, 59, 0);
            MyTime time4 = new MyTime(17, 31, 0);

            Assert.AreEqual("1-а пара", MyTime.WhatLesson(time1));
            Assert.AreEqual("Перерва між 1-ю та 2-ю парами", MyTime.WhatLesson(time2));
            Assert.AreEqual("Пари ще не почалися", MyTime.WhatLesson(time3));
            Assert.AreEqual("Пари вже закінчилися", MyTime.WhatLesson(time4));
        }
    }
}