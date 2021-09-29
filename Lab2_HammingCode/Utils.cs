using System;
using System.ComponentModel;

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
    }
}