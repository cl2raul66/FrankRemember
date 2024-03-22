using FrankRemember.ViewModels;

namespace FrankRemember.Views;

public partial class PgLogHistory : ContentPage
{
	public PgLogHistory(PgLogHistoryViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}