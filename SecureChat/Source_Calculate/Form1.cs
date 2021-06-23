using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Calculate
{
    public class GFG
    {
        //generate an odd integer randomly
        public static long generate_OddNumber()
        {
            Random random = new Random();
            long ans = (long)random.Next(1000, 99999);
            if (ans % 2 == 0)
                generate_OddNumber();
            return ans;


        }
        public static long generate_Prime()
        {
            long p = 4; //generate a random number
            while (isPrime(p) == false) // number generated will be check if is prime,if false regenerate another random number
            {
                p = generate_OddNumber();
            }
            return p;
        }
        // Returns true if n is prime
        public static bool isPrime(long n)
        {

            //để kiểu dữ liệu long double
            /* Miller-Rabin algorithm*/
            if (n == 2 || n == 3)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;
            long s = n - 1;
            while (s % 2 == 0)
                s >>= 1;
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                //double a = r.Next((int)n - 1) + 1;
                long a = r.Next((int)n - 1) + 1;
                long temp = s;
                long x = ModuloPower(a, temp, n);
                while (temp != n - 1 && x != 1 && x != n - 1)
                {
                    x = (x * x) % n;
                    temp = temp * 2;
                }
                if (x != n - 1 && temp % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // (a^b) %n
        public static long ModuloPower(long x, long y, long p)
        {
            long res = 1;
            for (int i = 0; i < y; i++)
                res = (res * x) % p;
            return res;
        }
        public static long power(long x, long y, long p)
        {
            long res = 1;     // Initialize result

            x = x % p; // Update x if it is more than or equal to p

            while (y > 0)
            {
                // If y is odd, multiply x with result
                if (y % 2 == 1)
                {
                    res = (res * x) % p;
                }

                // y must be even now
                y = y >> 1; // y = y/2
                x = (x * x) % p;
            }
            return res;
        }

        // Utility function to store prime factors of a number
        public static void findPrimefactors(HashSet<long> s, long n)
        {
            // Print the number of 2s that divide n
            while (n % 2 == 0)
            {
                s.Add(2);
                n = n / 2;
            }

            // n must be odd at this point. So we can skip one element (Note i = i +2)
            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                // While i divides n, print i and divide n
                while (n % i == 0)
                {
                    s.Add(i);
                    n = n / i;
                }
            }

            // This condition is to handle the case when n is a prime number greater than 2
            if (n > 2)
            {
                s.Add(n);
            }
        }

        // Function to find smallest primitive root of n
        public static long findPrimitive(long n)
        {
            HashSet<long> s = new HashSet<long>();

            // Check if n is prime or not
            if (isPrime(n) == false)
            {
                return -1;
            }

            // Find value of Euler Totient function of n
            // Since n is a prime number, the value of Euler
            // Totient function is n-1 as there are n-1
            // relatively prime numbers.
            long phi = n - 1;

            // Find prime factors of phi and store in a set
            findPrimefactors(s, phi);

            // Check for every number from 2 to phi
            for (long r = 2; r <= phi; r++)
            {
                bool flag = true;
                foreach (long a in s)
                {

                    // Check if r^((phi)/primefactors) mod n
                    // is 1 or not
                    if (power(r, phi / (a), n) == 1)
                    {
                        flag = true;
                        break;
                    }
                }

                // If there was no power with value 1.
                if (flag == true)
                {
                    return r;
                }
            }

            // If no primitive root found
            return -1;
        }

        public static long PrimitiveRoot(long p)
        {

            List<long> root = new List<long>();
            long phi = p - 1, n = phi;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    root.Add(i);
                    while (n % i == 0)
                        n /= i;
                }
            }
            if (n > 1)
                root.Add(n);
            for (long res = p - 1; res >= 2; res--)
            {
                bool ok = true;
                for (int i = 0; i < root.Count() && ok; ++i)
                {
                    ok &= power(res, phi / root[i], p) != 1;

                }
                if (ok) return res;
            }
            return -1;
        }
    }
    
}
