using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ViewModel
{
    public class BlogArticleViewModels
    {
        public int Id { get; set; }

        public string Submitter { get; set; }

        public string Title { get; set; }

        public string Digest { get; set; }

        public string Previous { get; set; }

        public int PreviousId { get; set; }

        public string Next { get; set; }

        public int NextId { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Traffic { get; set; }

        public int CommentNum { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
