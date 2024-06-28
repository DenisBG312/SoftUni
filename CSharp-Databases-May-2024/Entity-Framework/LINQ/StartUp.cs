using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);



            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var album in albumsInfo)
            {
                    sb.AppendLine($"-AlbumName: {album.Name}");
                    sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                    sb.AppendLine($"-ProducerName: {album.ProducerName}");
                    sb.AppendLine("-Songs:");

                    int currentSongNum = 0;
                foreach (var s in album.Songs)
                {
                    currentSongNum++;


                    sb.AppendLine($"---#{currentSongNum}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsInfo = context.Songs
                .Include(song => song.Writer)
                .Include(song => song.SongPerformers)
                .ThenInclude(songPerformer => songPerformer.Performer)
                .Include(song => song.Album)
                .ThenInclude(album => album.Producer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformersName = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}"),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            var sb = new StringBuilder();

            int number = 0;

            foreach (var s in songsInfo)
            { 
                number++;
                sb.AppendLine($"-Song #{number}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.WriterName}");

                if (s.PerformersName.Any())
                {
                    foreach (var name in s.PerformersName
                                 .OrderBy(s => s))
                    {
                        sb.AppendLine($"---Performer: {name}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.Duration}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
