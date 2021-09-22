using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1_ShamirsCode {
    public class Program {
        public static void Main(string[] args) {            
            var userStr = Utils.GetValueFromUser<string>("Enter a string: ");
            
            var numberStr = Utils.StrToNumbers(userStr);
            Console.WriteLine(numberStr);
        
            var splittedStr = Utils.SplitBy(numberStr, 2);
            Console.WriteLine(ListToStr(splittedStr));
        }

        public static string ListToStr(List<string>? list) {
            if (list == null) return string.Empty;

            var result = string.Empty;
            foreach (var item in list) {
                result += item + "\t";
            }

            return result;
        }
    }
}
