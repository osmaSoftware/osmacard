using Microsoft.Maui.Controls;
namespace OsmaCard;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new Views.AddItemPage(App.Services.GetService<Services.DatabaseService>()!));
    }
}
