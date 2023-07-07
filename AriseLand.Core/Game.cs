using AriseLand.Core.Builder;
using AriseLand.Core.Config;
using AriseLand.Core.Exception;
using AriseLand.Core.Interface;
using AriseLand.Core.Model;
using AriseLand.Core.Service;

namespace AriseLand.Core;

public class Game
{
    public GameConfig Config { get; private set; } = new();
    public DatabaseContext Database { get; private set; }
    public IMessageLogger? Logger { get; private set; } = null!;
    public Dictionary<Type, IGameService> Services { get; } = new();

    public Game()
    {
        Database = DatabaseContextBuilder.Create()
            .SetDataSource("AriseLand/Main.db")
            .Build();
    }

    public Game LoadConfigure(GameConfig config)
    {
        Config = config;
        Logger = config.Logger;
        Database.DataSource = $"{config.SavePath}/Main.db";
        return this;
    }
    
    public void Start()
    {
        if(Logger == null)
            throw new LoadConfigureException("未指定日志记录器");

        RegisterService(new GameDataService());
        RegisterService(new ConfigTableService());
        RegisterService(new WorldService());
        
        GetService<ConfigTableService>().LoadConfigTable();
        GetService<GameDataService>().LoadOrCreateGame();
    }
    
    public void RegisterService<T>(T service) where T : IGameService
    {
        service.Game = this;
        Services.Add(typeof(T), service);
    }
    
    public T GetService<T>() where T : IGameService
    {
        return (T) Services[typeof(T)];
    }
    
    public void Msg(object message)
    {
        Logger!.Msg(message?.ToString());
    }
    
    public void Warning(object message)
    {
        Logger!.Warning(message?.ToString());
    }
    
    public void Error(object message)
    {
        Logger!.Error(message?.ToString());
    }
}