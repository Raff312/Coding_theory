namespace Lab1_ShamirsCode {
    public static class Utils {
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
    }
}