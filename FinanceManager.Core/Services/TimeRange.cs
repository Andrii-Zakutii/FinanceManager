using System;

namespace FinanceManager.Core.Entities
{
    public record TimeRange
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public TimeRange(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception($"{nameof(start)} can't be later than {nameof(end)}");

            _start = start;
            _end = end;
        }

        public bool Include(DateTime? time) => time == null ? false : Include(time.Value);

        public bool Include(DateTime time) => _start <= time && time <= _end;

        public bool Include(TimeRange range) => range == null ? false : _start <= range._start && range._end <= _end;

        public bool Include(Transaction transaction) => Include(transaction.Time);
    }
}
