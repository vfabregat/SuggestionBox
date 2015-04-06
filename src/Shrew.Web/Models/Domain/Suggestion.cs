
namespace Shrew.Web.Models.Domain
{
    public class Suggestion
    {
        public string Body { get; private set; }

        public Votes Votes { get; set; }
        public Suggestion(string body)
        {
            this.Body = body;
            Votes = new Votes();
        }

        public void VoteUp(string userWhoVote)
        {
            //TODO: Check concurrency when save!
            //Votes++;

            Votes.Add(new Vote(userWhoVote, VoteType.Positive));
        }

        public void VoteDown()
        {
            //Votes--;
        }

        public int TotalVotes
        {
            get
            {
                return Votes.Count;
            }
        }
    }
}