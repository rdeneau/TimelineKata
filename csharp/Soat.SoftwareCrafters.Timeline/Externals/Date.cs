using System;

namespace Soat.SoftwareCrafters.Timeline.Externals
{
    public class Date : IEquatable<Date>, IComparable<Date>
    {
        public static Date Clone(Date source) => (Date)(DateTime)source;

        private readonly DateTime _value;

        public int Year  => _value.Year;
        public int Month => _value.Month;
        public int Day   => _value.Day;

        public DayOfWeek DayOfWeek => _value.DayOfWeek;
        public int DayOfYear => _value.DayOfYear;

        public Date(int year, int month, int day) => _value = new DateTime(year, month, day);

        public static implicit operator DateTime(Date date) => date._value;
        public static explicit operator Date(DateTime date) => new Date(date.Year,date.Month, date.Day);

        public DateTime AddDays  (double days  ) => _value.AddDays  (days  );
        public DateTime AddMonths(int    months) => _value.AddMonths(months);
        public DateTime AddYears (int    years ) => _value.AddYears (years );

        public int CompareTo(Date other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return DateTime.Compare(_value, other);
        }

        public bool Equals(Date other) => !ReferenceEquals(null, other) && _value == other._value;
        public override bool Equals(object obj) => Equals(obj as Date);
        public override int GetHashCode() => _value.GetHashCode();

        public static bool operator ==(Date left, Date right) => Equals(left, right);
        public static bool operator !=(Date left, Date right) => !Equals(left, right);

        public TypeCode GetTypeCode() => TypeCode.DateTime;
    }
}
