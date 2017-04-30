using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceRollerSimulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //used to choose a random number for each dice roll
        Random random = new Random(Environment.TickCount);

        public MainPage()
        {
            this.InitializeComponent();
        }

        //Reference for code within _TextChanging functions: http://stackoverflow.com/questions/35186357/using-uwp-textbox-textchanging-to-ignore-wrong-data
        //if the text in the textbox is changing
        private void tbxNoDice_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //temporary number place holder
            double tempNumber;

            //checks the text in the text box
            if(!double.TryParse(sender.Text, out tempNumber) && sender.Text != "")
            {
                //if the character entered cannot be oparsed into a double it removes the character and resets the selection
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }

        }

        //if the text in the textbox is changing
        private void tbxSidesOnDice_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //temporary number place holder
            double tempNumber;

            //checks the text in the text box
            if (!double.TryParse(sender.Text, out tempNumber) && sender.Text != "")
            {
                //if the character entered cannot be oparsed into a double it removes the character and resets the selection
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }

        //print out the results of all dice rolls and format the reasults
        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            //reset the results textbox
            tbxResults.Text = "";
            try
            {
                //get the text in both entry boxes
                int numOfDice = int.Parse(tbxNoDice.Text);
                int numOfSides = int.Parse(tbxSidesOnDice.Text);

                //iterate through the number of dice there are
                for (int i = 0; i < numOfDice; i++)
                {
                    //if 1 + i divided by 5 does not have a remainder then this entry is the fifth on the line
                    if ((i + 1) % 5 == 0)
                    {
                        //add the results of the dice roll and start a new line
                        tbxResults.Text += "   Dice #" + (i + 1) + ": " + random.Next(1, numOfSides + 1) + "\n";
                    }

                    // if it is not the fifth entry in the textbox
                    else
                    {
                        //if the last entry was the end of a line
                        if (i % 5 == 0)
                        {
                            //start the new line with a new dice result
                            tbxResults.Text += "Dice #" + (i + 1) + ": " + random.Next(1, numOfSides + 1);

                        }

                        //if it is any entry other than teh first or last
                        else
                        {
                            //add a new dice result to the textbox
                            tbxResults.Text += "   Dice #" + (i + 1) + ": " + random.Next(1, numOfSides + 1);
                        }
                    }
                }
            }
            catch { }

        }

        private async void DisplayAbout(object sender, RoutedEventArgs e)
        {
            ContentDialog About = new ContentDialog
            {
                Title = "About this project",
                Content = "\nCreated by: James Hagen",
                PrimaryButtonText = "Ok"
            };

            ContentDialogResult result = await About.ShowAsync();
        }
    }
}
