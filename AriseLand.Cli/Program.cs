// See https://aka.ms/new-console-template for more information

using AriseLand.Core.Builder;
using AriseLand.Core.Data;

var Database = DatabaseContextBuilder.Create()
    .SetDataSource("AriseLandTest.db")
    .Build();

var world = new WorldData()
{
    Name = "AriseWorld",
    Plates = new[]
    {
        new PlateData()
        {
            Name = "ArisePlate",
            Areas = new[]
            {
                new AreaData()
                {
                    Name = "AriseArea",
                    Places = new[]
                    {
                        new PlaceData()
                        {
                            Name = "ArisePlace",
                            Buildings = new List<BuildingData>()
                            {
                                new BuildingData()
                                {
                                    Name = "AriseBuilding"
                                }
                            }
                        }
                    }
                }
            }
        }
    }
};

Database.CreateTable<WorldData>();
Database.CreateTable<PlateData>();
Database.CreateTable<AreaData>();
Database.CreateTable<PlaceData>();
Database.CreateTable<BuildingData>();
//Database.InsertWithChildren(world, true);

var worldData = Database.GetWithChildren<WorldData>(1, true);
Console.WriteLine(worldData.Name);
Console.WriteLine(worldData.Plates[0].Name);
Console.WriteLine(worldData.Plates[0].Areas[0].Name);
Console.WriteLine(worldData.Plates[0].Areas[0].Places[0].Name);
Console.WriteLine(worldData.Plates[0].Areas[0].Places[0].Buildings[0].Name);
Console.WriteLine(worldData.Plates[0].Areas[0].Places[0].Buildings[0].BindPlace?.Name);

Console.WriteLine("Hello, World!");