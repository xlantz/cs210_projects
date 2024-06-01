using System;

class Comment{

    public string Commentator {get; set;}
    public string VideoComment {get; set;}

    public Comment(string commentator, string videoComment){

        Commentator = commentator;
        VideoComment = videoComment;
    }
}

class Video{

    public string Title {get; set;}
    public string Author {get; set;}
    public int Length {get; set;}
    private List<Comment> comments;

    public Video(string title, string author, int length){

        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commentator, string videoComment){

        comments.Add(new Comment(commentator, videoComment));
    }

    public int GetNumComments(){

        return comments.Count;
    }

    public void DisplayInfo(){

        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds\n");
        Console.WriteLine("# of comments: " + GetNumComments());
        Console.WriteLine("Comments:\n");
        foreach (Comment comment in comments){

            Console.WriteLine("- " + comment.Commentator + " said: " + comment.VideoComment);
        }

        Console.WriteLine();
    }
}

class Program{

    static void Main(string[] args){

        List<Video> videos = new List<Video>();

        videos.Add(new Video("I build 10,000 schools in Malaysia", "SeniorPhil", 1000));
        videos.Add(new Video("How to survive in space", "VidAwesome", 280));
        videos.Add(new Video("Webex Master Class", "ITxBus", 600));

        videos[0].AddComment("Moroni123", "Terrible Video!");
        videos[0].AddComment("NoobTube68", "This has change my life.");
        videos[0].AddComment(".Kool.Aide00", "Skool is Kool. Thx for doin this.");

        videos[1].AddComment("wowza1", "This can't be real.");
        videos[1].AddComment("12yokuz", "Why are penguins so problematic in space?");
        videos[1].AddComment("OopZsoup", "Me watching this instead of doing physics");

        videos[2].AddComment("WaynkahMayte", "first");
        videos[2].AddComment("mybrownBAG45", "Why am I watching this at 2am?");
        videos[2].AddComment("adsf45poi8", "When you need this before your business meeting...");

        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
