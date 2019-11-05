using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputInspectingElements
{
    public static class BitHelper
    {
        /// <summary>
        /// Return true if the given flag has the-one-and-only-on-bit of oneBitOnFlag on.
        /// </summary>
        public static bool IsContainingOneBitOnFlag(int flag, int oneBitOnFlag)
        {
            return ( flag & oneBitOnFlag ) == oneBitOnFlag;
        }

        /// <summary>
        /// Return true if the flag has only one bit on.
        /// </summary>
        private static bool IsOneBitOnFlag(int flag)
        {
            return (flag & ( flag - 1 )) == 0;
        }
    }
}
