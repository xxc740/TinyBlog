using Domain.Models;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.ViewModel;
using Repository.Blog;
using AutoMapper;
using Common.ToolHelper;

namespace Service.Blog
{
    public class BlogArticleServices : BaseService<BlogArticle>, IBlogArticleServices
    {
        IBlogArticleRepository dal;

        public BlogArticleServices(IBlogArticleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public BlogArticleViewModels getBlogDetails(int id)
        {
            BlogArticle blogArticle = dal.QuerySingle(a => a.Id == id).FirstOrDefault();
            BlogArticle nextBlog = dal.QuerySingle(a => a.Id == id - 1).FirstOrDefault();
            BlogArticle preBlog = dal.QuerySingle(a => a.Id == id + 1).FirstOrDefault();
            blogArticle.Traffic += 1;
            dal.Edit(blogArticle, new string[] { "traffic" });
            dal.SaveChange();

            Mapper.Initialize(cfg => cfg.CreateMap<BlogArticle, BlogArticleViewModels>());
            BlogArticleViewModels model = Mapper.Map<BlogArticle, BlogArticleViewModels>(blogArticle);

            if(nextBlog != null)
            {
                model.Next = nextBlog.Title;
                model.NextId = nextBlog.Id;
            }

            if (preBlog != null)
            {
                model.Previous = preBlog.Title;
                model.PreviousId = preBlog.Id;
            }

            model.Digest = Tools.ReplaceHtmlTag(blogArticle.Content).Length > 100 ? Tools.ReplaceHtmlTag(blogArticle.Content).Substring(0, 200) : Tools.ReplaceHtmlTag(blogArticle.Content);

            return model;
        }
    }
}
