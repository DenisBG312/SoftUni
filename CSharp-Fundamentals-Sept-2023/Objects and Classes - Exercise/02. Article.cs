namespace _02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleStr = Console.ReadLine()
                .Split(", ");

            int count = int.Parse(Console.ReadLine());

            Article article = new Article(articleStr[0], articleStr[1], articleStr[2]);

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ");

                if (command[0] == "Edit")
                {
                    string newContent = command[1];
                    article.Edit(newContent);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    string newAuthor = command[1];
                    article.ChangeAuthor(newAuthor);
                }
                else if (command[0] == "Rename")
                {
                    string newTitle = command[1];
                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);
        }
    }
}
