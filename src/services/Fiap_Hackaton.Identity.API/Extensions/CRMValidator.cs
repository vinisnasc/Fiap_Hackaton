using System.Text.RegularExpressions;

namespace Fiap_Hackaton.Identity.API.Extensions
{
    public class CRMValidator
    {
        public static bool IsValid(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return false;

            crm = crm.Trim().ToUpper();

            var regex = new Regex(@"^\d{4,6}/[A-Z]{2}$");

            return regex.IsMatch(crm);
        }
    }
}
