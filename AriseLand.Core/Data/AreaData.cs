using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AriseLand.Core.Data;

public class AreaData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey(typeof(PlateData))]
    [Column("plate_id")]
    public int PlateId { get; set; }
    
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    [Column("places")]
    public PlaceData[] Places { get; set; } = Array.Empty<PlaceData>();
}