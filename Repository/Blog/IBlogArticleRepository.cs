using Repository.Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Blog
{
    public interface IBlogArticleRepository:IBaseRepository<BlogArticle>
    {
    }
}
