using Core;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

public partial class MainPage : ContentPage
{
    Entry phoneNumberText;
    Button translateButton;
    Button callButton;
    string TranslatedNumber;

    public MainPage()
    {
        this.Padding = new Thickness(20, 20, 20, 20);

        StackLayout panel = new StackLayout
        {
            Spacing = 15
        };

        panel.Children  .Add(new Label
        {
            Text = "Enter a Phoneword:",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
        });

        panel.Children.Add(phoneNumberText = new Entry
        {
            Text = "1-855-XAMARIN",
        });

        panel.Children.Add(translateButton = new Button
        {
            Text = "Translate",
            BackgroundColor = new Color(0, 153, 51)
        });

        panel.Children.Add(callButton = new Button
        {
            Text = "Call",
            IsEnabled = false,
            TextColor = new Color(0, 0, 0),
            BackgroundColor = new Color(12, 50, 43)
        });

        translateButton.Clicked += OnTraslate;
        callButton.Clicked += OnCall;

        this.Content = panel;


        
    }
    void OnTraslate(object sender, EventArgs e)
    {
        TranslatedNumber = Translator.ToNumber(phoneNumberText.Text);

        if (!string.IsNullOrEmpty(TranslatedNumber))
        {
            callButton.Text = $"Call {TranslatedNumber}";
            callButton.IsEnabled = true;
        }

    }

    async void OnCall(object sender, EventArgs e)
    {
        if (await this.DisplayAlert("Dial a number",
            $"would you like to call {TranslatedNumber}",
            "Yes",
            "Cancel"))
        {

        }
    }
}