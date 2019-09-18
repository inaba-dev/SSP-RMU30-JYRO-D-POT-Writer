using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMU30
{
    public static class Func
    {
        public static double convFromDBVal(object obj)
        {
            return (obj != DBNull.Value) ? Convert.ToDouble(obj) : 0;
        }

        public static long convSec(DateTime _time)
        {
            var dto = new DateTimeOffset(_time.Ticks, new TimeSpan(+09, 00, 00));
            return dto.ToUnixTimeSeconds();
        }

        public static int int2asc(int src)
        {
            if (src < 10) return (src + 0x30);
            else if (src < 16) return ((src - 10) + 0x41);
            else return 0;
        }

        public static int asc2int(int src)
        {
            if (src > 0x40) return (src - 0x41 + 10);
            else if (src >= 0x30) return (src - 0x30);
            else return 0;
        }

        public static bool isFormatValid(string[] _csv)
        {
            //// 日付ォーマットチェック
            DateTime dateTime;
            if (!DateTime.TryParse(_csv[0], out dateTime)) return false;

            ////
            return true;
        }

        public static DateTime convDateTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime;
        }

        public static DateTime RoundDown(DateTime input, TimeSpan interval)
            => new DateTime((((input.Ticks + interval.Ticks) / interval.Ticks) - 1) * interval.Ticks, input.Kind);
    }
}
