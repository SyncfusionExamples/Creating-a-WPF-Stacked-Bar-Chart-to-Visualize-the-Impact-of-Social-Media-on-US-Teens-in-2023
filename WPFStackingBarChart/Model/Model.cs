using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStackingBarChart
{
    public class Model
    {

        public string Category { get; set; }

        public double AlmostConstantly { get; set; }

        public double SeveralTimesADay { get; set; }

        public double AboutOnceADay { get; set; }

        public double SeveralTimesAWeek { get; set; }

        public double LessOften { get; set; }

        public double DoNotUse { get; set; }

        public Model(string category, double almostConstantly, double severalTimesADay, double aboutOnceADay, double severalTimesAWeek, double lessOften, double doNotUse)
        {
            Category = category;
            AlmostConstantly = almostConstantly;
            SeveralTimesADay = severalTimesADay;
            AboutOnceADay = aboutOnceADay;
            SeveralTimesAWeek = severalTimesAWeek;
            LessOften = lessOften;
            DoNotUse = doNotUse;
        }
    }
}
