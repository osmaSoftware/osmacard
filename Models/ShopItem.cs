using SQLite;

namespace OsmaCard.Models;

public class ShopItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Description { get; set; }
    public string Barcode { get; set; }

    public string Icon => "shop_icon.png";
}
