using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankRemember.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    string? tripStatus;

    [RelayCommand]
    void StartTrip()
    {
        TripStatus = "Viaje comenzado";
    }

    [RelayCommand]
    async Task EndOfTrip()
    {
        TripStatus = "Viaje Finalizado";
        await Task.Delay(5000);
        TripStatus = null;
    }

    [RelayCommand]
    async Task CancelTrip()
    {
        TripStatus = "Viaje Cancelado";
        await Task.Delay(5000);
        TripStatus = null;
    }
}
