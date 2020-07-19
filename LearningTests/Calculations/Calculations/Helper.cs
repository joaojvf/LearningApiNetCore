using System;

namespace Calculations
{
    internal class Helper
    {
        internal static void CheckParameterNotNull(object obj, string msgException, object valueDefault)
        {
            if (obj == null || obj.Equals(valueDefault)) { throw new ArgumentNullException(msgException); }
        }

        internal static void CheckParameterNotNullOrEmpty(string obj, string msgException, string valueDefault)
        {
            if (string.IsNullOrEmpty(obj) || obj.Equals(valueDefault)) { throw new ArgumentNullException(msgException); }
        }
    }
}
