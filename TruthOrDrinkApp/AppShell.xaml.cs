using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AccountPage", typeof(AccountPage));
		Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
		Routing.RegisterRoute("AboutPage", typeof(AboutPage));

	}
}
