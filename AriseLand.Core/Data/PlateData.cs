using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AriseLand.Core.Data;

public class PlateData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey(typeof(WorldData))]
    [Column("world_id")]
    public int WorldId { get; set; }
    
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    [Column("areas")]
    public AreaData[] Areas { get; set; } = Array.Empty<AreaData>();
}