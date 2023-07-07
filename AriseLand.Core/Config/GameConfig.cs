using AriseLand.Core.Interface;

namespace AriseLand.Core.Config;

public class GameConfig
{
    public IMessageLogger? Logger { get; set; }
    public string SavePath { get; set; } = "AriseLand";
}