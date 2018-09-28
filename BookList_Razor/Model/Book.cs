namespace BookList_Razor.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Availibility { get; set; }
        public double Price { get; set; }
    }
}