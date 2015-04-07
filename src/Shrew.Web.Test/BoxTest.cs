using System;
using System.Linq;
using Shrew.Web.Models.Domain;
using Shrew.Web.Models.Exceptions;
using Xunit;

namespace Test
{
    public class BoxTest
    {
        [Fact]
        public void NameIsRequired()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var box = new Box(null, null, false);
            });
        }

        [Fact]
        public void UserCanAddSuggestionToAnPublishBox()
        {
            var box = new Box("Test suggestions", string.Empty, true);
            box.Publish();
            box.AddSuggestion("This should be pass");

            Assert.Equal(1, box.Suggestions.Count());
        }

        [Fact]
        public void UserCanNotAddSuggestionToAnUnpublishedBox()
        {
            Assert.Throws<SuggestionException>(() =>
            {
                var box = new Box("Test suggestions", string.Empty, false);

                box.AddSuggestion("This should throw an exception");

            });
        }
    }
}
