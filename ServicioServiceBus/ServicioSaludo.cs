using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioServiceBus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioSaludo" in both code and config file together.
    public class ServicioSaludo : IServicioSaludo
    {
        private Dictionary<String,String> saludos =new Dictionary<string, string>()
        {
            {"es","Buenos dias"},
            {"en","Good Morning"},
            {"fr","Bon Jour"},
            {"de","Guten Morgen"}
        };
        
      
        public string GetSaludo(string idioma)
        {
            if (saludos.ContainsKey(idioma))
                return saludos[idioma];

            return saludos["en"];
        }
    }
}
