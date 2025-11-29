using SQLite;
using OsmaCard.Models;

namespace OsmaCard.Services;

public class DatabaseService
{
    readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<ShopItem>().Wait();
    }

    public Task<List<ShopItem>> GetItemsAsync() =>
        _db.Table<ShopItem>().OrderBy(i => i.Id).ToListAsync();

    public Task<int> SaveItemAsync(ShopItem item) =>
        _db.InsertAsync(item);

    public Task<int> DeleteItemAsync(ShopItem item) =>
        _db.DeleteAsync(item);
}
