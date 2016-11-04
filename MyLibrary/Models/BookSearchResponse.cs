namespace MyLibrary.Models
{
    using System;
    using System.Collections.Generic;

    public partial class BookSearchResponse
    {
        public string Query { get; set; }
        public IEnumerable<Book> Result { get; set; }
        public Exception Exception { get; set; }
    }
}