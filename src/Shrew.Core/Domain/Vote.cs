using Newtonsoft.Json;
using Shrew.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shrew.Core.Domain
{
    [JsonObject]
    public class Votes : IEnumerable<Vote>
    {
        List<Vote> internalVotes = new List<Vote>();

        public Votes()
        {

        }
        public void Add(Vote item)
        {
            if (this.Contains(item))
                throw new VoteException("This user already vote this suggestion");
            internalVotes.Add(item);
        }

        public bool Contains(Vote item)
        {
            if ((object)item == null)
            {
                foreach (var vote in internalVotes)
                {
                    if ((object)vote == null)
                        return true;
                }
                return false;
            }
            else
            {
                EqualityComparer<Vote> @default = EqualityComparer<Vote>.Default;
                //for (int index = 0; index < this._size; ++index)
                foreach (var vote in internalVotes)
                {
                    if (@default.Equals(vote, item))
                        return true;
                }
                return false;
            }
        }

        public int Count
        {
            get
            {
                return internalVotes.Sum(v => v.Value);
            }
        }

        public IEnumerator<Vote> GetEnumerator()
        {
            return internalVotes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalVotes.GetEnumerator();
        }
    }

    public class Vote : IEquatable<Vote>
    {
        public string User { get; private set; }
        public VoteType Type { get; private set; }
        internal short Value { get { return value; } }
        private short value;
        public Vote(string user, VoteType type)
        {
            this.User = user;
            this.Type = type;
            this.value = (short)type;

        }

        public bool Equals(Vote other)
        {
            return this.User == other.User
                && this.Type == other.Type;
        }
    }

    public enum VoteType : short
    {
        Positive = 1,
        Negative = -1
    }
}
