using Channel9.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// 
namespace Channel9.Services.RssService
{
    public class RssService : IRssService
    {
        public async Task<List<Episode>> GetEpisodesAsync(string uri, string feedId)
        {
            HttpClient client = new HttpClient();
            using (var stream = await client.GetStreamAsync(uri))
            {
                return ParseRssFeed(stream, feedId);
            }
        }

        internal static List<Episode> ParseRssFeed(Stream stream, string feedId = "")
        {
            List<Episode> results = new List<Episode>();

            XNamespace ns = "http://purl.org/rss/1.0/";
            XNamespace mrss = "http://search.yahoo.com/mrss/";
            XNamespace itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd";
            var media = mrss.GetName("media");

            XDocument xdoc = XDocument.Load(stream);

            var items = xdoc.Descendants("item");
            foreach (var item in items)
            {
                string thumbUri = string.Empty;
                XAttribute mediadownload;

                var durationStr = item.Element(itunes + "duration")?.Value;
                TimeSpan duration = TimeSpan.MinValue;
                if (!string.IsNullOrEmpty(durationStr) && durationStr.Contains(":"))
                {
                    duration = TimeSpan.Parse(durationStr);
                }
                else if (!string.IsNullOrEmpty(durationStr) && !durationStr.Contains(":")) // Channel 9
                {
                    duration = TimeSpan.FromSeconds(Convert.ToInt32(durationStr));
                }

                var subtitleStr = item.Element(itunes + "subtitle")?.Value;

                if (string.IsNullOrEmpty(subtitleStr))
                {
                    var cats = item.Elements("category");
                    if (cats != null && cats.Count() > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach(var cat in cats.ToList())
                        {
                            sb.Append($"{cat.Value} ");
                        }

                        subtitleStr = sb.ToString();
                    }
                }

                var desc = item.Element("description");
                var content = item.Elements(mrss + "content").FirstOrDefault();
                if (content != null)
                {
                    mediadownload = content.Attribute("url");
                    var thumbnailElement = content.Element(mrss + "thumbnail");
                    if (thumbnailElement != null)
                    {
                        var thumbnail = thumbnailElement.Attribute("url");
                        thumbUri = thumbnail.Value;
                    }
                }
                else
                {
                    var thumbnailElements = item.Elements(mrss + "thumbnail");
                    XElement thumbElement = null;
                    if (thumbnailElements.Count() >= 4)
                    {
                        thumbElement = thumbnailElements.ElementAt(3);
                    }
                    else if (thumbnailElements.Count() >= 1)
                    {
                        thumbElement = thumbnailElements.ElementAt(0);
                    }

                    if (thumbElement != null)
                    {
                        thumbUri = thumbElement.Attribute("url").Value;
                    }

                    var mediaGroup = item.Elements(mrss + "group");
                    var mediaUriElements = mediaGroup.Elements(mrss + "content");
                    XElement mediaUriElement = null;
                    if (mediaUriElements.Count() >= 4)
                    {
                        mediaUriElement = mediaUriElements.ElementAt(3);
                    }

                    if (mediaUriElements.Count() == 1)
                    {
                        mediaUriElement = mediaUriElements.ElementAt(0);
                    }

                    mediadownload = mediaUriElement?.Attribute("url");
                }

                if (mediadownload == null)
                {
                    var mediadownloadElements = item.Element("enclosure");
                    mediadownload = mediadownloadElements?.Attribute("url");
                }

                if (mediadownload != null)
                {
                    var feed = new Episode(
                        title: item.Element("title").Value,
                        description: desc.Value,
                        key: mediadownload.Value,
                        itemThumbnail: thumbUri,
                        duration: duration,
                        subtitle: subtitleStr,
                        feedId : feedId);
                    results.Add(feed);
                }
                else
                {
                    Debug.WriteLine($"Skipping");
                }
            }

            return results;
        }
    }
}
