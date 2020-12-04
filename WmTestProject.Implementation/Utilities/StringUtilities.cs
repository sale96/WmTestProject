using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Implementation.Utilities
{
    public static class StringUtilities
    {
        public static bool IsTotalyEmpty(this string providedString)
            => string.IsNullOrEmpty(providedString) || string.IsNullOrWhiteSpace(providedString);
    }
}
