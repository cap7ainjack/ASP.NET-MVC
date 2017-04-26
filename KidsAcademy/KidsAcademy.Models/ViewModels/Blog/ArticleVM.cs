
using KidsAcademy.Models.EntityModels;
using System;


namespace KidsAcademy.Models.ViewModels.Blog
{
   public class ArticleVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public ArticleAuthorVM Author { get; set; }
    }
}
