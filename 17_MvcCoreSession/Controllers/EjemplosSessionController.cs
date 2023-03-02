using _17_MvcCoreSession.Extensions;
using _17_MvcCoreSession.Helpers;
using _17_MvcCoreSession.Models;
using Microsoft.AspNetCore.Mvc;

namespace _17_MvcCoreSession.Controllers
{
    public class EjemplosSessionController : Controller
    {
        int numero = 1;

        public IActionResult Index()
        {
            ViewData["NUMERO"] = "Valor del numero: " + this.numero;
            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            this.numero += 1;
            ViewData["NUMERO"] = "Valor del numero: " + this.numero;

            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "NERFO");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());

                    ViewData["MENSAJE"] = "Datos almacenados en Session";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }

            return View();
        }

        public IActionResult SessionPersona(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Persona persona = new Persona();
                    persona.Nombre = "Jaime";
                    persona.Email = "blabla";
                    persona.Edad = 21;

                    //DEBEMOS CONVERTIR EL OBJETO PERSONA A BYTE[] PARA ALMACENARLO EN SESSION
                    byte[] data = HelperBinarySession.ObjectToByte(persona);

                    //ALMACENAMOS EL OBJETO BINARIO EN SESSION
                    HttpContext.Session.Set("PERSONA", data);
                    ViewData["MENSAJE"] = "Datos almacenados";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //XTRAEMOS EL OBJETO PERSONA DESDE LOS BYTES[] DE SESSION
                    byte[] data = HttpContext.Session.Get("PERSONA");

                    //CONVERTIMOS EL BINARIO A OBJETO
                    Persona persona = (Persona)HelperBinarySession.ByteToObject(data);
                    ViewData["PERSONA"] = persona;
                }
            }

            return View();
        }

        public IActionResult ColeccionSessionPersona(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Persona> personas = new List<Persona>
                    {
                        new Persona { Nombre = "Lolo", Email = "lolo", Edad = 22 },
                        new Persona { Nombre = "Lola", Email = "lola", Edad = 23 },
                        new Persona { Nombre = "Lolu", Email = "lolu", Edad = 24 },
                        new Persona { Nombre = "Loli", Email = "loli", Edad = 25 },
                        new Persona { Nombre = "Lole", Email = "lole", Edad = 26 }
                    };
                    byte[] data = HelperBinarySession.ObjectToByte(personas);
                    HttpContext.Session.Set("LISTAPERSONAS", data);
                    ViewData["MENSAJE"] = "Coleccion almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("LISTAPERSONAS");
                    List<Persona> personas = (List<Persona>)HelperBinarySession.ByteToObject(data);

                    return View(personas);
                }
            }

            return View();
        }

        public IActionResult SessionPersonaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Persona persona = new Persona();
                    persona.Nombre = "Jaime";
                    persona.Email = "blabla";
                    persona.Edad = 21;

                    string jsonPersona = HelperJsonSession.SerializeObject<Persona>(persona);
                    HttpContext.Session.SetString("PERSONA", jsonPersona);

                    ViewData["MENSAJE"] = "Datos almacenados";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //XTRAEMOS EL OBJETO PERSONA DESDE EL STRING
                    string jsonPersona = HttpContext.Session.GetString("PERSONA");

                    Persona persona = HelperJsonSession.DeserializeObject<Persona>(jsonPersona);

                    ViewData["PERSONA"] = persona;
                }
            }

            return View();
        }

        public IActionResult SessionPersonaObject(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Persona persona = new Persona();
                    persona.Nombre = "Jaime Object";
                    persona.Email = "blabla object";
                    persona.Edad = 21;

                    HttpContext.Session.SetObject("PERSONAOBJECT", persona);

                    ViewData["MENSAJE"] = "Datos almacenados";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    Persona persona = HttpContext.Session.GetObject<Persona>("PERSONAOBJECT");

                    ViewData["PERSONA"] = persona;
                }
            }

            return View();
        }

        public IActionResult ColeccionSessionObject(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Persona> personas = new List<Persona>
                    {
                        new Persona { Nombre = "Lolo", Email = "lolo", Edad = 22 },
                        new Persona { Nombre = "Lola", Email = "lola", Edad = 23 },
                        new Persona { Nombre = "Lolu", Email = "lolu", Edad = 24 },
                        new Persona { Nombre = "Loli", Email = "loli", Edad = 25 },
                        new Persona { Nombre = "Lole", Email = "lole", Edad = 26 }
                    };

                    HttpContext.Session.SetObject("LISTAPERSONASOBJECT", personas);
                    ViewData["MENSAJE"] = "Datos almacenados";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    List<Persona> personas = HttpContext.Session.GetObject<List<Persona>>("LISTAPERSONASOBJECT");

                    return View(personas);
                }
            }

            return View();
        }
    }
}
