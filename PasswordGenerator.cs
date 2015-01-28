using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordVault
{
    public partial class PasswordGenerator : Form
    {
        /// <summary>
        /// Members of the class
        /// </summary>
        private string _password = "";

        /// <summary>
        /// Properties of the class.
        /// </summary>
        public string Password { get { return _password; } }
 
        /// <summary>
        /// Constructor
        /// </summary>
        public PasswordGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Respond to the user clicking the button and generate the password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateButton_Click(object sender, EventArgs e)
        {
            float kCharacterReuseChance = 0.30f;
            float kSymbolCharacterChance = 0.30f;
            float kNumberCharacterChance = 0.30f;
            float kLetterCharacterChance = 0.40f;
            float kSymbolChanceReduction = 0.075f;
            char[] kNumberCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] kLetterCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] kSymbolCharacters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '<', '>', '?', ':', '{', '}', '[', ']', '|' };
            

            // read in option values for building password
            bool numbers = numbersCheckBox.Checked;
            bool lowers = lowerCheckBox.Checked;
            bool uppers = upperCheckBox.Checked;
            bool symbols = symbolsCheckBox.Checked;
            int length = (int)lengthUpDown.Value;

            // initially clear the text
            passwordTextbox.Text = "";

            Random random = new Random(DateTime.Now.Ticks.GetHashCode());
            List<char> usedCharacters = new List<char>();
            string password = "";

            // iterate over the length of the password
            for (int i = 0; i < length; ++i)
            {
                float randValue = (float)random.NextDouble();
                char[] characterSetToUse = kLetterCharacters;

                while (true)
                {
                    // check for letters
                    if ((randValue <= kLetterCharacterChance && (uppers == true || lowers == true)) || (symbols == false && numbers == false))
                    {
                        characterSetToUse = kLetterCharacters;
                        break;
                    }
                    randValue -= kLetterCharacterChance;

                    // check for numbers
                    if ((randValue <= kNumberCharacterChance || (symbols == false && uppers == false && lowers == false)) && numbers == true)
                    {
                        characterSetToUse = kNumberCharacters;
                        break;
                    }
                    randValue -= kNumberCharacterChance;

                    // check for symbols
                    if (randValue <= kSymbolCharacterChance && symbols)
                    {
                        characterSetToUse = kSymbolCharacters;
                        break;
                    }
                    randValue -= kSymbolCharacterChance;
                }

                // Now that we have a character set to use, lets randomly pick a char to use from that set
                char character = 'a';

                // pick a character to use
                while (true)
                {
                    // get a percentage for random reuse
                    float reuseRandom = (float)random.NextDouble();

                    // attempt to pick a character
                    character = characterSetToUse[random.Next() % characterSetToUse.Length];

                    // validate that we have a unique char, or if we can reuse an already taken char
                    if (usedCharacters.Contains(character) == false || reuseRandom <= kCharacterReuseChance)
                    {
                        break;
                    }
                }

                // if we have picked a letter handle the case here
                if (characterSetToUse == kLetterCharacters)
                {
                    // if we have uppers and no lowerd than automatically convert to uppercase
                    if (uppers == true && lowers == false)
                    {
                        character = (char)('A' + character - 'a');
                    }
                    // if we have both uppers and lowers then randomly select a case
                    else if (uppers && lowers)
                    {
                        int randomCase = random.Next() % 2;
                        if (randomCase == 1)
                        {
                            character = (char)('A' + character - 'a');
                        }
                    }
                }

                // change the chance percentages when we use a special character
                if (characterSetToUse == kSymbolCharacters)
                {
                    kSymbolCharacterChance = Math.Max(0, kSymbolCharacterChance - kSymbolChanceReduction);

                    int randomChance = random.Next() % 2;
                    if (randomChance == 0)
                    {
                        kLetterCharacterChance = Math.Min(1.0f, kLetterCharacterChance + kSymbolChanceReduction);
                    }
                    else
                    {
                        kNumberCharacterChance = Math.Min(1.0f, kNumberCharacterChance + kSymbolChanceReduction);
                    }
                }

                // append the character to the password string
                password += character;
            }

            // set the text on the textbox
            passwordTextbox.Text = password;
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            // assign the password
            _password = passwordTextbox.Text;

            this.Close();
            this.Dispose();
        }
    }
}
