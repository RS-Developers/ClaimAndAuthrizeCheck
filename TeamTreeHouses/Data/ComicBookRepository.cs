using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses.Models;

namespace TeamTreeHouses.Data
{
    public class ComicBookRepository
    {
        /*** Public Part ***/
        public ComicBook GetComicBook(int id)
        {
            var lComicBook = new ComicBook()
            {
                Id = 3,
                SeriesTitle = "The Amazing Spider-Man",
                IssueNumber = 700,
                DescriptionHtml = "<p>The Amazing Spider-Man Description<p>",
                Artists = new Artist[] 
                {
                    new Artist() { Name = "Dan Scott", Role = "Script", },
                    new Artist() { Name = "Humberto Ramos", Role = "Pencils", },
                },
            };
            //
            if (lComicBook.Id != id)
                return null;
            //
            return lComicBook;
        }
    }
}