using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AriseLand.Core.Data;

public class PlaceData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey(typeof(AreaData))]
    [Column("area_id")]
    public int AreaId { get; set; }
    
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    [Column("buildings")]
    public List<BuildingData> Buildings { get; set; } = new();
}