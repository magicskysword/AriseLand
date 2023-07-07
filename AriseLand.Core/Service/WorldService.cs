using AriseLand.Core.Interface;

namespace AriseLand.Core.Service;

/// <summary>
/// 世界相关服务
/// </summary>
public partial class WorldService : IGameService
{
    public Game Game { get; set; } = null!;
}