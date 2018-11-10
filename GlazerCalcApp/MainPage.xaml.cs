using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalcApp
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

        private async void DisplayError()
        {
            ContentDialog UnexpectedErrorDialog = new ContentDialog()
            {
                Title = "Non Supported Character dectected!",
                Content = "Please only enter Digits into provided spaces.",
                CloseButtonText = "Ok"
            };

            await UnexpectedErrorDialog.ShowAsync();
        }


        private void txtWidth_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                try
                {
                    const double MAX_WIDTH = 5.0;
                    const double MIN_WIDTH = 0.5;

                    double input = Convert.ToInt32(txtWidth.Text);
                    if (input < MIN_WIDTH || input > MAX_WIDTH)
                    {
                        txtBlkTest.Foreground = new SolidColorBrush(Colors.Red);
                        txtBlkTest.Text = "Please enter a width between 0.5 and 5.0";
                    }
                    else
                    {
                        txtBlkTest.Foreground = new SolidColorBrush(Colors.Green);
                        txtBlkTest.Text = "Width within limits";
                        undisabledBtn();
                    }
                }
                catch
                {
                    DisplayError();
                }

            }
            else
            {
                txtBlkTest.Foreground = new SolidColorBrush(Colors.Red);
                txtBlkTest.Text = "Press enter for Validation";
            }

        }

        private void txtHeight_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                try
                {
                    const double MAX_HEIGHT = 3.0;
                    const double MIN_HEIGHT = 0.75;

                    double input = Convert.ToInt32(txtHeight.Text);
                    if (input < MIN_HEIGHT || input > MAX_HEIGHT)
                    {
                        txtBlkTest.Foreground = new SolidColorBrush(Colors.Red);
                        txtBlkTest.Text = "Please enter a width between 0.75 and 3.0";
                    }
                    else
                    {
                        txtBlkTest.Foreground = new SolidColorBrush(Colors.Green);
                        txtBlkTest.Text = "Heights within limits";
                        undisabledBtn();
                    }
                }
                catch
                {
                    DisplayError();
                }

            }
            else
            {
                txtBlkTest.Foreground = new SolidColorBrush(Colors.Red);
                txtBlkTest.Text = "Press enter for Validation";
            }
        }

        private void sidQuanity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var input = sidQuanity.Value;
            txtBlckQuan.Text = input.ToString();
        }

        private void undisabledBtn()
        {
            if(!string.IsNullOrEmpty(txtHeight.Text) && !string.IsNullOrEmpty(txtWidth.Text))
            {
                btnCalcQuote.IsEnabled = true;
            }
        }

        private void btnCalcQuote_Click(object sender, RoutedEventArgs e)
        {
            //set up vars for use in calculations
            double height = Convert.ToDouble(txtHeight.Text);
            double width = Convert.ToDouble(txtWidth.Text);
            int quanity = Convert.ToInt32(txtBlckQuan.Text);

            //calculates based on givin values
            double woodLength = (2 * (width + height) * 3.25) * quanity;
            double glassArea = (2 * (width * height)) * quanity;


            //places values in the textboxes
            txtAreaOfGlass.Text = glassArea.ToString();
            txtLenOfWood.Text = woodLength.ToString();
            txtWidthQuote.Text = txtWidth.Text;
            txtHeightQuote.Text = txtHeight.Text;
            txtQuantityQuote.Text = txtBlckQuan.Text;
            txtTintQuote.Text = combxTint.SelectedValue.ToString();
            

        }
    }
}
