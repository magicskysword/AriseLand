using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AriseLand.Core.Data;

public class BuildingData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey(typeof(PlaceData))]
    [Column("bind_place_id")]
    public int BindPlaceId { get; set; }
    
    [ManyToOne]
    public PlaceData? BindPlace { get; set; }
}