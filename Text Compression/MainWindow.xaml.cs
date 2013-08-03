using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Text_Compression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Text;
        List<bool> EncodedList;
        List<UInt16> EncodedText;
        List<char> EncodedByte;
        double[] prop, lows, highs;
        long numbers = 0;
        double result;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Text = Main_Text.Text;
            Compress();
            Encoding();
            Decoder();
            //EncodedByte = new List<byte>();
            //foreach (var i in EncodedText)
            //{
            //    string tmp = i.ToString();
            //    var r = tmp.ToList<char>();
            //    foreach (var j in r)
            //    {
            //        byte h;
            //        Byte.TryParse(j.ToString(), out h);
            //        EncodedByte.Add(h);
            //    }
            //}
        }

        private string Compress()
        {
            EncodedList = new List<bool>();
            EncodedText = new List<UInt16>();
            foreach (char i in Text)
            {
                #region switch
                switch (i)
                {
                    case ' ':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ا':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ب':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ت':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ث':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ج':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ح':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'خ':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'د':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ذ':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ر':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ز':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'س':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ش':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ص':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ض':
                        EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ط':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ظ':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ع':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'غ':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ف':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ق':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ك':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ل':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'م':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ن':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ه':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'و':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ي':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'أ':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'إ':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'آ':
                        EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ى':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ة':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ء':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ؤ':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ئ':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case '،':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case '.':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case ')':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case '(':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case '0':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case '1':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case '2':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case '3':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case '4':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case '5':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case '6':
                        EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case '7':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case '8':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case '9':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'َ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ُ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ِ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ْ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case 'ً':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case 'ٌ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case 'ٍ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case 'ّ':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    case '\n':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                    case '@':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(false);
                        break;
                    case '#':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false); EncodedList.Add(true);
                        break;
                    case '\t':
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(false);
                        break;
                    default:
                        EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true); EncodedList.Add(true);
                        break;
                }
                #endregion
            }
            ushort x;
            int j;
            while (EncodedList.Count % 16 != 0)
                EncodedList.Add(true);
            int y = EncodedList.Count / 16;
            for (j = 0; j < y; j++)
            {
                x = Binary2Int16(EncodedList[j * 16], EncodedList[j * 16 + 1], EncodedList[j * 16 + 2], EncodedList[j * 16 + 3], EncodedList[j * 16 + 4], EncodedList[j * 16 + 5], EncodedList[j * 16 + 6], EncodedList[j * 16 + 7], EncodedList[j * 16 + 8], EncodedList[j * 16 + 9], EncodedList[j * 16 + 10], EncodedList[j * 16 + 11], EncodedList[j * 16 + 12], EncodedList[j * 16 + 13], EncodedList[j * 16 + 14], EncodedList[j * 16 + 15]);
                EncodedText.Add(x);
            }
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Encoded Text|*.ctxt";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                save_data_strucure(SFD.FileName);
                return SFD.FileName;
            }
            return null;
        }

        private ushort Binary2Int16(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13, bool p14, bool p15, bool p16)
        {
            return (UInt16)(32768 * Bo(p1) + 16384 * Bo(p2) + 8192 * Bo(p3) + 4096 * Bo(p4) + 2048 * Bo(p5) + 1024 * Bo(p6) + 512 * Bo(p7) + 256 * Bo(p8) + 128 * Bo(p9) + 64 * Bo(p10) + 32 * Bo(p11) + 16 * Bo(p12) + 8 * Bo(p13) + 4 * Bo(p14) + 2 * Bo(p15) + Bo(p16));
        }

        private void save_data_strucure(string Path)
        {
            Stream Writer = File.Create(Path);
            BinaryWriter Serlizer = new BinaryWriter(Writer);
            Serlizer.Write("CTxt");
            Serlizer.Write(true);
            Serlizer.Write("AraText");
            Serlizer.Write(true);
            Serlizer.Write("Dr.Mohammad");
            Serlizer.Write(true);
            int count = EncodedText.Count;
            Serlizer.Write(count);
            Serlizer.Write(true);
            foreach (ushort i in EncodedText)
                Serlizer.Write(i);
            Writer.Close();
        }

        private ushort Bo(bool p1)
        {
            if (p1)
                return 1;
            else
                return 0;
        }

        private void Encoding()
        {
            Helper();
            double low = 0.0;
            double high = 1;
            double range;
            foreach (var i in EncodedText)
            {
                string tmp = i.ToString();
                var r = tmp.ToList<char>();
                foreach (var j in r)
                {
                    range = high - low;
                    high = low + range * highs[j - 48];
                    low = low + range * lows[j - 48];
                }
                //*
                range = high - low;
                high = low + range * highs[10];
                low = low + range * lows[10];
            }
            result = low;

        }

        private void Helper()
        {
            double high = 1;
            prop = new double[11];
            lows = new double[11];
            highs = new double[11];

            foreach (var i in EncodedText)
            {
                string tmp = i.ToString();
                var r = tmp.ToList<char>();
                foreach (var j in r)
                {
                    if (j.Equals('0'))
                        prop[0]++;
                    else if (j.Equals('1'))
                        prop[1]++;
                    else if (j.Equals('2'))
                        prop[2]++;
                    else if (j.Equals('3'))
                        prop[3]++;
                    else if (j.Equals('4'))
                        prop[4]++;
                    else if (j.Equals('5'))
                        prop[5]++;
                    else if (j.Equals('6'))
                        prop[6]++;
                    else if (j.Equals('7'))
                        prop[7]++;
                    else if (j.Equals('8'))
                        prop[8]++;
                    else if (j.Equals('9'))
                        prop[9]++;
                    numbers++;
                }
                numbers++;
                prop[10]++;
            }
            for (int i = 0; i < 11; i++)
                prop[i] = prop[i] / numbers;
            for (int i = 0; i < 11; i++)
            {
                highs[i] = high;
                lows[i] = highs[i] - prop[i];
                high = lows[i];
            }
        }

        private void Decoder()
        {
            EncodedByte = new List<char>();
            double range;
            char symbol;
            double number = result;
            while (number > 0 && number < 1)
            {
                symbol = Find_Sumbol(number);
                EncodedByte.Add(symbol);
                if (symbol == 94)
                {
                    range = highs[10] - lows[10];
                    number = (number - lows[10]) / range;
                }
                else
                {
                    range = highs[symbol - 48] - lows[symbol - 48];
                    number = (number - lows[symbol - 48]) / range;
                }
            }
        }

        private char Find_Sumbol(double s)
        {
            for (int i = 0; i < 10; i++)
                if (s > lows[i])
                    return i.ToString()[0];
            return '^';
        }
    }
}
