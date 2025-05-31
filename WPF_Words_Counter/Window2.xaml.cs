using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_Words_Counter
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void WordsQuantity_Click(object sender, RoutedEventArgs e)
        {
            string inputText = VvediteText.Text;
            int WordCount = CountWords(inputText);
            MessageBox.Show("Количество слов в тексте: " + WordCount);
        }
        private int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                {
                    return 0;
                }

            char[] delimiters = new char[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        
        private void SymbolsFrequency_Click(object sender, RoutedEventArgs e)
        {
            string text = VvediteText.Text;
            int charCount = text.Length;
            MessageBox.Show("Количество символов: " + charCount.ToString());
        }

        private void SymbolsQuantity_Click(object sender, RoutedEventArgs e)
        {
            string text = VvediteText.Text;
            string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordFrequency.OrderByDescending(key => key.Value))
            {
                MessageBox.Show(pair.Key + ": " + pair.Value);
            }
        }

        private void ClearText_Click(object sender, RoutedEventArgs e)
        {
            VvediteText.Text = "";
            VvediteText.Clear();
        }

        private void TextSaving_Click_1(object sender, RoutedEventArgs e)
        {
            string inputText = VvediteText.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
                {
                    SaveList.Items.Add(inputText);
                    VvediteText.Clear();
                }
        }
        private void OutputSavedText_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedText = SaveList.SelectedItem.ToString();
                VvediteText.Text = selectedText;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Я же сказала не выводить! >:(");
            }
        }
    }
}