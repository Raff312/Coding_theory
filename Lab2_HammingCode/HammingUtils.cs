using System;
using System.Collections.Generic;

namespace Lab2_HammingCode {
    public static class HammingUtils {
        public static int GetErrorPosition(string data, int parityBitsCount) {
            var errorPosition = "";
            for (var i = parityBitsCount - 1; i >= 0; i--) {
                var bitPositions = GetBitPositions((int)Math.Pow(2, i), data.Length, true);
                errorPosition += GetParityFromReceived(data, bitPositions);
            }

            return Convert.ToInt32(errorPosition, 2);
        }

        private static string GetParityFromReceived(string data, IEnumerable<int> bitPositions) {
            var countOfOnes = 0;
            foreach (var pos in bitPositions) {
                if (data[pos - 1].ToString() == "1") {
                    countOfOnes++;
                }
            }

            return IsEven(countOfOnes) ? "0" : "1";
        }

        public static string GetCode(string data) {
            var redundantBitsCount = DefineRedundantBitsCount(data);
            var codeLength = data.Length + redundantBitsCount;
            var hammingCode = "";

            var initialDataIterator = 0;
            for (var i = 0; i < codeLength; i++) {
                if (IsPowerOfTwo(i + 1)) {
                    var bitPositions = GetBitPositions(i + 1, codeLength);
                    hammingCode += GetParity(data, bitPositions);
                } else {
                    hammingCode += data[initialDataIterator];
                    initialDataIterator++;
                }
            }

            return hammingCode;
        }

        public static int DefineRedundantBitsCount(string data) {
            return (int)Math.Floor(Math.Log2(data.Length) + 1);
        }

        private static bool IsPowerOfTwo(int num) {
            return num != 0 && (num & (num - 1)) == 0;
        }

        private static IEnumerable<int> GetBitPositions(int parityBit, int maxPos, bool firstBitNeeded = false) {
            var bitPositions = new List<int>();

            var k = 1;
            var position = parityBit;
            while (position <= maxPos) {
                for (var i = position; i < position + parityBit; i++) {
                    if (i == parityBit && !firstBitNeeded) {
                        continue;
                    }

                    if (i > maxPos) {
                        return bitPositions;
                    }

                    bitPositions.Add(i);
                }

                k++;
                position = (2 * k - 1) * parityBit;
            }

            return bitPositions;
        }

        private static string GetParity(string data, IEnumerable<int> bitPositions) {
            var countOfOnes = 0;
            foreach (var pos in bitPositions) {
                var val = (int)(Math.Log2(pos) + 1);
                if (data[pos - val - 1].ToString() == "1") {
                    countOfOnes++;
                }
            }

            return IsEven(countOfOnes) ? "0" : "1";
        }

        private static bool IsEven(int num) {
            return (num & 1) == 0;
        }
    }
}