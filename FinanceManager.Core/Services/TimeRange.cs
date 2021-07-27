using System;

namespace FinanceManager.Core.Entities
{
    public record TimeRange
    {
        public static TimeRange Default => new TimeRange(DateTime.MinValue, DateTime.MaxValue);

        private readonly DateTime _start;
        private readonly DateTime _end;

        public TimeRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException($"{nameof(start)} can't be later than {nameof(end)}");

            _start = start;
            _end = end;
        }

        public bool Include(DateTime time) => (_start <= time) && (time <= _end);
    }
}
