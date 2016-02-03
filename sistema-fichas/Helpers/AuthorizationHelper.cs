using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace sistema_fichas.Helpers
{
    public static class AuthorizationHelper
    {
        public static bool isAdministrador(IPrincipal User) 
        {
            return (User.IsInRole("Administrador")) ? true : false;
        }
        
        public static bool isGerencia(IPrincipal User)
        {
            isAdministrador(User);
            return (User.IsInRole("Gerencia")) ? true : false;
        }

        public static bool isAdministradorComercial(IPrincipal User)
        {
            isGerencia(User);
            return (User.IsInRole("Administrador Comercial")) ? true : false;
        }

        public static bool isEjecutivoCuenta(IPrincipal User)
        {
            isAdministradorComercial(User);
            return (User.IsInRole("Ejecutivo Comercial")) ? true : false;
        }

        public static bool puedeAnular(IPrincipal User, bool isOwner)
        {
            return (isAdministradorComercial(User) || isOwner) ? true : false;
        }

        public static bool isComercial(IPrincipal User) 
        {
            return (User.IsInRole("Ejecutivo Comercial") || User.IsInRole("Administrador Comercial")) ? true : false;
        }

        public static bool isOperaciones(IPrincipal User)
        {
            return (User.IsInRole("Operaciones")) ? true : false;
        }
    }
}