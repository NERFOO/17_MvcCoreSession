using _17_MvcCoreSession.Helpers;

namespace _17_MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        //QUEREMOS UN METODO GETOBJECT<T>(KEY)
        public static T GetObject<T> (this ISession session, string key)
        {
            //QUEREMOS RECUPERRAR DATOS DE LA SESSION MEDIANTE UN KEY
            string json = session.GetString(key);

            //QUE SUCEDE CON SESSION CUANDO RECUPERAMOS ALGO QUE NO EXISTE???
            if(json == null)
            {
                //CUANDO UTILIZAMOS GENERICOS NO PODEMOS DEVOLVER NULL
                //SE DEVULVE EL VALOR POR DEFECTO DEL TIPO
                return default(T);
            } else
            {
                T data = HelperJsonSession.DeserializeObject<T>(json);

                return data;
            }
        }

        //QUEREMOS UN METODO SETOBJECT<T>(KEY, OBJETO)
        public static void SetObject(this ISession session, string key, object value)
        {
            //TENEMOS QUE PASAR A JSON STRING EL OBJECT VALUE
            string data = HelperJsonSession.SerializeObject(value);

            //ALMACENAMOS EL JSON EN SESSION 
            session.SetString(key, data);
        }

    }
}
