namespace Boats.NET.Entities
{
    public class BotEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Library { get; set; }
        public int ServerCount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string Invite { get; set; }
        public bool InQueue { get; set; }
        public bool Certified { get; set; }
        public int Votes { get; set; }
    }
}