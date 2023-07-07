using AriseLand.Core.Data;
using AriseLand.Core.Interface;
using Newtonsoft.Json;

namespace AriseLand.Core.Service;

public class GameDataService : IGameService
{
    public Game Game { get; set; }

    public void LoadOrCreateGame()
    {
        var config = Game.Config;
        var hasSave = false;

        try
        {
            var info = LoadSaveInfo(config.SavePath);
            hasSave = true;
        }
        catch (System.Exception e)
        {
            Game.Error(e);
            hasSave = false;
        }

        if (hasSave)
        {
            LoadGame();
        }
        else
        {
            CreateGame();
        }
    }

    public SaveFileData LoadSaveInfo(string savePath)
    {
        if (File.Exists($"{savePath}/info.json"))
        {
            var json = File.ReadAllText($"{savePath}/info.json");
            return JsonConvert.DeserializeObject<SaveFileData>(json);
        }

        throw new FileNotFoundException("未找到存档信息文件");
    }
    
    public void CreateGame()
    {
        
    }

    public void LoadGame()
    {
        
    }
}