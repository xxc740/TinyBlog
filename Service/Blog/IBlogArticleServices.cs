using Domain.Models;
using Domain.Models.ViewModel;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Blog
{
    public interface IBlogArticleServices:IBaseService<BlogArticle>
    {
        BlogArticleViewModels getBlogDetails(int id);
    }
}
