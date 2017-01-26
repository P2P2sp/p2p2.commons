using System;

namespace TH.Commons
{
    /// <summary>
    /// Extenstion methods for Guid type
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks if nullable Guid is null or zero
        /// </summary>
        public static bool IsNullOrEmpty(this Guid? value)
        {
            return value == null || value == Guid.Empty;
        }

        /// <summary>
        /// Checks if value of the Guid is zero
        /// </summary>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }
    }
}
