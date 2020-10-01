using System.Collections.Generic;

namespace DiscordBoats.Models
{
    public interface IBoatBot : IBoatEntity
    {
        string Prefix { get; }

        string Library { get; }

        string AvatarUrl { get; }

        string ShortDescription { get; }

        string LongDescription { get; }

        IReadOnlyList<ulong> OwnerIds { get; }

        string InviteUrl { get; }

        string SupportGuildUrl { get; }

        string WebsiteUrl { get; }

        string RepositoryUrl { get; }

        ulong ServerCount { get; }

        ulong VoteCount { get; }

        string VanityUrl { get; }

        VisibleStatus Visiblity { get; }

        bool IsQueued { get; }

        bool IsCertified { get; }

        IReadOnlyList<string> Categories { get; }

        IReadOnlyList<Rating> Ratings { get; }

        float AverageRating { get; }
    }
}
