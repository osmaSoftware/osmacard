using Xamarin.Forms;
using ZXing.Net.Maui;
using OsmaCard.ViewModels;

namespace OsmaCard.Views;

public partial class AddItemPage : ContentPage
{
    ItemViewModel ViewModel;

    public AddItemPage(OsmaCard.Services.DatabaseService db)
    {
        InitializeComponent();
        ViewModel = new ItemViewModel(db);
        BindingContext = ViewModel;
    }

    void OnBarcodeDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var bc = e.Results?.FirstOrDefault()?.Value;
        if (!string.IsNullOrEmpty(bc))
            MainThread.BeginInvokeOnMainThread(() => ViewModel.Barcode = bc);
    }
}
