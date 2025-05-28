using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Models a single comment on a video
    class Comment
    {
        public string Author { get; }
        public string Text   { get; }

        public Comment(string author, string text)
        {
            Author = author;
            Text   = text;
        }
    }

    // Models a YouTube‐style video with a list of comments
    class Video
    {
        public string Title    { get; }
        public string Author   { get; }
        public int    LengthInSeconds { get; }

        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title            = title;
            Author           = author;
            LengthInSeconds  = lengthInSeconds;
        }

        // Add a comment to this video
        public void AddComment(Comment c)
        {
            _comments.Add(c);
        }

        // Return how many comments this video has
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        // Expose comments for iteration
        public IEnumerable<Comment> Comments => _comments;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a few sample videos
            var videos = new List<Video>
            {
                new Video("Intro to C#",    "Alice", 300),
                new Video("LINQ Deep Dive", "Bob",   420),
                new Video("Async/Await",    "Cara",  360),
                new Video("Design Patterns","Dave",  540)
            };

            // Add some comments to each
            videos[0].AddComment(new Comment("Xavier", "Great intro, thanks!"));
            videos[0].AddComment(new Comment("Yara",   "Clear and concise."));
            videos[0].AddComment(new Comment("Zane",   "Can you show more examples?"));

            videos[1].AddComment(new Comment("Amy",    "LINQ saved my life."));
            videos[1].AddComment(new Comment("Brian",  "Very thorough."));
            videos[1].AddComment(new Comment("Cara",   "Loved the examples."));

            videos[2].AddComment(new Comment("Eli",    "Async/await still confusing."));
            videos[2].AddComment(new Comment("Fay",    "Please cover error handling!"));
            videos[2].AddComment(new Comment("Gus",    "Nice pacing."));

            videos[3].AddComment(new Comment("Helen",  "Singleton is dangerous."));
            videos[3].AddComment(new Comment("Ian",    "Factory pattern FTW."));
            videos[3].AddComment(new Comment("Jane",   "Can you do a decorator demo?"));

            // Display each video’s info and its comments
            foreach (var vid in videos)
            {
                Console.WriteLine($"Title : {vid.Title}");
                Console.WriteLine($"Author: {vid.Author}");
                Console.WriteLine($"Length: {vid.LengthInSeconds} seconds");
                Console.WriteLine($"Comments ({vid.GetCommentCount()}):");
                foreach (var cm in vid.Comments)
                {
                    Console.WriteLine($"\t{cm.Author}: {cm.Text}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
