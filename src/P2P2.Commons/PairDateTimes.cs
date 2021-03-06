﻿using System;

namespace P2P2.Commons
{
    public class PairDateTimes
    {
        public PairDateTimes(DateTime from, DateTime to)
        {
            if (from > to) throw new ArgumentException($"Datetime from '{from:G}' cannot be later than datetime to '{to:G}'.");
            From = from;
            To = to;
            Duration = To - From;
        }

        public DateTime From { get; }
        public DateTime To { get; }
        public TimeSpan Duration { get; }

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
            return other.From > From
                ? other.From < To
                : other.To > From;
        }

        public TimeSpan GetOverlappingTime(PairDateTimes other)
        {
            if(!IsOverlappingWith(other)) return TimeSpan.Zero;
            return (To < other.To ? To : other.To) - (From > other.From ? From : other.From);
        }
    }
}