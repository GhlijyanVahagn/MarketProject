using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketHelpers
{
    public static class SafeConvertuct
    {

        public static DateTime ConvertToDateTime(this string date)
        {
            DateTime dateResult;
            var isOk=DateTime.TryParse(date,out dateResult);
            return dateResult;
        }

        public static int ConvertToInt32(this string date)
        {
            Int32 dateint;
            Int32.TryParse(date, out dateint);
            return dateint;
        }
        public static decimal ConvertToDecimal(this string date)
        {
            decimal dateint;
            decimal.TryParse(date, out dateint);
            return dateint;
        }
        public static T ConvertTo<T>(this string date)
        {
            T dateResult=default(T);
            MethodInfo method = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });
            if(method!=null)
            {
                object[] args = { date, dateResult };
                object result=method.Invoke(null, args);
                if (result != null)
                    return (T)args[1];
            }
            return dateResult;
        }
    }
}
