using System;

namespace InputInspectingElements
{
    public static class BinaryNumberHelper
    {
        private const string ERROR_FLAG_IS_NOT_ONE_BINARY_NUMBER_ON_FLAG = "The given flag is not an one-bit-on-flag.";
        private const string ERROR_FLAG_IS_NOT_POSITIVE = "The given flag is not positive.";

        /// <summary>
        /// Return true if the given flag has the-one-and-only-on-bit of oneBitOnFlag on.
        /// </summary>
        public static bool IsContainingOneBinaryNumberOnFlag(int flag, int oneBinaryNumberOnFlag)
        {
            if ( !IsOneBinaryNumberOnFlag(oneBinaryNumberOnFlag) )
            {
                throw new ArgumentException(ERROR_FLAG_IS_NOT_ONE_BINARY_NUMBER_ON_FLAG);
            }
            return IsContainingFlag(flag, oneBinaryNumberOnFlag);
        }

        /// <summary>
        /// Return true if the positive flag has only one bit on.
        /// </summary>
        private static bool IsOneBinaryNumberOnFlag(int positiveFlag)
        {
            if ( positiveFlag <= 0 )
            {
                throw new ArgumentException(ERROR_FLAG_IS_NOT_POSITIVE);
            }
            return ( positiveFlag & ( positiveFlag - 1 ) ) == 0;
        }

        /// <summary>
        /// Return true if the given flag has all the on-bit of partialFlag on.
        /// </summary>
        private static bool IsContainingFlag(int flag, int partialFlag)
        {
            return ( flag & partialFlag ) == partialFlag;
        }
    }
}
