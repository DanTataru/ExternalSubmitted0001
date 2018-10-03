//using Humanizer;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DatatableActivities.Extensions
{
	public static class EnumExtensions
	{
		public static IEnumerable<T> GetEnumItems<T>()
		{
			return System.Enum.GetValues(typeof (T)).Cast<T>();
		}

		public static string[] AsStringArray<T>()
		{
			return System.Enum.GetValues(typeof(T)).Cast<T>().Select(e=>e.ToString()).ToArray();
		}

		public static T GetEnum<T>(object o)
		{
			return (T)System.Enum.Parse(typeof(T), o.ToString());
		}

        public static T? ToNullable<T>(this string s) where T : struct
        {
            var result = new T?();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }

        //public static Dictionary<string, int> GetEnumItemsAsDictionary<T>()
        //{
        //    var enumDictionary = new Dictionary<string, int>();
        //    foreach (var item in Enum.GetValues(typeof(T)))
        //    {
        //        enumDictionary.Add((item as Enum).Humanize(), (int)item);
        //    }
        //    return enumDictionary;
        //}

        public static string GetDescription<T>(int value)
        {
            var type = typeof(T);
            string item = System.Enum.ToObject(type, value).ToString();
            var memInfo = type.GetMember(item);
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
                return ((DescriptionAttribute)attributes[0]).Description;
            else
                return item;
        }
    }
}
