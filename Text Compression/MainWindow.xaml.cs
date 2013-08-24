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
using System.Numerics;

namespace Text_Compression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Text;
        List<bool> EncodedList;
        List<bool> DecodedList;
        List<UInt16> EncodedText;
        List<char> EncodedByte;
        long[] freq;
        BigInteger[] prop, lows, highs;
        long numbers = 0;
        BigInteger result;
        StringBuilder DecompredText = new StringBuilder(string.Empty);
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
            string b = string.Empty;
            List<UInt16> UnEncodedText = new List<ushort>();
            foreach(var i in EncodedByte)
            {
                if (i == '^')
                {
                    ushort tmp;
                    ushort.TryParse(b, out tmp);
                    UnEncodedText.Add(tmp);
                    b = string.Empty;
                }
                else
                    b += i;
            }
            DecompredText = new StringBuilder(string.Empty);
            DecodedList = new List<bool>();
            Decompress(UnEncodedText);
            System.Windows.MessageBox.Show(DecompredText.ToString(), "Done", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Decompress(List<UInt16> UnEncodedText)
        {
            foreach (var i in UnEncodedText)
                Int16toBinary(i);
            #region IF
            for (int i = 0; i < DecodedList.Count / 6; i++)
            {
                if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append(' ');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ا');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ب');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ت');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ث');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ج');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ح');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('خ');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('د');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ذ');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ر');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ز');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('س');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ش');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ص');
                else if (!DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ض');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ط');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ظ');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ع');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('غ');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ف');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ق');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ك');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ل');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('م');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ن');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ه');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('و');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ي');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('أ');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('إ');
                else if (!DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('آ');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ى');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ة');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ء');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ؤ');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ئ');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append(',');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('.');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append(')');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('(');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('0');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('1');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('2');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('3');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('4');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('5');
                else if (DecodedList[i * 6] && !DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('6');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('7');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('8');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('9');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('َ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ُ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ِ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ْ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && !DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ً');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ٌ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('ْ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('ّ');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && !DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('\n');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('@');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && !DecodedList[i * 6 + 4] && DecodedList[i * 6 + 5])
                    DecompredText.Append('#');
                else if (DecodedList[i * 6] && DecodedList[i * 6 + 1] && DecodedList[i * 6 + 2] && DecodedList[i * 6 + 3] && DecodedList[i * 6 + 4] && !DecodedList[i * 6 + 5])
                    DecompredText.Append('\t');
            }
            #endregion
        }

        private void Int16toBinary(ushort i)
        {
            bool[] tmp = new bool[16];
            tmp[0] = !(i % 2 == 0); i /= 2;
            tmp[1] = !(i % 2 == 0); i /= 2;
            tmp[2] = !(i % 2 == 0); i /= 2;
            tmp[3] = !(i % 2 == 0); i /= 2;
            tmp[4] = !(i % 2 == 0); i /= 2;
            tmp[5] = !(i % 2 == 0); i /= 2;
            tmp[6] = !(i % 2 == 0); i /= 2;
            tmp[7] = !(i % 2 == 0); i /= 2;
            tmp[8] = !(i % 2 == 0); i /= 2;
            tmp[9] = !(i % 2 == 0); i /= 2;
            tmp[10] = !(i % 2 == 0); i /= 2;
            tmp[11] = !(i % 2 == 0); i /= 2;
            tmp[12] = !(i % 2 == 0); i /= 2;
            tmp[13] = !(i % 2 == 0); i /= 2;
            tmp[14] = !(i % 2 == 0); i /= 2;
            tmp[15] = !(i % 2 == 0);
            for (int n = 15; n > -1; n--)
                DecodedList.Add(tmp[n]);
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
            BigInteger low = new BigInteger(0);
            BigInteger ten_power_1000 = new BigInteger(1);
            for (int i = 0; i < 1000; i++)
                ten_power_1000 = ten_power_1000 * 10;
            BigInteger high = new BigInteger(1);
            for (int i = 0; i < 1000; i++)
                high = high * 10;
            BigInteger range;
            foreach (var i in EncodedText)
            {
                string tmp = i.ToString();
                var r = tmp.ToList<char>();
                foreach (var j in r)
                {
                    range = high - low;
                    high = low + (range * highs[j - 48] / ten_power_1000);
                    low = low + (range * lows[j - 48] / ten_power_1000);
                }
                //*
                range = high - low;
                high = low + (range * highs[10] / ten_power_1000);
                low = low + (range * lows[10] / ten_power_1000);
            }
            result = low;
        }

        private void Helper()
        {
            BigInteger high = new BigInteger(1);
            for (int i = 0; i < 1000; i++)
                high = high * 10;
            prop = new BigInteger[11];
            freq = new long[11];
            lows = new BigInteger[11];
            highs = new BigInteger[11];
            foreach (var i in EncodedText)
            {
                string tmp = i.ToString();
                var r = tmp.ToList<char>();
                foreach (var j in r)
                {
                    if (j.Equals('0'))
                        freq[0]++;
                    else if (j.Equals('1'))
                        freq[1]++;
                    else if (j.Equals('2'))
                        freq[2]++;
                    else if (j.Equals('3'))
                        freq[3]++;
                    else if (j.Equals('4'))
                        freq[4]++;
                    else if (j.Equals('5'))
                        freq[5]++;
                    else if (j.Equals('6'))
                        freq[6]++;
                    else if (j.Equals('7'))
                        freq[7]++;
                    else if (j.Equals('8'))
                        freq[8]++;
                    else if (j.Equals('9'))
                        freq[9]++;
                    numbers++;
                }
                numbers++;
                freq[10]++;
            }
            BigInteger ten_power_1000 = new BigInteger(1);
            for (int i = 0; i < 1000; i++)
                ten_power_1000 = ten_power_1000 * 10;
            for (int i = 0; i < 11; i++)
                prop[i] = ten_power_1000 * freq[i];
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
            BigInteger range = new BigInteger(0);
            char symbol;
            BigInteger number = result;
            BigInteger ten_power_1000 = new BigInteger(1);
            for (int i = 0; i < 1000; i++)
                ten_power_1000 = ten_power_1000 * 10;
            long jj = 0;
            while (/*number < ten_power_1000 && number > 0*/jj < numbers)
            {
                symbol = Find_Sumbol(number);
                EncodedByte.Add(symbol);
                if (symbol == 94)
                {
                    range = highs[10] - lows[10];
                    number = (number - lows[10]) * ten_power_1000 / range;
                }
                else
                {
                    range = highs[symbol - 48] - lows[symbol - 48];
                    number = (number - lows[symbol - 48]) * ten_power_1000 / range;
                }
                jj++;
            }
        }

        private char Find_Sumbol(BigInteger s)
        {
            for (int i = 0; i < 10; i++)
                if (s > lows[i])
                    return i.ToString()[0];
            return '^';
        }
    }
}
