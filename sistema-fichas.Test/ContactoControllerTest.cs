using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sistema_fichas.Service.Core;
using sistema_fichas.Controllers;
using sistema_fichas.Business;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;


namespace sistema_fichas.Test
{
    [TestClass]
    public class ContactoControllerTest
    {
        private Mock<IContactoService> _contactoServiceMock;
        private Mock<IClienteService> _clienteServiceMock;
        ContactoController objController;
        List<Contacto> listContacto;

        [TestInitialize]
        public void Initialize()
        {

            _contactoServiceMock = new Mock<IContactoService>();
            _clienteServiceMock = new Mock<IClienteService>();
            objController = new ContactoController(_contactoServiceMock.Object, _clienteServiceMock.Object);
            listContacto = new List<Contacto>() {
                   new Contacto() { ID = 1, Nombres = "sergio", Celular="85566689", Estado=1 },
                   new Contacto() { ID = 2, Nombres = "esteban", Celular="85566689", Estado=1 },
                   new Contacto() { ID = 3, Nombres = "cardenas", Celular="85566689", Estado=1 },
                  };
        }

        [TestMethod]
        public void Contacto_Get_All()
        {
            _contactoServiceMock.Setup(x => x.GetAllByCriteria(It.IsAny<String>(), It.IsAny<String>(), true)).Returns(listContacto);

            var result = ((objController.Index(null, null) as ViewResult).Model) as List<Contacto>;
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("sergio", result[0].Nombres);
            Assert.AreEqual("esteban", result[1].Nombres);
            Assert.AreEqual("cardenas", result[2].Nombres);
        }

        [TestMethod]
        public void Contacto_Details()
        {
            int id = It.IsAny<int>();
            _contactoServiceMock.Setup(x => x.GetById(id)).Returns(listContacto[0]);

            var result = ((objController.Details(id) as ViewResult).Model) as Contacto;

            Assert.AreEqual("sergio", result.Nombres);
            Assert.AreEqual("85566689", result.Celular);
            Assert.AreEqual(1, result.Estado);
        }
    
        [TestMethod]
        public void Valid_Country_Create()
        {
            
            //Contacto c = new Contacto() { ID = 1 , Nombres = "cardenas", Celular = "85566689", Estado = 1 };
            //_contactoServiceMock.Verify(m => m.Create(c), Times.Once);
            //_contactoServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(c);

            Cliente cl = new Cliente();
            _clienteServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(cl);

            var result = (ViewResult)objController.CrearContacto(It.IsAny<int>());

            string class_name = result.Model.GetType().Name;
            Assert.AreEqual("Contacto", class_name);
            Assert.AreEqual("", result.ViewName);
          
        }
    }
}
