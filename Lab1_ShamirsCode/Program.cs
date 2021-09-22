using System;

namespace Lab1_ShamirsCode {
    public class Program {
        public static void Main(string[] args) {
            try {
                Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;

                var userStr = "наступать";
                //var userStr = Utils.GetValueFromUser<string>("Введите строку: ");
                Console.WriteLine($"\nНачальная строка: {userStr}");

                var userStrCode = Utils.StrToNumbers(userStr);
                Console.WriteLine($"Ее код: {userStrCode}");

                var p = 101;
                var s = MathUtils.GetMutuallySimpleNumber(p - 1);
                var t = MathUtils.ExtendedGcd(s, p - 1).t;
                Console.WriteLine($"\np = {p}\ns = {s}\nt = {t}");

                var encodedUserStr = Utils.EncodeStrCode(userStrCode, p, s);
                Console.WriteLine($"Кодированное сообщение: {encodedUserStr}");

                var decodedUserStr = Utils.EncodeStrCode(encodedUserStr, p, t);
                Console.WriteLine($"\nДекодированное сообщение: {decodedUserStr}");
                Console.WriteLine($"Декодированная строка: {Utils.NumbersToStr(decodedUserStr)}\n");
            } catch (Exception e) {
                ConsoleTools.WriteLine(ConsoleColor.Red, e.Message);
            }
        }
    }
}
