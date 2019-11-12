using System;

namespace InputInspectingElements
{
    public static class BinaryNumberHelper
    {
        private const string ERROR_INVALID_ONE_BINARY_NUMBER_ON_FLAG = "The given flag is not an one-bit-on-flag.";

        /// <summary>
        /// Return true if the given flag has the-one-and-only-on-bit of oneBitOnFlag on.
        /// </summary>
        public static bool IsContainingOneBinaryNumberOnFlag(int flag, int oneBinaryNumberOnFlag)
        {
            if ( !IsOneBinaryNumberOnFlag(oneBinaryNumberOnFlag) )
            {
                throw new ArgumentException(ERROR_INVALID_ONE_BINARY_NUMBER_ON_FLAG);
            }
            return IsContainingFlag(flag, oneBinaryNumberOnFlag);
        }

        /// <summary>
        /// Return true if the given flag has all the on-bit of partialFlag on.
        /// </summary>
        private static bool IsContainingFlag(int flag, int partialFlag)
        {
            return ( flag & partialFlag ) == partialFlag;
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
