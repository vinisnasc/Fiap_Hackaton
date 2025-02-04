namespace Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;

public class Notification
{
    public Notification(string message)
    {
        Message = message;
    }

    public string Message { get; }
}