using System.Text;
using static SabreTools.Models.Xbox.Constants;

namespace SabreTools.Printing
{
    public static class XMID
    {
        public static void Print(StringBuilder builder, Models.Xbox.XMID xmid)
        {
            builder.AppendLine("Xbox Media Identifier Information:");
            builder.AppendLine("-------------------------");
            builder.AppendLine(xmid.PublisherIdentifier, "Publisher identifier");
            if (!string.IsNullOrWhiteSpace(xmid.PublisherIdentifier) && Publishers.ContainsKey(xmid.PublisherIdentifier))
                builder.AppendLine(Publishers[xmid.PublisherIdentifier], "Publisher");
            builder.AppendLine(xmid.GameID, "Game ID");
            builder.AppendLine(xmid.VersionNumber, "Version number");
            builder.AppendLine(xmid.RegionIdentifier, "Region identifier");
            if (Regions.ContainsKey(xmid.RegionIdentifier))
                builder.AppendLine(Regions[xmid.RegionIdentifier], "Region");
            builder.AppendLine();
        }
    }
}