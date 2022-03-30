using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMI_Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RenderBMI();
        }

        private double ToDouble(string input) {
            if (input == null) { return 0.00; }

            input = string.Join("", input.Split(' '));
            input = string.Join("", input.Split('-'));
            input = string.Join("", input.Split(','));

            return input.Equals("") ? 0.00 : double.Parse(input);
        }

        private void RenderBMI() {
            double weight = ToDouble(WeightEntry.Text);
            double height = ToDouble(HeightEntry.Text);

            double bmi = 703.00 * weight / (height == 0.00 ? 1.00 : height * height);

            BMILabel.Text = $"BMI: {bmi.ToString("0.##")}";
        }

        private void WeightEntry_TextChanged(object sender, TextChangedEventArgs e) { RenderBMI(); }

        private void HeightEntry_TextChanged(object sender, TextChangedEventArgs e) { RenderBMI(); }
    }
}
