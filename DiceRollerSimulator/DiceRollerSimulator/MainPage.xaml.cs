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

        

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void tbxNoDice_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //temporary number place holder
            int tempNumber;

            //checks the text in the text box
            if(int.TryParse(sender.Text, out tempNumber) || sender.Text == "")
            {

            }

        }
    }
}
