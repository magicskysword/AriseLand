using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AriseLand.Core.Data;

public class WorldData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    [Column("places")]
    public PlateData[] Plates { get; set; } = Array.Empty<PlateData>();
}