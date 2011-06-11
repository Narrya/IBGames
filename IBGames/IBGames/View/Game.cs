using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using System.Security.Cryptography;
using System.Timers;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace IBGames
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Game : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private ArrayList numbers = new ArrayList();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, int> dictionaryNumbers = new Dictionary<string,int>();

        /// <summary>
        /// 
        /// </summary>
        private string _username = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int ClicksCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int[] SelectedCards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Game(string username)
        {
            InitializeComponent();
            CreateButtons();

            _username = username;

            ClicksCount = 0;
            SelectedCards = new int[2] { -1, -1 };
            FillDictionaryWithRandomNumbers();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillDictionaryWithRandomNumbers()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < dictionaryNumbers.Count; i += 2)
            {
                list.Add(i);
                list.Add(i);
            }

            Random random = new Random();
            for (int j = 0; j < dictionaryNumbers.Count; j++)
            {     
                int i = random.Next(0, list.Count);

                dictionaryNumbers[j.ToString()] = list[i];
                list.Remove(list[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateButtons()
        {
            Button dynamicButton = null;
            Font createdFont = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);

            for (int i = 0; i < 16; i++)
            {
                dynamicButton = new Button();

                dynamicButton.Dock = DockStyle.Fill;
                dynamicButton.Name = i.ToString();
                dynamicButton.Font = createdFont;

                dynamicButton.Click += new EventHandler(DynamicCreatedBtn_Click);

                tableLayoutPanelMain.Controls.Add(dynamicButton);
                dictionaryNumbers.Add(dynamicButton.Name, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearTextOnButtons()
        {
            Button dynamicButton = null;

            foreach (System.Windows.Forms.Control controls in tableLayoutPanelMain.Controls)
            {
                dynamicButton = controls as Button;
                if (dynamicButton != null)
                {
                    dynamicButton.Text = string.Empty;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DynamicCreatedBtn_Click(object sender, EventArgs e)
        {
            Button eventSource = (Button)sender;

            if (string.IsNullOrWhiteSpace(eventSource.Text))
            {
                if (ClicksCount == 2)
                {
                    ClicksCount = 0;

                    ClearTextOnButtons();

                    SelectedCards[0] = -1;
                    SelectedCards[1] = -1;
                }

                string name = eventSource.Name;
                eventSource.Text = dictionaryNumbers[eventSource.Name].ToString();

                ClicksCount++;
                SelectedCards[ClicksCount - 1] = dictionaryNumbers[eventSource.Name];

                if (ClicksCount == 2)
                {
                    if (SelectedCards[0] == SelectedCards[1] && SelectedCards[0] != -1 && SelectedCards[1] != -1)
                    {
                        MessageBox.Show("You've found a pair!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void CreateRandomTable()
        {
            numbers.Clear();

            for (int j = 0; j < 2; j++)
            {
                for (int i = 1; i <= 16; i++)
                {
                    numbers.Add(i);
                }
            }

            numbers = (ArrayList)Shuffle(numbers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ICollection Shuffle(ICollection c)
        {
            if (c == null || c.Count <= 1)
            {
                return c;
            }

            byte[] bytes = new byte[4];

            RNGCryptoServiceProvider cRandom = new RNGCryptoServiceProvider();
            cRandom.GetBytes(bytes);

            int seed = BitConverter.ToInt32(bytes, 0);
            Random random = new Random(seed);

            ArrayList orig = new ArrayList(c);
            ArrayList randomized = new ArrayList(c.Count);

            for (int i = 0; i < c.Count; i++)
            {
                int index = random.Next(orig.Count);
                randomized.Add(orig[index]);
                orig.RemoveAt(index);
            }

            return randomized;
        }
    }
}