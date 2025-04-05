using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WordsCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = VvediteText.Text;
            string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            MessageBox.Show("Количество слов в тексте: " + wordCount.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = VvediteText.Text;
            int charCount = text.Length;
            MessageBox.Show("Количество символов: " + charCount.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = VvediteText.Text.ToLower();
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
    }
}
