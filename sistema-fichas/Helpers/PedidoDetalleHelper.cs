using sistema_fichas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.Helpers
{
    public static class PedidoDetalleHelper
    {
        public static string getColorActividad(int? Estado_ID) {
            string color = "primary";
            int estado = (Estado_ID == null)? 0 : Estado_ID.Value;
            if (estado == TipoEstadoDetalle.Inactivo.GetHashCode())
            {
                color = "danger";
            }
            if (estado == TipoEstadoDetalle.Activo.GetHashCode())
            {
                color = "success";
            }
            if (estado == TipoEstadoDetalle.Agendado.GetHashCode())
            {
                color = "default";
            }
            if (estado == TipoEstadoDetalle.Parcial.GetHashCode())
            {
                color = "warning";
            }
            if (estado == TipoEstadoDetalle.Finalizado.GetHashCode())
            {
                color = "primary";
            }
            return "label label-"+color;
        }

    }
}