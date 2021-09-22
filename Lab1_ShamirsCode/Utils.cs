using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab1_ShamirsCode {
    public static class Utils {
        public static T Convert<T>(this string? input) {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter == null) {
                throw new Exception();
            }

            return (T)converter.ConvertFromString(input);
        }

        public static T GetValueFromUser<T>(string msg) {
            while (true) {
                Console.Write(msg);
                var userAnswer = Console.ReadLine();
                try {
                    return Utils.Convert<T>(userAnswer);
                } catch (Exception) {
                    ConsoleTools.WriteLine(ConsoleColor.Red, "Invalid value type. Try again...");
                }
            }
        }
        
        public static int GetMutuallySimple(int value) {
            for (var i = 2; i < value; i++) {
                if (value % i == 1) {
                    return i;
                }
            }

            throw new System.Exception($"There is no mutually simple number for value = {value}");
        }

        public static (int gcd, int t) ExtendedGcd(int a, int b) {
            if (a < b) {
                Swap<int>(ref a, ref b);
            }

            var u = (u1: a, u2: 0);
            var v = (v1: b, v2: 1);
            while (v.v1 != 0) {
                var r = u.u1 / v.v1;
                var t = (u.u1 % v.v1, u.u2 - r * v.v2);
                u = v;
                v = t;
            }

            if (u.u2 < 0) {
                u.u2 += a;
            }

            return u;
        }

        public static void Swap<T> (ref T lhs, ref T rhs) {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static string StrToNumbers(string str) {
            var result = string.Empty;
            foreach(var ch in str.ToCharArray()) {
                result += RuCharToInt(ch);
            }

            return result;
        }

        private static string RuCharToInt(char ch) {
            return ch != ' ' ? (char.ToUpper(ch) - ('A' - 1)).ToString("00") : "00";
        }

        public static List<string>? SplitBy(string str, int count) {
            if (str.Length < count) return null;

            var result = new List<string>();

            var countOfParts = (int)Math.Ceiling(str.Length / (double)count);

            var extraCharsCount = countOfParts * count % str.Length;
            for (var i = 0; i < extraCharsCount; i++) {
                str += "00";
            }

            for (var i = 0; i < countOfParts; i++) {
                result.Add(str.Substring(i * count, count));
            }

            return result;
        }
    }
}