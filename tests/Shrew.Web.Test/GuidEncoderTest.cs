using System;
using MongoDB.Bson;
using Xunit;

namespace Shrew.Web.Test
{
    public class GuidEncoderTest
    {

        [Fact]
        public void ObjectIdCanBeConverterToAString()
        {
            var textGuid = "5514825e9c62566efcb6144f";
            var expected = "VRSCXpxiVm78thRP";

            var result = ObjectIdEncoder.Encode(textGuid);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void ObjectIdCanBeDecodedFromString()
        {
            var expected = new ObjectId("5514825e9c62566efcb6144f");
            var encoded = "VRSCXpxiVm78thRP";

            var result = ObjectIdEncoder.Decode(encoded);

            Assert.Equal(expected, result);
        }
    }
}
