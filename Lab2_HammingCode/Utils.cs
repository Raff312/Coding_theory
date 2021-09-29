using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace Lab2_HammingCode {
    public static class Utils {
        public static T Convert<T>(this string input) {
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
                    return userAnswer.Convert<T>();
                } catch (Exception) {
                    ConsoleTools.WriteLine(ConsoleColor.Red, "Invalid value type. Try again...");
                }
            }
        }

        public static string StrToNumbers(string str) {
            return str.ToCharArray().Aggregate(string.Empty, (current, ch) => current + RuCharToInt(ch));
        }

        private static string RuCharToInt(char ch) {
            return ch != ' ' ? (char.ToUpper(ch) - ('А' - 1)).ToString("00") : "00";
        }

        public static string NumbersToStr(string numberStr) {
            var numbersList = SplitBy(numberStr, 2);
            return numbersList.Aggregate(string.Empty, (current, item) => current += RuNumberToChar(Utils.Convert<int>(item)))
                .ToLower().Trim();
        }

        private static char RuNumberToChar(int num) {
            return num == 0 ? ' ' : (char)(num + 'А' - 1);
        }

        public static string TransformStrCode(string strCode, int simpleNum, int exponent, bool encode) {
            var splittedStrCode = SplitBy(strCode, encode ? 2 : simpleNum.ToString().Length);
            var encodedSplittedStrCode = TransformStrParts(splittedStrCode, simpleNum, exponent, encode);
            return encodedSplittedStrCode.Aggregate(string.Empty, (current, item) => current += item);
        }

        private static List<string> SplitBy(string str, int count) {
            var result = new List<string>();
            
            if (str.Length < count) {
                return result;
            }

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

        private static List<string> TransformStrParts(List<string> parts, int simpleNum, int exponent, bool encode) {
            var format = GetFormat(simpleNum);
            var result = new List<string>();
            foreach (var str in parts) {
                var num = Utils.Convert<int>(str);
                var encodeNum = BigInteger.ModPow(num, exponent, simpleNum);
                result.Add(encodeNum.ToString(encode ? format : "00"));
            }
            return result;
        }

        public static string ListToStr(List<string> list) {
            return list == null ? string.Empty : list.Aggregate(string.Empty, (current, item) => current + (item + "\t"));
        }

        private static string GetFormat(int num) {
            var digitsNum = num.ToString().Length;
            var result = string.Empty;
            for (var i = 0; i < digitsNum; i++) {
                result += "0";
            }

            return result;
        }
    }
}