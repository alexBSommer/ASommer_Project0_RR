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
    public class DataHandler
    {
        public string RestaurauntToString(Restauraunt target)
        {

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restauraunt));
                ser.WriteObject(ms, target);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }
        public Restauraunt StringToRestauraunt(string json)
        {
            //deserializer goes here
            Restauraunt deserializedRestauraunt = new Restauraunt();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedRestauraunt.GetType());
            deserializedRestauraunt = ser.ReadObject(ms) as Restauraunt;
            ms.Close();
            return deserializedRestauraunt;

        }
        public List<Restauraunt> GetRestaraunts(string json)
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
