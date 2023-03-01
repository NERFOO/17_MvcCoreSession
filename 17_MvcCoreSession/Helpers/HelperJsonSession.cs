using Newtonsoft.Json;

namespace _17_MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //{ NOMBRE=AAA, EDAD=21 }
        //INTERNAMENTE TRABAJAREMOS CON GETSTRING, DEBE RECIBIR UN OBJETO Y TRANSFORMARLO A STRING JSON, TENDREMOS QUE RECIBIR ALGO...
        public static T DeserializeObject<T>(string data)
        {
            //MEDIANTE NEWTONSOFT DESERIALIZAMOS EL OBJETO
            T objeto = JsonConvert.DeserializeObject<T>(data);

            return objeto;
        }

        public static string SerializeObject<T>(T data)
        {
            string json = JsonConvert.SerializeObject(data);

            return json;
        }
    }
}
