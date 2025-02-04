namespace Fiap_Hackaton.Health_Med.API.Extensions;

public class AppSettingsConfiguration
{
    public string Secret { get; set; }
    public int ExpiracaoHoras { get; set; }
    public string Emissor { get; set; }
    public string ValidoEm { get; set; }
}