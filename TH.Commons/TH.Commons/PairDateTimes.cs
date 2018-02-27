using System;

namespace TH.Commons
{
    public class PairDateTimes
    {
        public PairDateTimes(DateTime from, DateTime to)
        {
            if (from > to) throw new ArgumentException($"Datetime from '{from:G}' cannot be later than datetime to '{to:G}'.");
            From = from;
            To = to;
        }

        public DateTime From { get; }
        public DateTime To { get; }

        public override string ToString()
        {
            return $"{From:G} - {To:G}";
        }

        public bool IsOverlappingWith(PairDateTimes other)
        {
            if (other.From == To) return false;
            if (other.To == From) return false;
            if (other.From == From) return true;
            if (other.To == To) return true;
            if (other.From > From)
                return other.From < To;
            return other.To > From;
        }
    }
}