using FrankRemember.Views;

namespace FrankRemember;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PgLogHistory), typeof(PgLogHistory));
    }
}
