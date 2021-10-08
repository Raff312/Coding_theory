using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab2_HammingCode {
    public static class Utils {
        public static T GetValueFromUser<T>(string msg) {
            while (true) {
                Console.Write(msg);
                var userAnswer = Console.ReadLine();
                try {
                    return userAnswer.Convert<T>();
                } catch (Exception) {
                    ConsoleTools.WriteLine(ConsoleColor.Red, "Invalid value type. Try again...");
                }
            }
        }

        public static T Convert<T>(this string input) {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter == null) {
                throw new Exception();
            }

            return (T)converter.ConvertFromString(input);
        }

        public static string StringToBinary(string data) {
            var builder = new StringBuilder();
            foreach (var ch in data.ToCharArray()) {
                builder.Append(System.Convert.ToString(ch, 2).PadLeft(16, '0'));
            }
            return builder.ToString();
        }

        public static string BinaryToString(string data) {
            var list = new List<int>();
            for (int i = 0; i < data.Length; i += 16) {
                list.Add(System.Convert.ToInt32(data.Substring(i, 16), 2));
            }
            return list.Aggregate(string.Empty, (cur, value) => cur += (char)value);
        }

        public static void FixBit(ref string data, int pos) {
            if (pos < 0) {
                return;
            }
            
            var builder = new StringBuilder(data);
            builder.Remove(pos, 1);
            builder.Insert(pos, data[pos] == '0' ? '1' : '0');
            data = builder.ToString();
        }
    }
}