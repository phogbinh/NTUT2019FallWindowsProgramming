namespace InputInspectingElements
{
    public static class BinaryNumberHelper
    {
        /// <summary>
        /// Return true if the given flag has the-one-and-only-on-bit of oneBitOnFlag on.
        /// </summary>
        public static bool IsContainingOneBinaryNumberOnFlag(int flag, int oneBinaryNumberOnFlag)
        {
            return ( flag & oneBinaryNumberOnFlag ) == oneBinaryNumberOnFlag;
        }

        /// <summary>
        /// Return true if the flag has only one bit on.
        /// </summary>
        private static bool IsOneBinaryNumberOnFlag(int flag)
        {
            return ( flag & ( flag - 1 ) ) == 0;
        }
    }
}
