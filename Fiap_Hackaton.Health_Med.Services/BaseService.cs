using Fiap_Hackaton.Health_Med.Domain.ErrorNotificator;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Services;

namespace Fiap_Hackaton.Health_Med.Services;

public class BaseService
{
    private readonly INotificator _notificador;

    protected BaseService(INotificator notificador)
    => _notificador = notificador;

    protected void Notificate(string message) => _notificador.Handle(new Notification(message));
}