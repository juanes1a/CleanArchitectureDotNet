namespace Model.Movie
{
    public class Movie
    {
        public Movie(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public string id { get; set; }
        public string name { get; set; }

    }
}
