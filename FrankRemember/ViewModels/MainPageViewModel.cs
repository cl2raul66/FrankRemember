using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrankRemember.Services;
using FrankRemember.Views;

namespace FrankRemember.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    readonly ITripService tripServ;

    public MainPageViewModel(ITripService tripService)
    {
        tripServ = tripService;
    }

    [ObservableProperty]
    string? tripStatus;

    [RelayCommand]
    async Task StartTrip()
    {
        string result = await Shell.Current.DisplayPromptAsync("Datos de inicio", "Monto del pago del viaje:");
        if (string.IsNullOrEmpty(result))
        {
            return;
        }

        if (double.TryParse(result, out double freight))
        {
            await Shell.Current.DisplayAlert("Pago", $"el pago es de {freight}", "Cerrar");
            TripStatus = "Viaje comenzado";
            return;
        }

        await Shell.Current.DisplayAlert("Precaución", "Ingrese un número", "Cerrar");
    }

    [RelayCommand]
    async Task EndOfTrip()
    {
        bool result = await Shell.Current.DisplayAlert("Notificación", "¿Seguro que llego a su destino?", "Si, estoy seguro", "No");

        if (!result)
        {
            return;
        }

        TripStatus = "Viaje Finalizado";
        await Task.Delay(5000);
        TripStatus = null;
    }

    [RelayCommand]
    async Task CancelTrip()
    {
        bool result = await Shell.Current.DisplayAlert("Notificación", "¿Seguro que va a cancelar el viaje?", "Si, estoy seguro", "No");

        if (!result)
        {
            return;
        }

        TripStatus = "Viaje Cancelado";
        await Task.Delay(5000);
        TripStatus = null;
    }

    [RelayCommand]
    async Task Refuel()
    {
        string result = await Shell.Current.DisplayPromptAsync("Datos de recarga de combustible", "Monto pagado:");
        if (string.IsNullOrEmpty(result))
        {
            return;
        }

        if (double.TryParse(result, out double cost))
        {
            
            return;
        }

        await Shell.Current.DisplayAlert("Precaución", "Ingrese un número", "Cerrar");
    }

    [RelayCommand]
    async Task GoToLogHistory() => await Shell.Current.GoToAsync(nameof(PgLogHistory), true);
}
