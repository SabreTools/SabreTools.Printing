using System.Text;
using SabreTools.Models.NCF;

namespace SabreTools.Printing
{
    public class NCF : IPrinter<File>
    {
        /// <inheritdoc/>
        public void PrintInformation(StringBuilder builder, File model)
            => Print(builder, model);

        public static void Print(StringBuilder builder, File file)
        {
            builder.AppendLine("NCF Information:");
            builder.AppendLine("-------------------------");
            builder.AppendLine();

            // Header
            Print(builder, file.Header);

            // Directory and Directory Maps
            Print(builder, file.DirectoryHeader);
            Print(builder, file.DirectoryEntries);
            // TODO: Should we print out the entire string table?
            Print(builder, file.DirectoryInfo1Entries);
            Print(builder, file.DirectoryInfo2Entries);
            Print(builder, file.DirectoryCopyEntries);
            Print(builder, file.DirectoryLocalEntries);
            Print(builder, file.UnknownHeader);
            Print(builder, file.UnknownEntries);

            // Checksums and Checksum Maps
            Print(builder, file.ChecksumHeader);
            Print(builder, file.ChecksumMapHeader);
            Print(builder, file.ChecksumMapEntries);
            Print(builder, file.ChecksumEntries);
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

            builder.AppendLine(header.Dummy0, "  Dummy 0");
            builder.AppendLine(header.MajorVersion, "  Major version");
            builder.AppendLine(header.MinorVersion, "  Minor version");
            builder.AppendLine(header.CacheID, "  Cache ID");
            builder.AppendLine(header.LastVersionPlayed, "  Last version played");
            builder.AppendLine(header.Dummy1, "  Dummy 1");
            builder.AppendLine(header.Dummy2, "  Dummy 2");
            builder.AppendLine(header.FileSize, "  File size");
            builder.AppendLine(header.BlockSize, "  Block size");
            builder.AppendLine(header.BlockCount, "  Block count");
            builder.AppendLine(header.Dummy3, "  Dummy 3");
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryHeader? header)
        {
            builder.AppendLine("  Directory Header Information:");
            builder.AppendLine("  -------------------------");
            if (header == null)
            {
                builder.AppendLine("  No directory header");
                builder.AppendLine();
                return;
            }

            builder.AppendLine(header.Dummy0, "  Dummy 0");
            builder.AppendLine(header.CacheID, "  Cache ID");
            builder.AppendLine(header.LastVersionPlayed, "  Last version played");
            builder.AppendLine(header.ItemCount, "  Item count");
            builder.AppendLine(header.FileCount, "  File count");
            builder.AppendLine(header.ChecksumDataLength, "  Checksum data length");
            builder.AppendLine(header.DirectorySize, "  Directory size");
            builder.AppendLine(header.NameSize, "  Name size");
            builder.AppendLine(header.Info1Count, "  Info 1 count");
            builder.AppendLine(header.CopyCount, "  Copy count");
            builder.AppendLine(header.LocalCount, "  Local count");
            builder.AppendLine(header.Dummy1, "  Dummy 1");
            builder.AppendLine(header.Dummy2, "  Dummy 2");
            builder.AppendLine(header.Checksum, "  Checksum");
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryEntry?[]? entries)
        {
            builder.AppendLine("  Directory Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No directory entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Directory Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.NameOffset, "    Name offset");
                builder.AppendLine(entry.Name, "    Name");
                builder.AppendLine(entry.ItemSize, "    Item size");
                builder.AppendLine(entry.ChecksumIndex, "    Checksum index");
                builder.AppendLine($"    Directory flags: {entry.DirectoryFlags} (0x{entry.DirectoryFlags:X})");
                builder.AppendLine(entry.ParentIndex, "    Parent index");
                builder.AppendLine(entry.NextIndex, "    Next index");
                builder.AppendLine(entry.FirstIndex, "    First index");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryInfo1Entry?[]? entries)
        {
            builder.AppendLine("  Directory Info 1 Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No directory info 1 entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Directory Info 1 Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.Dummy0, "    Dummy 0");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryInfo2Entry?[]? entries)
        {
            builder.AppendLine("  Directory Info 2 Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No directory info 2 entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Directory Info 2 Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.Dummy0, "    Dummy 0");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryCopyEntry?[]? entries)
        {
            builder.AppendLine("  Directory Copy Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No directory copy entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Directory Copy Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.DirectoryIndex, "    Directory index");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, DirectoryLocalEntry?[]? entries)
        {
            builder.AppendLine("  Directory Local Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No directory local entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Directory Local Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.DirectoryIndex, "    Directory index");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, UnknownHeader? header)
        {
            builder.AppendLine("  Unknown Header Information:");
            builder.AppendLine("  -------------------------");
            if (header == null)
            {
                builder.AppendLine("  No unknown header");
                builder.AppendLine();
                return;
            }

            builder.AppendLine(header.Dummy0, "  Dummy 0");
            builder.AppendLine(header.Dummy1, "  Dummy 1");
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, UnknownEntry?[]? entries)
        {
            builder.AppendLine("  Unknown Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No unknown entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Unknown Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.Dummy0, "    Dummy 0");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, ChecksumHeader? header)
        {
            builder.AppendLine("  Checksum Header Information:");
            builder.AppendLine("  -------------------------");
            if (header == null)
            {
                builder.AppendLine("  No checksum header");
                builder.AppendLine();
                return;
            }

            builder.AppendLine(header.Dummy0, "  Dummy 0");
            builder.AppendLine(header.ChecksumSize, "  Checksum size");
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, ChecksumMapHeader? header)
        {
            builder.AppendLine("  Checksum Map Header Information:");
            builder.AppendLine("  -------------------------");
            if (header == null)
            {
                builder.AppendLine("  No checksum map header");
                builder.AppendLine();
                return;
            }

            builder.AppendLine(header.Dummy0, "  Dummy 0");
            builder.AppendLine(header.Dummy1, "  Dummy 1");
            builder.AppendLine(header.ItemCount, "  Item count");
            builder.AppendLine(header.ChecksumCount, "  Checksum count");
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, ChecksumMapEntry?[]? entries)
        {
            builder.AppendLine("  Checksum Map Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No checksum map entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Checksum Map Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.ChecksumCount, "    Checksum count");
                builder.AppendLine(entry.FirstChecksumIndex, "    First checksum index");
            }
            builder.AppendLine();
        }

        private static void Print(StringBuilder builder, ChecksumEntry?[]? entries)
        {
            builder.AppendLine("  Checksum Entries Information:");
            builder.AppendLine("  -------------------------");
            if (entries == null || entries.Length == 0)
            {
                builder.AppendLine("  No checksum entries");
                builder.AppendLine();
                return;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                builder.AppendLine($"  Checksum Entry {i}");
                if (entry == null)
                {
                    builder.AppendLine("    [NULL]");
                    continue;
                }

                builder.AppendLine(entry.Checksum, "    Checksum");
            }
            builder.AppendLine();
        }
    }
}