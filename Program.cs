using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0_overloading {
    class Program {
        class custom {
            public int atrib_1, atrib_2;
            public custom() {
                Console.WriteLine("constructor 1");
            }
            public custom(int atrib_1) {
                Console.WriteLine("constructor 2");
                this.atrib_1 = atrib_1;
                this.atrib_2 = 0;
            }
            public custom(int atrib_1, int atrib_2) {
                Console.WriteLine("constructor 3");
                this.atrib_1 = atrib_1;
                this.atrib_2 = atrib_2;
            }
            ~custom() {}

            public int func(int x) {
                return x;
            }
            public int func(int x, int y) {
                return x + y;
            }
            public int func(int x, float y) {
                return x + (int)y;
            }

            public static custom operator +(custom c_1, custom c_2) {
                custom c_res = new custom(
                    c_1.atrib_1 + c_2.atrib_1,
                    c_1.atrib_2 + c_2.atrib_2);
                return c_res;
            }
            public static custom operator -(custom c_1, custom c_2) {
                custom c_res = new custom(
                    c_1.atrib_1 - c_2.atrib_1,
                    c_1.atrib_2 - c_2.atrib_2);
                return c_res;
            }
            public static bool operator >(custom c_1, custom c_2) {
                return c_1.atrib_1 > c_2.atrib_2;
            }
            public static bool operator <(custom c_1, custom c_2) {
                return c_1.atrib_1 < c_2.atrib_2;
            }
            
            public void oper(int x, int y) {
                this.atrib_1 = x + y;
            }
            public void oper(int x) {
                this.atrib_1 = x;
            }
        }
        static void Main(string[] args) {
            custom c_1 = new custom();
            custom c_2 = new custom(5);
            custom c_3 = new custom(3, 6);
            Console.WriteLine(
                "c_1 is empty, c_2 atrib_1 = {0}, c_2 atrib_2 = {1}, c_3 atrib_1 = {2}, c_3 atrib_2 = {3}",
                c_2.atrib_1, c_2.atrib_2, c_3.atrib_1, c_3.atrib_2
            );
            Console.WriteLine(
                "c_2 func 1 = {0}, 2 = {1}, 3 = {2}", c_2.func(2),
                c_2.func(1, 2), c_2.func(1, (int)2.3)
            );
            Console.WriteLine(
                "c_3 func 1 = {0}, 2 = {1}, 3 = {2}", c_3.func(2),
                c_3.func(1, 2), c_3.func(1, (int)2.3)
            );
            custom c_sum = new custom();
            c_sum = c_2 + c_3;
            Console.WriteLine("c_sum atrib_1 = {0}, atrib_2 = {1}", c_sum.atrib_1, c_sum.atrib_2);
            c_sum = c_2 - c_3;
            Console.WriteLine("c_diff atrib_1 = {0}, atrib_2 = {1}", c_sum.atrib_1, c_sum.atrib_2);
            bool c_comp = c_sum > c_3;
            Console.WriteLine(c_comp);
            Console.ReadKey();
        }
    }
}
