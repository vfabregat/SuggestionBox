
using System.Text.RegularExpressions;
using MongoDB.Bson;
namespace System
{
    //public class PrivatePropertySetterResolver : DefaultContractResolver
    //{
    //    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    //    {
    //        var prop = base.CreateProperty(member, memberSerialization);
    //        if (!prop.Writable)
    //        {
    //            var property = member as PropertyInfo;
    //            if (property != null)
    //            {
    //                var hasPrivateSetter = property.GetSetMethod(true) != null;
    //                prop.Writable = hasPrivateSetter;
    //            }
    //        }

    //        return prop;
    //    }
    //}
    public class RavenIdResolver
    {
        public static int Resolve(string ravenId)
        {
            var match = Regex.Match(ravenId, @"\d+");
            var idStr = match.Value;
            int id = int.Parse(idStr);
            if (id == 0)
                throw new System.InvalidOperationException("Id cannot be zero."); // TODO: use code contracts.
            return id;
        }
    }
    public static class ObjectIdEncoder
    {
        public static string Encode(string guidText)
        {
            ObjectId guid = new ObjectId(guidText);

            return Encode(guid);
        }

        public static string Encode(ObjectId guid)
        {
            string encoded = Convert.ToBase64String(guid.ToByteArray());


            encoded = encoded.Replace("/", "_");
            encoded = encoded.Replace("+", "-");
            encoded = encoded.Replace("=", "*");

            return encoded;
        }

        public static ObjectId Decode(string encoded)
        {
            encoded = encoded.Replace("_", "/");
            encoded = encoded.Replace("-", "+");
            encoded = encoded.Replace("*", "=");
            var buffer = Convert.FromBase64String(encoded);

            return new ObjectId(buffer);
        }


    }
}