using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsAcademy.Models.ViewModels.Blog;
using KidsAcademy.Models.EntityModels;
using AutoMapper;
using KidsAcademy.Models.BindingModels;

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

        public void AddNewArtice(AddArticleBM bm, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            Article model = Mapper.Map<AddArticleBM, Article>(bm);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today;
            this.Context.Articles.Add(model);
            this.Context.SaveChanges();
        }
    }
}
