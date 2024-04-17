using System.Text;
using SabreTools.Models.VBSP;
using SabreTools.Printing.Interfaces;
using static SabreTools.Models.VBSP.Constants;

namespace SabreTools.Printing
{
    public class VBSP : IPrinter<File>
    {
        /// <inheritdoc/>
        public void PrintInformation(StringBuilder builder, File model)
            => Print(builder, model);

        public static void Print(StringBuilder builder, File file)
        {
            builder.AppendLine("VBSP Information:");
            builder.AppendLine("-------------------------");
            builder.AppendLine();

            Print(builder, file.Header);
        }

        private static void Print(StringBuilder builder, Header? header)
        {
            builder.AppendLine("  Header Information:");
            builder.AppendLine("  -------------------------");
            if (header == null)
            {
                builder.AppendLine("  No header");
                builder.AppendLine();
                return;
            }

            builder.AppendLine(header.Signature, "  Signature");
            builder.AppendLine(header.Version, "  Version");
            builder.AppendLine(header.MapRevision, "  Map revision");
            builder.AppendLine();

            Print(builder, header.Lumps);
        }

        private static void Print(StringBuilder builder, Lump?[]? lumps)
        {
            builder.AppendLine("  Lumps Information:");
            builder.AppendLine("  -------------------------");
            if (lumps == null || lumps.Length == 0)
            {
                builder.AppendLine("  No lumps");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < lumps.Length; i++)
            {
                var lump = lumps[i];
                string specialLumpName = string.Empty;
                switch (i)
                {
                    case HL_VBSP_LUMP_ENTITIES:
                        specialLumpName = " (entities)";
                        break;
                    case HL_VBSP_LUMP_PAKFILE:
                        specialLumpName = " (pakfile)";
                        break;
                }

                builder.AppendLine($"  Lump {i}{specialLumpName}");
                if (lump == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(lump.Offset, "    Offset");
                builder.AppendLine(lump.Length, "    Length");
                builder.AppendLine(lump.Version, "    Version");
                builder.AppendLine(lump.FourCC, "    4CC");
            }
            builder.AppendLine();
        }
    }
}