using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Configuration;
using System.Web;
using DapperT1.BusinessLogicLayer;

namespace DapperT1
{
    public static class Utility
    {
        
        public static void SendLogToNotify(string LogMessage)
        {
            string token = ConfigurationManager.AppSettings["NotifyToken"];
            isRock.LineNotify.Utility.SendNotify(token, $"\nLOG:{LogMessage}");
        }
        
        public static T GetEnumValueFromDescription<T>(string description)
        {
            //使用方法:
            //var EnumValue = Utility.GetEnumValueFromDescription<YourEnumClass>(description);

            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static string GetEnumDescription(string value,Type type)
        {
            //使用時需傳入Type type = typeof(enumName);

            var name = Enum.GetNames(type)
                            .Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                            .Select(d => d)
                            .FirstOrDefault();

            //// 找無相對應的列舉
            if (name == null)
            {
                return string.Empty;
            }

            //// 利用反射找出相對應的欄位
            var field = type.GetField(name);
            //// 取得欄位設定DescriptionAttribute的值
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //// 無設定Description Attribute, 回傳Enum欄位名稱
            if (customAttribute == null || customAttribute.Length == 0)
            {
                return name;
            }

            //// 回傳Description Attribute的設定
            return ((DescriptionAttribute)customAttribute[0]).Description;
        }
        
        //public static string SearchEnumDescription(Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DescriptionAttribute[] attributes =
        //        (DescriptionAttribute[])fi.GetCustomAttributes(
        //        typeof(DescriptionAttribute),
        //        false);

        //    if (attributes != null &&
        //        attributes.Length > 0)
        //        return attributes[0].Description;
        //    else
        //        return value.ToString();
        //}

        //public static string GetEnumDescription(Enum EnumClass)
        //{
        //    var EnumDescriptions = from MyEnumClass n in Enum.GetValues(typeof(MyEnum))
        //                           select new { ID = (int)n, Name = Enumerations.SearchEnumDescription(n) };
        //    return EnumDescriptions;
        //}
    }
}