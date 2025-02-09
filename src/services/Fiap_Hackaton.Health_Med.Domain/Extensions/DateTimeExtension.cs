using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap_Hackaton.Health_Med.Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ArredondarParaHoraAnterior(this DateTime data)
        {
            return data.Minute == 0 ? data : data.AddMinutes(-data.Minute).AddSeconds(-data.Second);
        }
    }
}
