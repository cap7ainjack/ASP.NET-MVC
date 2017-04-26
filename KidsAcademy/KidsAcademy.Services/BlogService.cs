using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsAcademy.Models.ViewModels.Blog;
using KidsAcademy.Models.EntityModels;
using AutoMapper;

namespace KidsAcademy.Services
{
    public class BlogService : Service
    {
        public IEnumerable<ArticleVM> GetAllArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles;
            IEnumerable<ArticleVM> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVM>>(articles);
            return vms;
        }
    }
}
