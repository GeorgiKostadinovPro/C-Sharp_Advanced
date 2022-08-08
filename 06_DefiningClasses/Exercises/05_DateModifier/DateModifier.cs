using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }

        public string FirstDate
        {
            get { return this.firstDate; }
            private set { this.firstDate = value; }
        }

        public string SecondDate
        {
            get { return this.secondDate; }
            private set { this.secondDate = value; }
        }

        public int GetDaysDifference()
        {
            DateTime firstDate = DateTime.Parse(this.FirstDate, CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.Parse(this.SecondDate, CultureInfo.InvariantCulture);

            TimeSpan daysDifference = firstDate.Subtract(secondDate);
            return Math.Abs(daysDifference.Days);
        }
    }
}
