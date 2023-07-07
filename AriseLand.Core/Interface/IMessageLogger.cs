namespace AriseLand.Core.Interface;

public interface IMessageLogger
{
    void Msg(string? message);
    void Warning(string? message);
    void Error(string? message);
}