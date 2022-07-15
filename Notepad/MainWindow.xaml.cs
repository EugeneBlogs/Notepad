using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filename;
        public bool IsFileChanged;

        public MainWindow()
        {
            InitializeComponent();
            text.FontSize = 12;
            texts.Text = "12";
            Initialize();
        }
        public void Initialize()
        {
            filename = "";
            IsFileChanged = false;
            UpdateTitle();
        }
        public void CreateNewDocument(object sender, EventArgs e)
        {
            SaveUnsaved();
            text.Text = "";
            filename = "";
            IsFileChanged = false;
            UpdateTitle();
        }
        public void CreateNewDocument()
        {
            SaveUnsaved();
            text.Text = "";
            filename = "";
            IsFileChanged = false;
            UpdateTitle();
        }
        public void OpenFile(object sender, EventArgs e)
        {
            SaveUnsaved();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    text.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog.FileName;
                    IsFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть файл! :(");
                }
            }
            UpdateTitle();
        }
        public void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    _filename = saveFileDialog.FileName;
                    _filename += ".txt";
                }
                try
                {
                    StreamWriter sw = new StreamWriter(_filename + ".txt");
                    sw.Write(text.Text);
                    sw.Close();
                    filename = _filename;
                    IsFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл! :(");
                }
            }
            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(_filename + ".txt");
                    sw.Write(text.Text);
                    sw.Close();
                    filename = _filename;
                    IsFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл! :(");
                }
            }
            UpdateTitle();
        }
        public void DeleteFile(string _filename)
        {
            if (_filename == "")
            {
                MessageBox.Show("У вас нет открытых файлов.");
            }
            else
            {
                string message1 = "Удалить данный файл?";
                string caption = "Удаление файла.";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                string result = Convert.ToString(MessageBox.Show(message1, caption, buttons, MessageBoxImage.Asterisk));
                if (result == "Yes")
                {
                    try
                    {
                        FileInfo fileInf = new FileInfo($"{_filename}.txt");
                        fileInf.Delete();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить файл! :(");
                    }
                    CreateNewDocument();
                }
            }
        }
        public void Save(object sender, EventArgs e)
        {
            SaveFile(filename);
        }
        public void SaveAs(object sender, EventArgs e)
        {
            SaveFile("");
        }
        public void Delete(object sender, EventArgs e)
        {
            DeleteFile(filename);
        }
        public void Close(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsFileChanged)
            {
                this.Title = this.Title.Replace('*', ' ');
                IsFileChanged = true;
                this.Title = "*" + this.Title;
            }
            simvol.Text = $"Количество символов: {text.Text.Length}.";
        }
        public void UpdateTitle()
        {
            if (filename != "")
                this.Title = filename + " - Блокнот";
            else
                this.Title = "Безымянный - Блокнот";
        }
        public void SaveUnsaved()
        {
            if (IsFileChanged)
            {
                string message1 = "Сохранить данный файл?";
                string caption = "У вас есть несохранённые изменения.";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                string result = Convert.ToString(MessageBox.Show(message1, caption, buttons, MessageBoxImage.Hand));
                if (result == "Yes")
                {
                    SaveFile(filename);
                }
            }
        }
        public void Copy(object sender, EventArgs e)
        {
            Clipboard.SetText(text.SelectedText);
        }
        public void Cut(object sender, EventArgs e)
        {
            Clipboard.SetText(text.SelectedText);
            text.Text = text.Text.Remove(text.SelectionStart, text.SelectionLength);
        }
        public void Paste(object sender, EventArgs e)
        {
            text.Text = text.Text.Substring(0, text.SelectionStart) + Clipboard.GetText() + text.Text.Substring(text.SelectionStart, text.Text.Length - text.SelectionStart);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveUnsaved();
            Environment.Exit(0);
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            text.FontWeight = FontWeights.Normal;
            text.FontStyle = FontStyles.Normal;
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            text.FontWeight = FontWeights.Bold;
        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            text.FontWeight = FontWeights.Black;
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            text.FontWeight = FontWeights.Light;
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
            text.FontStyle = FontStyles.Italic;
        }

        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            text.FontStyle = FontStyles.Oblique;
        }
        private void Proverkabukv(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Clear();
            foreach (char ch in text.Text)
            {


                switch (ch)
                {
                    case 'q':
                        {
                            sb.Append("й");
                            break;
                        }
                    case 'Q':
                        {
                            sb.Append("Й");
                            break;
                        }
                    case 'w':
                        {
                            sb.Append("ц");
                            break;
                        }
                    case 'W':
                        {
                            sb.Append("Ц");
                            break;
                        }
                    case 'e':
                        {
                            sb.Append("у");
                            break;
                        }
                    case 'E':
                        {
                            sb.Append("У");
                            break;
                        }
                    case 'r':
                        {
                            sb.Append("к");
                            break;
                        }
                    case 'R':
                        {
                            sb.Append("К");
                            break;
                        }
                    case 't':
                        {
                            sb.Append("е");
                            break;
                        }
                    case 'T':
                        {
                            sb.Append("Е");
                            break;
                        }
                    case 'y':
                        {
                            sb.Append("н");
                            break;
                        }
                    case 'Y':
                        {
                            sb.Append("Н");
                            break;
                        }
                    case 'u':
                        {
                            sb.Append("г");
                            break;
                        }
                    case 'U':
                        {
                            sb.Append("Г");
                            break;
                        }
                    case 'i':
                        {
                            sb.Append("ш");
                            break;
                        }
                    case 'I':
                        {
                            sb.Append("Ш");
                            break;
                        }
                    case 'o':
                        {
                            sb.Append("щ");
                            break;
                        }
                    case 'O':
                        {
                            sb.Append("Щ");
                            break;
                        }
                    case 'p':
                        {
                            sb.Append("з");
                            break;
                        }
                    case 'P':
                        {
                            sb.Append("З");
                            break;
                        }
                    case '[':
                        {
                            sb.Append("х");
                            break;
                        }
                    case '{':
                        {
                            sb.Append("Х");
                            break;
                        }
                    case ']':
                        {
                            sb.Append("ъ");
                            break;
                        }
                    case '}':
                        {
                            sb.Append("Ъ");
                            break;
                        }
                    case 'a':
                        {
                            sb.Append("ф");
                            break;
                        }
                    case 'A':
                        {
                            sb.Append("Ф");
                            break;
                        }
                    case 's':
                        {
                            sb.Append("ы");
                            break;
                        }
                    case 'S':
                        {
                            sb.Append("Ы");
                            break;
                        }
                    case 'd':
                        {
                            sb.Append("в");
                            break;
                        }
                    case 'D':
                        {
                            sb.Append("В");
                            break;
                        }
                    case 'f':
                        {
                            sb.Append("а");
                            break;
                        }
                    case 'F':
                        {
                            sb.Append("А");
                            break;
                        }
                    case 'g':
                        {
                            sb.Append("п");
                            break;
                        }
                    case 'G':
                        {
                            sb.Append("П");
                            break;
                        }
                    case 'h':
                        {
                            sb.Append("р");
                            break;
                        }
                    case 'H':
                        {
                            sb.Append("Р");
                            break;
                        }
                    case 'j':
                        {
                            sb.Append("о");
                            break;
                        }
                    case 'J':
                        {
                            sb.Append("О");
                            break;
                        }
                    case 'k':
                        {
                            sb.Append("л");
                            break;
                        }
                    case 'K':
                        {
                            sb.Append("Л");
                            break;
                        }
                    case 'l':
                        {
                            sb.Append("д");
                            break;
                        }
                    case 'L':
                        {
                            sb.Append("Д");
                            break;
                        }
                    case ';':
                        {
                            sb.Append("ж");
                            break;
                        }
                    case ':':
                        {
                            sb.Append("Ж");
                            break;
                        }
                    case '\'':
                        {
                            sb.Append("э");
                            break;
                        }
                    case '"':
                        {
                            sb.Append("Э");
                            break;
                        }
                    case '`':
                        {
                            sb.Append("ё");
                            break;
                        }
                    case '~':
                        {
                            sb.Append("Ё");
                            break;
                        }
                    case 'z':
                        {
                            sb.Append("я");
                            break;
                        }
                    case 'Z':
                        {
                            sb.Append("Я");
                            break;
                        }
                    case 'x':
                        {
                            sb.Append("ч");
                            break;
                        }
                    case 'X':
                        {
                            sb.Append("Ч");
                            break;
                        }
                    case 'c':
                        {
                            sb.Append("с");
                            break;
                        }
                    case 'C':
                        {
                            sb.Append("С");
                            break;
                        }
                    case 'v':
                        {
                            sb.Append("м");
                            break;
                        }
                    case 'V':
                        {
                            sb.Append("М");
                            break;
                        }
                    case 'b':
                        {
                            sb.Append("и");
                            break;
                        }
                    case 'B':
                        {
                            sb.Append("И");
                            break;
                        }
                    case 'n':
                        {
                            sb.Append("т");
                            break;
                        }
                    case 'N':
                        {
                            sb.Append("Т");
                            break;
                        }
                    case 'm':
                        {
                            sb.Append("ь");
                            break;
                        }
                    case 'M':
                        {
                            sb.Append("Ь");
                            break;
                        }
                    case ',':
                        {
                            sb.Append("б");
                            break;
                        }
                    case '<':
                        {
                            sb.Append("Б");
                            break;
                        }
                    case '.':
                        {
                            sb.Append("ю");
                            break;
                        }
                    case '>':
                        {
                            sb.Append("Ю");
                            break;
                        }
                    case '&':
                        {
                            sb.Append("?");
                            break;
                        }
                    case '/':
                        {
                            sb.Append(".");
                            break;
                        }
                    case '?':
                        {
                            sb.Append(",");
                            break;
                        }
                    default:
                        {
                            sb.Append(ch);
                            break;
                        }
                }
            }
            string sbtext = Convert.ToString(sb);
            text.Text = sbtext;
        }
        private void Proverkabukv1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Clear();
            foreach (char ch in text.Text)
            {


                switch (ch)
                {
                    case 'б':
                        {
                            sb.Append(",");
                            break;
                        }
                    case 'ю':
                        {
                            sb.Append(".");
                            break;
                        }
                    case ',':
                        {
                            sb.Append("?");
                            break;
                        }
                    case 'й':
                        {
                            sb.Append("q");
                            break;
                        }
                    case 'Й':
                        {
                            sb.Append("Q");
                            break;
                        }
                    case 'ц':
                        {
                            sb.Append("w");
                            break;
                        }
                    case 'Ц':
                        {
                            sb.Append("W");
                            break;
                        }
                    case 'у':
                        {
                            sb.Append("e");
                            break;
                        }
                    case 'У':
                        {
                            sb.Append("E");
                            break;
                        }
                    case 'к':
                        {
                            sb.Append("r");
                            break;
                        }
                    case 'К':
                        {
                            sb.Append("R");
                            break;
                        }
                    case 'е':
                        {
                            sb.Append("t");
                            break;
                        }
                    case 'Е':
                        {
                            sb.Append("T");
                            break;
                        }
                    case 'н':
                        {
                            sb.Append("y");
                            break;
                        }
                    case 'Н':
                        {
                            sb.Append("Y");
                            break;
                        }
                    case 'г':
                        {
                            sb.Append("u");
                            break;
                        }
                    case 'Г':
                        {
                            sb.Append("U");
                            break;
                        }
                    case 'ш':
                        {
                            sb.Append("i");
                            break;
                        }
                    case 'Ш':
                        {
                            sb.Append("I");
                            break;
                        }
                    case 'щ':
                        {
                            sb.Append("o");
                            break;
                        }
                    case 'Щ':
                        {
                            sb.Append("O");
                            break;
                        }
                    case 'з':
                        {
                            sb.Append("p");
                            break;
                        }
                    case 'З':
                        {
                            sb.Append("P");
                            break;
                        }
                    case 'ф':
                        {
                            sb.Append("a");
                            break;
                        }
                    case 'Ф':
                        {
                            sb.Append("A");
                            break;
                        }
                    case 'ы':
                        {
                            sb.Append("s");
                            break;
                        }
                    case 'Ы':
                        {
                            sb.Append("S");
                            break;
                        }
                    case 'в':
                        {
                            sb.Append("d");
                            break;
                        }
                    case 'В':
                        {
                            sb.Append("D");
                            break;
                        }
                    case 'а':
                        {
                            sb.Append("f");
                            break;
                        }
                    case 'А':
                        {
                            sb.Append("F");
                            break;
                        }
                    case 'п':
                        {
                            sb.Append("g");
                            break;
                        }
                    case 'П':
                        {
                            sb.Append("G");
                            break;
                        }
                    case 'р':
                        {
                            sb.Append("h");
                            break;
                        }
                    case 'Р':
                        {
                            sb.Append("H");
                            break;
                        }
                    case 'о':
                        {
                            sb.Append("j");
                            break;
                        }
                    case 'О':
                        {
                            sb.Append("J");
                            break;
                        }
                    case 'л':
                        {
                            sb.Append("k");
                            break;
                        }
                    case 'Л':
                        {
                            sb.Append("K");
                            break;
                        }
                    case 'д':
                        {
                            sb.Append("l");
                            break;
                        }
                    case 'Д':
                        {
                            sb.Append("L");
                            break;
                        }
                    case 'я':
                        {
                            sb.Append("z");
                            break;
                        }
                    case 'Я':
                        {
                            sb.Append("Z");
                            break;
                        }
                    case 'ч':
                        {
                            sb.Append("x");
                            break;
                        }
                    case 'Ч':
                        {
                            sb.Append("X");
                            break;
                        }
                    case 'с':
                        {
                            sb.Append("c");
                            break;
                        }
                    case 'С':
                        {
                            sb.Append("C");
                            break;
                        }
                    case 'м':
                        {
                            sb.Append("v");
                            break;
                        }
                    case 'М':
                        {
                            sb.Append("V");
                            break;
                        }
                    case 'и':
                        {
                            sb.Append("b");
                            break;
                        }
                    case 'И':
                        {
                            sb.Append("B");
                            break;
                        }
                    case 'т':
                        {
                            sb.Append("n");
                            break;
                        }
                    case 'Т':
                        {
                            sb.Append("N");
                            break;
                        }
                    case 'ь':
                        {
                            sb.Append("m");
                            break;
                        }
                    case 'Ь':
                        {
                            sb.Append("M");
                            break;
                        }
                    default:
                        {
                            sb.Append(ch);
                            break;
                        }
                }
            }
            string sbtext = Convert.ToString(sb);
            text.Text = sbtext;
        }
        private void Proverkabukv2(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Clear();
            foreach (char ch in text.Text)
            {


                switch (ch)
                {
                    case '!':
                        {
                            sb.Append("1");
                            break;
                        }
                    case '"':
                        {
                            sb.Append("2");
                            break;
                        }
                    case '@':
                        {
                            sb.Append("2");
                            break;
                        }
                    case '#':
                        {
                            sb.Append("3");
                            break;
                        }
                    case '№':
                        {
                            sb.Append("3");
                            break;
                        }
                    case '$':
                        {
                            sb.Append("4");
                            break;
                        }
                    case '%':
                        {
                            sb.Append("5");
                            break;
                        }
                    case ';':
                        {
                            sb.Append("4");
                            break;
                        }
                    case '^':
                        {
                            sb.Append("6");
                            break;
                        }
                    case ':':
                        {
                            sb.Append("6");
                            break;
                        }
                    case '?':
                        {
                            sb.Append("7");
                            break;
                        }
                    case '&':
                        {
                            sb.Append("7");
                            break;
                        }
                    case '*':
                        {
                            sb.Append("8");
                            break;
                        }
                    case '(':
                        {
                            sb.Append("9");
                            break;
                        }
                    case ')':
                        {
                            sb.Append("0");
                            break;
                        }
                    default:
                        {
                            sb.Append(ch);
                            break;
                        }
                }
            }
            string sbtext = Convert.ToString(sb);
            text.Text = sbtext;
        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            text.Text = text.Text.ToUpper();
        }

        private void MenuItem_Click_23(object sender, RoutedEventArgs e)
        {
            text.Text = text.Text.ToLower();
        }

        private void MenuItem_Click_24(object sender, RoutedEventArgs e)
        {
            StringBuilder text1 = new StringBuilder(text.Text.Length);
            for (int i = text.Text.Length; i-- != 0;)
                text1.Append(text.Text[i]);
            text.Text = text1.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int a;
            try
            {
                a = Convert.ToInt32(texts.Text);
            }
            catch
            {
                a = 0;
            }
            text.FontSize = a;
        }
        private void znacheniea_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte a = 0;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            byte at = 0;
            byte rt = 0;
            byte gt = 0;
            byte bt = 0;
            if (znacheniea != null)
            {
                a = Convert.ToByte(znacheniea.Value);
            }
            if (znachenier != null)
            {
                r = Convert.ToByte(znachenier.Value);
            }
            if (znachenieg != null)
            {
                g = Convert.ToByte(znachenieg.Value);
            }
            if (znachenieb != null)
            {
                b = Convert.ToByte(znachenieb.Value);
            }
            if (znachenieat != null)
            {
                at = Convert.ToByte(znachenieat.Value);
            }
            if (znacheniert != null)
            {
                rt = Convert.ToByte(znacheniert.Value);
            }
            if (znacheniegt != null)
            {
                gt = Convert.ToByte(znacheniegt.Value);
            }
            if (znacheniebt != null)
            {
                bt = Convert.ToByte(znacheniebt.Value);
            }
            text.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            text.Foreground = new SolidColorBrush(Color.FromArgb(at, rt, gt, bt));
        }
    }
}
