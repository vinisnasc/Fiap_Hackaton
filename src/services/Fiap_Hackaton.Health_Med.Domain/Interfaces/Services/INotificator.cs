using Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

public interface INotificator
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notificacao);
}