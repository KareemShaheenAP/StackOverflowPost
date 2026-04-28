using System.ComponentModel;

namespace StackOverflowPost
{
    public class Post
    {
        private int _vote;
        public int Vote
        {
            get
            {
                return _vote;
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
        }
        public void VoteUpCount()
        {
            _vote++;
        }
        public void VoteDownCount()
        {
            _vote--;
        }
        public int GetCurrentVote()
        {
            return _vote;
        }
    }
    enum Voting
    {
        [Description("Up Vote Press 1")] Up,
        [Description("Down Vote Press 2")] Down
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Post post = new Post("OOP discussion", "for beginners");
            do
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Desc.: {post.Description}");
                Console.WriteLine($"Created at: {post.CreatedAt}");
                Console.WriteLine($"Current Vote: {post.GetCurrentVote()}\n=============================");

                Console.WriteLine("\nUp Vote Press 1");
                Console.WriteLine("Down Vote Press 2");
                Voting vote = (Voting)int.Parse(Console.ReadLine()) - 1;
                switch (vote)
                {
                    case Voting.Up:
                        post.VoteUpCount();
                        break;
                    case Voting.Down:
                        post.VoteDownCount();
                        break;
                    default:
                        return;
                }
                Console.Clear();
            } while (true);
        }
    }
}
