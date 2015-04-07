using Shrew.Web.Models.Domain;
using Shrew.Web.Models.Exceptions;
using Xunit;
namespace Shrew.Web.Test
{
    public class VotesTest
    {
        [Fact]
        public void AUserCanVoteUpASuggestion()
        {

            //var date = new DateTime(2015, 04, 5, 19, 50, 00);

            //var dateString = date.Humanize(false, null, new CultureInfo("es-ES"));
            var votes = new Votes();

            votes.Add(new Vote("fake user", VoteType.Positive));

            Assert.Equal(1, votes.Count);
        }

        [Fact]
        public void SuggestionWithAnUpVoteAndVoteDownShouldBeZero()
        {
            var votes = new Votes();

            votes.Add(new Vote("fake user", VoteType.Positive));
            votes.Add(new Vote("fake user", VoteType.Negative));

            Assert.Equal(0, votes.Count);
        }


        [Fact]
        public void SuggestionsWithTwoUpVotesShouldBeTwoInTotal()
        {
            var votes = new Votes();

            votes.Add(new Vote("fake user", VoteType.Positive));
            votes.Add(new Vote("Another user", VoteType.Positive));

            Assert.Equal(2, votes.Count);
        }

        [Fact]
        public void TheSameUserCannotVoteTwiceTheSameSuggestion()
        {
            Assert.Throws<VoteException>(() =>
            {
                var votes = new Votes();

                votes.Add(new Vote("fake user", VoteType.Positive));
                votes.Add(new Vote("fake user", VoteType.Positive));
            });
        }
    }
}
