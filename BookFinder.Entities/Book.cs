using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.Entities
{
  public  class Book
    {
        public virtual int BookId { get; set; }
        public virtual  string Title { get; set; }
        public virtual string Authors { get; set; }
        public virtual long ISBN { get; set; }
        public virtual DateTime PublishedDate { get; set; }
        public virtual string CoverPageURL { get; set; }
    }
}
