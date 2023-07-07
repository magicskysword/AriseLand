using SQLite;

namespace AriseLand.Core.Data;

public class CharacterData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nickname")]
    public string Nickname { get; set; } = string.Empty;
    
    [Column("family_name")]
    public string FamilyName { get; set; } = string.Empty;
    
    [Column("given_name")]
    public string GivenName { get; set; } = string.Empty;
    
    [Column("birth_date")]
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    
    [Column("character_type")]
    public CharacterType CharacterType { get; set; } = CharacterType.Character;
}