using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Text;
        List<bool> EncodedList;
        List<UInt16> EncodedText;
        List<bool> DecodedList;
        List<UInt16> DecodedText;
        StringBuilder DecompredText;
        string path;
        Encoding Encode;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string Path)
        {
            path = Path;
            Encode = Encoding.UTF8;
            InitializeComponent();
        }

        private void Compress_Click_1(object sender, RoutedEventArgs e)
        {
            Text = TextBox1.Text;
            Compress();
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
            if (SFD.ShowDialog() == true)
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

        private ushort Bo(bool p1)
        {
            if (p1)
                return 1;
            else
                return 0;
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

        private void Decompress_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Encoded Text|*.ctxt";
            if (OFD.ShowDialog() == true)
            {
                Read_data_strucure(OFD.FileName);
                TextBlock1.Text = DecompredText.ToString();
            }
        }

        private void Read_data_strucure(string path)
        {
            DecodedList = new List<bool>();
            DecodedText = new List<UInt16>();
            DecompredText = new StringBuilder(String.Empty);
            Stream OpendFile = File.OpenRead(path);
            BinaryReader DeSerializer = new BinaryReader(OpendFile);
            if (DeSerializer.ReadString().Contains("CTxt"))
            {
                DeSerializer.ReadBoolean();
                var Language = DeSerializer.ReadString();
                DeSerializer.ReadBoolean();
                DeSerializer.ReadString();
                DeSerializer.ReadBoolean();
                int count = DeSerializer.ReadInt32();
                var f = DeSerializer.ReadBoolean();
                for (int i = 0; i < count; i++)
                    DecodedText.Add(DeSerializer.ReadUInt16());
                foreach (var i in DecodedText)
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
            else
                MessageBox.Show("ملف خاطئ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            OpendFile.Close();
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

        private void Compress_File_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Plan Text|*.txt";
            if (OFD.ShowDialog() == true)
            {
                Stream St = File.OpenRead(OFD.FileName);
                StreamReader SR = new StreamReader(St);
                Text = SR.ReadToEnd();
                string pa = Compress();
                MessageBox.Show("Done\nComressed File \"" + OFD.FileName + "\" to \"" + pa + "\"", "Compress File", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Error", "Compress File", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void Decompress_to_File_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Encoded Text|*.ctxt";
            if (OFD.ShowDialog() == true)
                Read_data_strucure(OFD.FileName);
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Plan Text|*.txt";
            if (SFD.ShowDialog() == true)
            {
                Stream S = File.OpenWrite(SFD.FileName);
                StreamWriter SW = new StreamWriter(S, Encode);
                SW.Write(DecompredText.ToString());
                SW.Close();
                MessageBox.Show("Done\nDecomressed File \"" + OFD.FileName + "\" to \"" + SFD.FileName + "\"", "Compress File", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Error", "Compress File", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path))
            {
                DecodedList = new List<bool>();
                DecodedText = new List<UInt16>();
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "Encoded Text|*.ctxt";
                if (OFD.ShowDialog() == true)
                    Read_data_strucure(OFD.FileName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    Encode = Encoding.ASCII;
                    break;
                case 1:
                    Encode = Encoding.BigEndianUnicode;
                    break;
                case 2:
                    Encode = Encoding.Unicode;
                    break;
                case 3:
                    Encode = Encoding.UTF32;
                    break;
                case 4:
                    Encode = Encoding.UTF7;
                    break;
                default:
                    Encode = Encoding.UTF8;
                    break;
            }
        }
    }
}