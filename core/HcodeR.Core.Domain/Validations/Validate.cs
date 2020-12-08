using System;
using System.Collections.Generic;

namespace HcodeR.Core.Domain.Validations
{
    public class Validate
    {
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsMaxCharacter(string value, int length)
        {
            return value.Length > length;
        }

        public static bool IsLessThanOrEqualZero(int value)
        {
            return value <= 0;
        }
    }
}
