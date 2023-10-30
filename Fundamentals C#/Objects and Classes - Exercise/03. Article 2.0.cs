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

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        List<Article> articles = new List<Article>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] articleStr = Console.ReadLine()
                .Split(", ");

            Article article = new Article(articleStr[0], articleStr[1], articleStr[2]);
            articles.Add(article);
        }

        foreach (Article article in articles)
        {
            Console.WriteLine(article);
        }
        
    }
}
