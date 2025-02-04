using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

namespace Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;

public class Notificator : INotificator
{
    private List<Notification> _notifications;

    public Notificator() => _notifications = new List<Notification>();

    public void Handle(Notification notificacao) => _notifications.Add(notificacao);

    public List<Notification> GetNotifications() => _notifications;

    public bool HasNotification() => _notifications.Any();
}