using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using OsmaCard.Models;
using OsmaCard.Services;

namespace OsmaCard.ViewModels;

public class ItemViewModel : BindableObject
{
    readonly DatabaseService _database;

    public ObservableCollection<ShopItem> Items { get; set; } = new();

    public ItemViewModel(DatabaseService database)
    {
        _database = database;
        Task.Run(async () => await LoadAsync());
    }

    public string Description { get; set; }
    public string Barcode { get; set; }

    public Command SaveCommand => new(async () =>
    {
        if (!string.IsNullOrWhiteSpace(Description) && !string.IsNullOrWhiteSpace(Barcode))
        {
            await _database.SaveItemAsync(new ShopItem { Description = Description, Barcode = Barcode });
            Description = Barcode = string.Empty;
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Barcode));
            await LoadAsync();
        }
    });

    public Command CancelCommand => new(() =>
    {
        Description = Barcode = string.Empty;
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(Barcode));
    });

    public Command<ShopItem> DeleteCommand => new(async (item) =>
    {
        await _database.DeleteItemAsync(item);
        await LoadAsync();
    });

    async Task LoadAsync()
    {
        var list = await _database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var it in list) Items.Add(it);
        });
    }
}
