using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public partial class MemoryGameForm : Form
    {
        private List<Button> buttons = new List<Button>();
        private List<string> icons = new List<string>()
        {
            "Bonjour", "Hello",
            "Chat", "Cat",
            "Chien", "Dog",
            "Pomme", "Apple",
            "Livre", "Book",
            "Rouge", "Red",
            "Vert", "Green",
            "Bleu", "Blue"
        };
        private Random random = new Random();
        private Button firstClicked = null;
        private Button secondClicked = null;

        public MemoryGameForm()
        {
            InitializeComponent();

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);

            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Button button in buttons)
            {
                int randomNumber = random.Next(icons.Count);
                button.Text = icons[randomNumber];
                button.ForeColor = button.BackColor;
                icons.RemoveAt(randomNumber);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Button clickedButton = sender as Button;

            if (clickedButton.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedButton;
            secondClicked.ForeColor = Color.Black;

            string firstWord = firstClicked.Text;
            string secondWord = secondClicked.Text;
            bool isMatch = (firstWord == "Bonjour" && secondWord == "Hello") ||
                           (firstWord == "Hello" && secondWord == "Bonjour") ||
                           (firstWord == "Chat" && secondWord == "Cat") ||
                           (firstWord == "Cat" && secondWord == "Chat") ||
                           (firstWord == "Bleu" && secondWord == "Blue") ||
                           (firstWord == "Blue" && secondWord == "Bleu") ||
                           (firstWord == "Vert" && secondWord == "Green") ||
                           (firstWord == "Green" && secondWord == "Vert") ||
                           (firstWord == "Chien" && secondWord == "Dog") ||
                           (firstWord == "Dog" && secondWord == "Chien") ||
                           (firstWord == "Apple" && secondWord == "Pomme") ||
                           (firstWord == "Pomme" && secondWord == "Apple") ||
                           (firstWord == "Rouge" && secondWord == "Red") ||
                           (firstWord == "Red" && secondWord == "Rouge") ||
                           (firstWord == "Livre" && secondWord == "Book");
                           


            if (isMatch)
            {
                firstClicked = null;
                secondClicked = null;
                CheckForWinner();
            }
            else
            {
                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            foreach (Button button in buttons)
            {
                if (button.ForeColor == button.BackColor)
                    return;
            }

            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
    }
}
