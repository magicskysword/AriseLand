using SQLite;
using SQLiteNetExtensions.Extensions;

namespace AriseLand.Core.Model;

public class DatabaseContext
{
    public string DataSource { get; set; } = null!;
    
    internal DatabaseContext()
    {
        
    }

    public SQLiteConnection InitialiseConnection() 
    {
        SQLiteConnectionString options = new SQLiteConnectionString(DataSource, false);
        var _connection = new SQLiteConnection(options);
        return _connection;
    }
    
    public void CreateTable<T>()
    {
        var connection = InitialiseConnection();
        connection.CreateTable<T>();
        connection.Close();
    }
    
    public T Get<T>(int id) where T : new()
    {
        var connection = InitialiseConnection();
        var result = connection.Get<T>(id);
        connection.Close();
        return result;
    }
    
    public IEnumerable<T> GetAll<T>() where T : new()
    {
        var connection = InitialiseConnection();
        var result = connection.Table<T>();
        connection.Close();
        return result;
    }
    
    public T GetWithChildren<T>(int id, bool recursive = false) where T : new()
    {
        var connection = InitialiseConnection();
        var result = connection.GetWithChildren<T>(id, recursive);
        connection.Close();
        return result;
    }
    
    public void Insert<T>(T obj)
    {
        var connection = InitialiseConnection();
        connection.Insert(obj);
        connection.Close();
    }
    
    public void InsertWithChildren<T>(T obj, bool recursive = false)
    {
        var connection = InitialiseConnection();
        connection.InsertWithChildren(obj, recursive);
        connection.Close();
    }
    
    public void Update<T>(T obj)
    {
        var connection = InitialiseConnection();
        connection.Update(obj);
        connection.Close();
    }
    
    public void UpdateWithChildren<T>(T obj)
    {
        var connection = InitialiseConnection();
        connection.UpdateWithChildren(obj);
        connection.Close();
    }
    
    public void Delete<T>(T obj)
    {
        var connection = InitialiseConnection();
        connection.Delete(obj);
        connection.Close();
    }
    
    public void DeleteWithChildren<T>(T obj)
    {
        var connection = InitialiseConnection();
        connection.Delete(obj, true);
        connection.Close();
    }
}