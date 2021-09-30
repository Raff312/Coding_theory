using System;
using System.Linq;

namespace Lab2_HammingCode {
    partial class Program {
        private class CommandDefinition {
            public string[] Codes { get; }
            public string Description { get; set; }
            public Action Action { get; set; }

            public CommandDefinition(params string[] codes) {
                Codes = codes;
            }
        }

        private static readonly CommandDefinition[] CommandDefinitions = {
            new CommandDefinition("1") {
                Description = "Run",
                Action = Run
            },
            new CommandDefinition("0") {
                Description = "Exit from program",
                Action = null
            }
        };

        private static CommandDefinition GetCommandDefinitionByCode(string code) {
            code = code?.ToLowerInvariant();
            return CommandDefinitions.FirstOrDefault(x => x.Codes.Contains(code));
        }

        private static void Run() {
            var userStr = Utils.GetValueFromUser<string>("Введите строку: ");
            var userStrCode = Utils.StringToBinary(userStr);
            Console.WriteLine($"Двоичный код: {userStrCode}");

            var hammingCode = HammingUtils.GetCode(userStrCode);
            Console.WriteLine($"Код Хэмминга: {hammingCode}");

            var receivedCode = Utils.GetValueFromUser<string>("\nВведите полученный код: ");
            var errorAt = HammingUtils.GetErrorPosition(receivedCode, HammingUtils.DefineRedundantBitsCount(userStrCode));
            Console.WriteLine($"Ошибка в позиции: {errorAt}");

            Utils.FixBit(ref receivedCode, errorAt - 1);
            Console.WriteLine($"Исправленный код: {receivedCode}");
        }
    }
}