using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHelpers
{
    public static class EnumConvertor
    {
        public static int ConvertEnumValueToInt32<T>(this string value) 
        {
            return (int)Enum.Parse(typeof(T), value);
        }
    }
}
