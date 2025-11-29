using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ZXing.Net.Maui;
using OsmaCard.Services;
using System.IO;

namespace OsmaCard;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .ConfigureFonts(fonts => {});

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shopitems.db3");
        builder.Services.AddSingleton(new DatabaseService(dbPath));
        builder.Services.AddSingleton<Views.AddItemPage>();

        return builder.Build();
    }
}
