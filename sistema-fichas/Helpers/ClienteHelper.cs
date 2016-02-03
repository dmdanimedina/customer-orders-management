using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace sistema_fichas.Helpers
{
    public static class ClienteHelper
    {
        public static String NombreEstado(int Estado)
        {
                switch (Estado)
                {
                    case 1:
                        return "Activo";
                    case 2:
                        return "Bloqueado";
                    case 3:
                        return "Inactivo";
                    default:
                        return "N/A";

                }
        }

        public static String ColorEstado(int Estado)
        {
            switch (Estado)
            {
                case 1:
                    return "success";
                case 2:
                    return "warning";
                case 3:
                    return "default";
                default:
                    return "primary";

            }
        }

        public static IEnumerable<PropertyInfo> getPropertyNames()
        {
            return typeof(sistema_fichas.Business.Cliente).GetProperties().Where(p => !p.GetGetMethod().IsVirtual && !p.Name.Contains("ID"));
        }

        public static SelectList getPropertyNamesAsSelectList()
        {
            return new SelectList(getPropertyNames(), "Name", "Name");
        }
    }
}