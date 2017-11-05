using System;

namespace Channel9.Models
{
    public class Episode
    {
        public Episode(
             string key,
             string title,
             string description,
             string itemThumbnail,
             TimeSpan duration,
             string subtitle,
             string feedId = "")
        {
            Id = Guid.NewGuid();
            Uri = key;
            Title = title;
            Description = description;
            ItemThumbnail = itemThumbnail;
            Duration = duration;
            Subtitle = subtitle;
            FeedId = feedId;
        }

        public Guid Id { get; set; }

        public string Uri { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ItemThumbnail { get; set; }

        public string FeedId { get; set; }

        public TimeSpan Duration { get; set; }

        public string Subtitle { get; set; }

        public override string ToString()
        {
            return Title ?? string.Empty;
        }
    }
}