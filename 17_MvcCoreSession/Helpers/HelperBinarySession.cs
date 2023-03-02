using System.Runtime.Serialization.Formatters.Binary;

namespace _17_MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        //TENDREMOS DOS METODOS STATIC, UNO PARA CONVERTIR BINARY A OBJECT
        public static byte[] ObjectToByte(Object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);

                return stream.ToArray();
            }
        }

        //OTRO METODO PARA RECUPERAR UN BINARY A OBJECT
        public static Object ByteToObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);

                Object objeto = (Object)formatter.Deserialize(stream);

                return objeto;
            }
        }
    }
}
