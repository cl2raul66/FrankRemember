using FrankRemember.ViewModels;

namespace FrankRemember.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}
