using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week04
{
    internal class Time
    {
        protected int hour;
        protected int minute;
        protected int second;
        protected int millisecond;

        public  Time()
        {
             hour = 0;
             minute = 0;
             second = 0;
             millisecond = 0;
        }
        public Time(int h, int m, int s,int ms)
        {
            hour = h;
            minute = m;
            second = s;
            millisecond = ms;
        }

        public void SetTime(int h, int m, int s,int ms)
        {
            hour = h;
            minute = m;
            second = s;
            millisecond = ms;
        }

        public string NowTimeAdd(int ms)
        {
            int totalTime;

            totalTime = hour * 3600*1000 + minute * 60*1000 + second*1000+millisecond+ms;

            hour = totalTime / (3600*1000);
            totalTime = totalTime % (3600*1000);
            minute = totalTime / (60*1000);
            totalTime = totalTime % (60*1000);
            second = totalTime/1000;
            totalTime = totalTime % 1000;
            millisecond = totalTime;

            return hour + ":" + minute + ":" + second + "." + millisecond;

        }
        public string GetStringTime()
        {
            return hour + ":" + minute + ":" + second+"." + millisecond;
        }

    }
}
