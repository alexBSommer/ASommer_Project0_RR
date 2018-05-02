using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using RestarauntReviewerLibrary;

namespace RestarauntReviewerLibrary
{
    public static class DataHandler
    {
        public static string RestaurauntToString(Restauraunt target)
        {
            
            MemoryStream ms = new MemoryStream();
            string jsonString;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restauraunt));
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                ser.WriteObject(ms, target);
                ms.Position = 0;
                jsonString= sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
            return jsonString;
        }
        public static Restauraunt StringToRestauraunt(string jsonString)
        {
            //deserializer goes here
            Restauraunt deserializedRestauraunt;
            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restauraunt));
                byte[] bytes = Encoding.ASCII.GetBytes(jsonString);
                ms.Write(bytes, 0, Encoding.ASCII.GetByteCount(jsonString));
                ms.Position = 0;
                deserializedRestauraunt = (Restauraunt)ser.ReadObject(ms);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
            return deserializedRestauraunt;
        }
        public static List<Restauraunt> GetRestaraunts(string json)
        {
            using (Stream stream = File.OpenRead(json))
            {
                var ser = new DataContractJsonSerializer(typeof(RestarauntList));
                RestarauntList list = (RestarauntList)ser.ReadObject(stream);
                return list.restaraunts;
            }

        }
        public static T DeserializeJSon<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(stream);
            return obj;
            // to use: var obj = DeserializeJSon<Type>(jsonString);
            //or : var obj = DeserializeJSon<List<Type>>(jsonString);
        }
    }
    [DataContract]
    public class RestarauntList
    {
        [DataMember]
        public List<Restauraunt> restaraunts { get; set; }
    }
}
