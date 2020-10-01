namespace DiscordBoats
{
    public class Rating
    {
        internal Rating() { }

        internal Rating(int tier, int count)
        {
            Tier = tier;
            Count = count;
        }

        public int Tier { get; internal set; }

        public int Count { get; internal set; }
    }
}
