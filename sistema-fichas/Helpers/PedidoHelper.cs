using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using sistema_fichas.Business;

namespace sistema_fichas.Helpers
{
    public static class PedidoHelper
    {

        public static IEnumerable<PropertyInfo> getPropertyNames()
        {
            var resultado = typeof(sistema_fichas.Business.Pedido).GetProperties().Where(p => !p.GetGetMethod().IsVirtual && !p.Name.Contains("ID"));
            return resultado.ToList();
        }

        public static SelectList getPropertyNamesAsSelectList()
        {


            //var select_customFilters =
            IEnumerable<SelectListItem> select_customFilters = (new[] { new SelectListItem { Text = "Nombre Fantasia", Value = "Cliente.NombreFantasia" }, new SelectListItem { Text = "Ejecutivo", Value = "UserProfile.UserName" }});
            IEnumerable<SelectListItem> select_properties = 
                getPropertyNames().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Name
                });
            var select_mixed = select_customFilters.Concat(select_properties);
            return new SelectList(select_mixed,"Value","Text");
        }

        public static bool esActivoEditable(int EstadoDetalle, int EstadoPedido) {
            var editable = esEditable(EstadoPedido);
            var activo = esActivo(EstadoDetalle);
            return (esEditable(EstadoPedido) && esActivo(EstadoDetalle)) ? true : false;
        }

        public static bool esAprobadoOperaciones(int EstadoDetalle, int EstadoPedido)
        {
            return (EstadoPedido == TipoEstadoPedido.Aprobado_Operaciones.GetHashCode() && (EstadoDetalle == TipoEstadoDetalle.Activo.GetHashCode() || EstadoDetalle == TipoEstadoDetalle.Deshabilitado.GetHashCode())) ? true : false;
        }
        //Condiciones: Para que sea un estado anulable, tiene que ser Ingresado, Revision, Aprobado/Rechazado por comercial.
        //estas condiciones son validas inicialmente para el área comercial.
        public static bool EstadoAnulable(int EstadoPedido) {
            return (
                EstadoPedido == TipoEstadoPedido.Ingresado.GetHashCode() ||
                EstadoPedido == TipoEstadoPedido.Revision.GetHashCode() ||
                EstadoPedido == TipoEstadoPedido.Aprobado_Comercial.GetHashCode() ||
                EstadoPedido == TipoEstadoPedido.Rechazado_Comercial.GetHashCode()) ? true : false;
        }

        //Condiciones:
        //El Detalle debe estar en estado activo. Si esta en estado agendado no puede ser modificado, puesto que
        //se encuentra en transicion de estados en el área de operaciones.
        public static bool esActivo(int detalle)
        {
            return (detalle == TipoEstadoDetalle.Activo.GetHashCode()) ? true : false;
        }

        public static bool esEvaluable(int pedido)
        {
            return (pedido == TipoEstadoPedido.Revision.GetHashCode()) ? true : false;
        }

        public static bool esAnulado(int detalle)
        {
            return (detalle == TipoEstadoDetalle.Inactivo.GetHashCode()) ? true : false;
        }

        //Condiciones
        //El pedido se debe encontrar en un estado Ingresado o  rechazado por comercial
        public static bool esEditable(int pedido)
        {
            return (
                pedido == TipoEstadoPedido.Ingresado.GetHashCode() ||
                pedido == TipoEstadoPedido.Rechazado_Operaciones.GetHashCode() ||
                pedido == TipoEstadoPedido.Rechazado_Comercial.GetHashCode()) ? true : false;
        }

        public static bool esEditableOperaciones(int pedido)
        {
            return (pedido == TipoEstadoPedido.Aprobado_Comercial.GetHashCode()) ? true : false;
        }

        public static string getColorServicio(int TipoEstadoServicio)
        {
            return (TipoEstadoServicio == TipoEstadoDetalle.Activo.GetHashCode()) ? "label-success" : "label-warning";
        }
    }
}