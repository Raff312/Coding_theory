using System;

namespace Lab1_ShamirsCode {
    public class Program {
        public static void Main(string[] args) {
            try {
                Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;

                var userStr = Utils.GetValueFromUser<string>("\nВведите строку: ");

                var userStrCode = Utils.StrToNumbers(userStr);
                Console.WriteLine($"Код: {userStrCode}");

                var p = Utils.GetValueFromUser<int>("\nВведите простое число: ");
                var s = MathUtils.GetMutuallySimpleNumber(p - 1);
                var t = MathUtils.ExtendedGcd(s, p - 1).t;
                Console.WriteLine($"\np = {p}\ns = {s}\nt = {t}");

                var encodedUserStr = Utils.TransformStrCode(userStrCode, p, s, true);
                Console.WriteLine($"\nКодированное сообщение: {encodedUserStr}");

                var decodedUserStr = Utils.TransformStrCode(encodedUserStr, p, t, false);
                Console.WriteLine($"\nДекодированное сообщение: {decodedUserStr}");
                Console.WriteLine($"Декодированная строка: {Utils.NumbersToStr(decodedUserStr)}\n");
            } catch (Exception e) {
                ConsoleTools.WriteLine(ConsoleColor.Red, e.Message);
            }
        }
    }
}
