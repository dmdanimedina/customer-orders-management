using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.WebApi.ViewModels
{
    public class ClienteDTO
    {
        public ClienteDTO() 
        {
            this.Pedidos = new List<PedidoDTO>();
        }

        public long ID { get; set; }
        public string NombreFantasia { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set; }

        public IList<PedidoDTO> Pedidos { get; set; }

    }
}