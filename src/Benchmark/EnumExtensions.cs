using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    internal static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum enumeration)
        {
            var attribute = GetText<DescriptionAttribute, TEnum>(enumeration);

            return attribute?.Description ?? enumeration.ToString();
        }

        public static T GetText<T, TEnum>(TEnum enumeration) where T : Attribute
        {
            var type = enumeration.GetType();

            var memberInfo = type.GetMember(enumeration.ToString());

            if (!memberInfo.Any())
                throw new ArgumentException($"No public members for the argument '{enumeration}'.");

            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

            if (attributes == null || attributes.Length != 1)
            {
                return null;
                //throw new ArgumentException(
                //    $"Can't find an attribute matching '{typeof(T).Name}' for the argument '{enumeration}'");
            }

            return attributes.Single() as T;
        }
    }
}
