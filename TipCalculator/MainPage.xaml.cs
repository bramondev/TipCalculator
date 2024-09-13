using System.Diagnostics;

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void slider_change(object sender, ValueChangedEventArgs e)
        {
            double value = (double)e.NewValue;
        }

        private void OnQuinzeBtn_Clicked(object sender, EventArgs e)
        {
            SliderTipPercent.Value = 15;
        }

        private void OnVinteBtn_Clicked(object sender, EventArgs e)
        {
            SliderTipPercent.Value = 20;
        }

        private void OnRounddownBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                //calcular a gorjeta, arredondand para baixo
                double result = calculatetip();
                double roundedResult = Math.Floor(result);
                double amount = Convert.ToDouble(ValueEntry.Text.ToString());
                double TotalValue = roundedResult + amount;

                //exibir a gorjeta
                LabelTipValue.Text = roundedResult.ToString();
                LabelTotalValue.Text = TotalValue.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
        }

        private void OnRoundupBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                //calcular a gorjeta, arredondand cima
                double result = calculatetip();
                double roundedResult = Math.Ceiling(result);
                double amount = Convert.ToDouble(ValueEntry.Text.ToString());
                double TotalValue = roundedResult + amount;

                //exibir a gorjeta
                LabelTipValue.Text = roundedResult.ToString();
                LabelTotalValue.Text = TotalValue.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
        }


        private double calculatetip()
        {

            double amount = Convert.ToDouble(ValueEntry.Text.ToString());
            double percent = SliderTipPercent.Value;

            //calculo da gorjeta
            double result = amount * (percent / 100);
            return result;
        }

        private void SliderTipValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            PercentageValue.Text = Math.Round(SliderTipPercent.Value).ToString();
        }

        private async void SobreBtn_Clicked(object sender, EventArgs e)
        {
            var githubUrl = new Uri("https://github.com/TRIBUNAA");
            await Browser.OpenAsync(githubUrl, BrowserLaunchMode.SystemPreferred);
        }

    }
    }
    


