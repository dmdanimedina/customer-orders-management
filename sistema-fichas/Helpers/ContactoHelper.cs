using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace sistema_fichas.Helpers
{
    public class Tipo {
        public int index { get; set; }
        public string text { get; set; }
    }

    public static class ContactoHelper
    {

        public static List<Tipo> Tipos = new List<Tipo>() { 
                                new Tipo(){ index = 1 , text = "Comercial" },
                                new Tipo(){ index = 2 , text = "Instalación"},
                                new Tipo(){ index = 3 , text = "Facturación"},
                                new Tipo(){ index = 4 , text = "Usuario"},
                                new Tipo(){ index = 5 , text = "Otro"} 
                            };
        public static IEnumerable<PropertyInfo> getPropertyNames() {
            return typeof(sistema_fichas.Business.Contacto).GetProperties().Where(p => !p.GetGetMethod().IsVirtual && !p.Name.Contains("ID"));
        }

        public static SelectList getPropertyNamesAsSelectList(){
            return new SelectList(getPropertyNames(), "Name", "Name");
        }

        public static SelectList getTiposAsSelectList(int? CurrentIndex){
            return new SelectList(
                Tipos, "index", "text", CurrentIndex
                );
        }

        public static string getTipoName(int? Index){
            string tag = Tipos.Where(x => x.index == Index).FirstOrDefault().text ;
            return (String.IsNullOrEmpty(tag)) ? "N/A" : tag;
        
        }
    }
}