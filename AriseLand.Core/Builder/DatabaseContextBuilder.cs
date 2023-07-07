using AriseLand.Core.Model;

namespace AriseLand.Core.Builder;

public class DatabaseContextBuilder
{
    private readonly DatabaseContext _context;

    private DatabaseContextBuilder()
    {
        _context = new DatabaseContext();
        _context.DataSource = "AriseLand.db";
    }
    
    public static DatabaseContextBuilder Create()
    {
        return new DatabaseContextBuilder();
    }
    
    public DatabaseContext Build()
    {
        return _context;
    }

    public DatabaseContextBuilder SetDataSource(string dataSource)
    {
        _context.DataSource = dataSource;
        return this;
    }
}