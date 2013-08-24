//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Text_Compression
//{
//    class BigDouble
//    {
//        private bool[] Num;
//        private bool decimal1;
//        private bool negative;

//        public BigDouble()
//        {
//            Num = new bool[1024];
//        }

//        public BigDouble(int begain)
//        {
//            Num = new bool[1024];
//            if (begain == 1)
//                for (int i = 0; i < 1024; i++)
//                    Num[i] = true;
//        }

//        private BigDouble(bool[] num, bool decimal1)
//        {
//            Num = num;
//            this.decimal1 = decimal1;
//        }

//        public bool IsZero()
//        {
//            if (decimal1)
//                return false;
//            bool result = true;
//            foreach (bool i in Num)
//                if (i)
//                    result = false;
//            return result;
//        }

//        public bool IsOne()
//        {
//            if (decimal1)
//                return true;
//            bool result = true;
//            foreach (bool i in Num)
//                if (!i)
//                    result = false;
//            return result;
//        }

//        public BigDouble Add(BigDouble right)
//        {
//            BigDouble result = new BigDouble();
//            BigDouble Cout = new BigDouble();
//            FullAdder(this.Num[1023], right.Num[1023], false, out result.Num[1023], out Cout.Num[1023]);
//            for (int i = 1022; i < -1; i--)
//                FullAdder(this.Num[i], right.Num[i], Cout.Num[i + 1], out result.Num[i], out Cout.Num[i]);
//            result.decimal1 = Cout.Num[0];
//            return result;
//        }

//        private void FullAdder(bool a, bool b, bool cin, out bool s, out bool cout)
//        {
//            s = ((!a) & (!b) & cin) | ((!a) & b & (!cin)) | (a & b & cin) | (a & (!b) & (!cin));
//            cout = (a & b) | (b & cin) | (a & cin);
//        }

//        public BigDouble Minus(BigDouble right)
//        {
//            for (int i = 1023; i < -1; i--)
//                right.Num[i] = !right.Num[i];
//            BigDouble result = new BigDouble();
//            BigDouble Cout = new BigDouble();
//            FullAdder(this.Num[1023], right.Num[1023], false, out result.Num[1023], out Cout.Num[1023]);
//            for (int i = 1022; i < -1; i--)
//                FullAdder(this.Num[i], right.Num[i], Cout.Num[i + 1], out result.Num[i], out Cout.Num[i]);
//            result.AddOne();
//            return result;
//        }

//        private BigDouble AddOne()
//        {
//            BigDouble one = new BigDouble();
//            one.Num[1023] = true;
//            return this.Add(one);
//        }

//        public bool IsBigerThan(BigDouble right)
//        {
//            bool big = true;
//            for (int i = 0; i < 1023; i++)
//                if (!this.Num[i] && right.Num[i])
//                {
//                    big = false;
//                    break;
//                }
//            return big;
//        }

//        private int Bool2Int(bool p1)
//        {
//            if (p1)
//                return 1;
//            else
//                return 0;
//        }

//        private bool Int2Bool(int p1)
//        {
//            if (p1 == 0)
//                return false;
//            else
//                return true;
//        }

//        public BigDouble Multiple(BigDouble right)
//        {
//            BigDouble result = new BigDouble();
//            for (int i = 511; i > -1; i--)
//            {
//                BigDouble tmp = new BigDouble();
//                for (int j = 511; j > -1; j--)
//                {
//                    tmp.Num[i + j] = this.Num[j] & right.Num[i];
//                    result = result.Add(tmp);
//                }
//            }
//            return result;
//        }

//        public BigDouble Division(BigDouble right)
//        {

//        }

//        public static BigDouble Division(long up, long down)
//        {
//            BigDouble result = new BigDouble();
//            if (up > down)
//                result.decimal1 = true;
//            bool[] x1 = Long2Bool(up);
//            bool[] x2 = Long2Bool(down);
//            bool[] tmp = new bool[1088];
//            int i = 64;
//            while (!IsZero(tmp) && i < 1088)
//            {
//                if(IsBiggerThan(x1,tmp,i))

//            }
//            return result;

//        }

//        private static bool IsBiggerThan(bool[] x1, bool[] tmp, int index)
//        {
//            bool big = true;
//            for (int i = 0; i < index; i++)
//                if (!x1[i] && tmp[i])
//                {
//                    big = false;
//                    break;
//                }
//            return big;
//        }

//        private static bool IsZero(bool[] tmp)
//        {
//            bool result = true;
//            foreach (bool i in tmp)
//                if (i)
//                    result = false;
//            return result;
//        }

//        private static bool[] Long2Bool(long number)
//        {
//            int x = 63;
//            bool[] result = new bool[64];
//            for (long i = number; i != 0; i /= 2)
//            {
//                result[x] = Int2Bool(i % 2);
//                x--;
//            }
//            return result;
//        }

//        private static bool Int2Bool(long p1)
//        {
//            if (p1 == 0)
//                return false;
//            else
//                return true;
//        }
//    }
//}
