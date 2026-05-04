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
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title cannot be null.");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description cannot be null.");
            }
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
            Console.WriteLine("Enter Title");
            var title = Console.ReadLine();
            Console.WriteLine("Enter description");
            var desc = Console.ReadLine();
            Post post = new Post(title, desc);
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
