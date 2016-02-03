using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistema_fichas.Business;
using System.Web.Mvc;
using System.ComponentModel;

namespace sistema_fichas.ViewModels
{
    
    public class PedidoViewModel
    {
        public PedidoViewModel() {
            this.Pedido = new Pedido();
            this.Adjunto = new Adjunto();
            this.PedidoDetalle = new PedidoDetalle();
            this.Modalidades = new HashSet<Modalidad>();
            this.Productos = new HashSet<Catalogo>();
            this.Herramientas = new HashSet<Herramienta>();
            this.Monedas = new HashSet<Moneda>();
        }

        public String TipoDetalle { get; set; }
        public Pedido Pedido { get; set; }
        public Adjunto Adjunto { get; set; }
        public PedidoDetalle PedidoDetalle { get; set; }
        public IEnumerable<Modalidad> Modalidades { get; set; }
        public IEnumerable<Herramienta> Herramientas { get; set; }
        public IEnumerable<Moneda> Monedas { get; set; }
        public IEnumerable<UserProfile> Users { get; set; }

        public IEnumerable<PedidoDetalle> HerramientasActivas
        {
            get
            {
                return this.PedidosDetalles.Where(p => p.Tipo == TipoPedidoDetalle.Herramienta.GetHashCode()).ToList();
            }
        }

        public IEnumerable<PedidoDetalle> ActividadesActivas
        {
            get
            {
                return this.PedidosDetalles.Where(p => p.Tipo == TipoPedidoDetalle.Actividad.GetHashCode()).ToList();
            }
        }

        public IEnumerable<PedidoDetalle> ProductosActivos
        {
            get
            {
                return this.PedidosDetalles.Where(p => p.Tipo == TipoPedidoDetalle.Producto.GetHashCode()).ToList();
            }
        }

        public IEnumerable<PedidoDetalle> ServiciosActivos
        {
            get
            {
                return this.PedidosDetalles.Where(p => p.Tipo == TipoPedidoDetalle.Servicio.GetHashCode()).ToList();
            }
        }

        public IEnumerable<Adjunto> AdjuntosActivos
        {
            get
            {
                return Pedido.Adjuntos.Where(s => s.Estado == 1);
            }
        }
        

        public SelectList ListaHerramientas { get { return new SelectList(this.Herramientas.ToList(), "ID", "Nombre", null); } }
        public SelectList ListaModalidades { get { return new SelectList(this.Modalidades.ToList(), "ID", "Nombre", null); } }
        public SelectList ListaMonedas { get { return new SelectList(this.Monedas.ToList(), "ID", "Alias", null); } }
        public SelectList ListaProductos { get { return new SelectList(Productos.ToList(), "ID", "Nombre", null); } }
        public SelectList ListaEstadoPedido { get { return new SelectList(EstadosPedidos, "ID", "Nombre", null); } }
        public SelectList ListaClientes { get { return new SelectList(Clientes, "ID", "RazonSocial", null); } }
        public SelectList ListaUsuarios { get { return new SelectList(Users, "UserId", "UserName", null); } }
        public SelectList ListaTipoCobro { get { return new SelectList(new[] { new SelectListItem { Value = "1", Text = "Total" }, new SelectListItem { Value = "2", Text = "Proporcional/Instalación" }, }, "Value", "Text"); } }

        public IEnumerable<PedidoDetalle> PedidosDetalles { get; set; }
        public IEnumerable<Catalogo> Productos { get; set; }
        [DisplayName("Estado Pedido")]
        public IEnumerable<EstadoPedido> EstadosPedidos { get; set; }
        [DisplayName("Clientes")]
        public IEnumerable<Cliente> Clientes { get; set; }
      
    }
}