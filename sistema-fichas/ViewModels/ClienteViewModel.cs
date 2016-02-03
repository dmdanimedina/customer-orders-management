using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistema_fichas.Business;
using System.Web.Mvc;
using System.ComponentModel;


namespace sistema_fichas.ViewModels
{
    public class ClienteViewModel
    {
        /*
         * SET DE VARIABLES PARA MOSTRAR LOS DATOS DEL CLIENTE
         */
        public sistema_fichas.Business.Cliente cliente { get; set; }

        /*
        * SET DE VARIABLES PARA MOSTRAR LOS TIPOS DE CLIENTE DISPONIBLES
        */
        public SelectList ListaTipoCliente
        {
            get
            {
                return new SelectList(TiposCliente, "ID", "Sigla", null);
            }
        } /*
        * SET DE VARIABLES PARA MOSTRAR LOS ESTADOS DE LOS CLIENTES
        */
        [DisplayName("Estado Cliente")]
        public SelectList ListaEstadoCliente { get { return new SelectList(EstadoCliente.Where(s=> s.Value != "0").ToList(), "text", "value", (this.cliente == null) ? null : this.cliente.Estado.ToString()); } }
        public IEnumerable<SelectListItem> EstadoCliente
        {
            get
            {
                return new SelectList(new[]{
                                          new SelectListItem{ Text="Activo", Value="1"},
                                          new SelectListItem{ Text="Bloqueado", Value="2"},
                                          new SelectListItem{ Text="Inactivo", Value="0"}
                                        }, "Text", "Value", "1");
            }
        }

        [DisplayName("Tipo Cliente")]
        public IEnumerable<string> TiposCliente { get; set; }
        /*
         * SET DE VARIABLES PARA MOSTRAR LAS INDUSTRIAS DISPONIBLES
         */
        public SelectList ListaIndustrias { 
            get 
            {
                return new SelectList(Industrias, "ID", "Nombre", (this.cliente == null) ? null : this.cliente.Industria_ID);
            }
        }
        
        
        /* List Entities */
        [DisplayName("Industrias")]
        public IEnumerable<sistema_fichas.Business.Industria> Industrias { get; set; }
        [DisplayName("Pedidos")]
        public IEnumerable<sistema_fichas.Business.Pedido> Pedidos { get; set; }
        [DisplayName("Usuarios")]
        public IEnumerable<sistema_fichas.Business.UserProfile> Usuarios { get; set; }
        [DisplayName("Direcciones")]
        public IEnumerable<Direccion> Direcciones { get; set; }
        [DisplayName("Contactos")]
        public IEnumerable<Contacto> Contactos { get; set; }

        /*
         * SET DE VARIABLES PARA MOSTRAR LOS USUARIOS DISPONIBLES
         */
        [DisplayName("Asignado a")]
        public SelectList ListaUsuarios { get {
            return new SelectList(Usuarios, "UserId", "UserName");
        } }

        

        /*
         * SET DE VARIABLES PARA MOSTRAR LAS DIRECCIONES DISPONIBLES
         */
        [DisplayName("Dirección")]
        public Direccion Direccion { get; set; }

        [DisplayName("Contacto Comercial")]
        public Contacto ContactoComercial { get; set; }
        
        [DisplayName("Contacto Facturación")]
        public Contacto ContactoFacturacion { get; set; }
        
        [DisplayName("Contacto Instalación")]
        public Contacto ContactoInstalacion { get; set; }

        

        

        public ClienteViewModel() {
            Industrias = new HashSet<Industria>();
            Usuarios = new HashSet<UserProfile>();
            Pedidos = new HashSet<Pedido>();
        }

    }    
}