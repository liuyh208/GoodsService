using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static  class DateTimeEx
    {
        /// <summary>
        /// To the string2.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>yyyy-MM-dd HH:mm:ss </returns>
        public static  string ToString2(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

    
    }
}
