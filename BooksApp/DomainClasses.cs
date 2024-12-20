﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? GenreId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public decimal? Price { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
