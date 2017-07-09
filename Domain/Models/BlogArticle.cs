using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BlogArticle
    {
        public int Id { get; set; }

        public string Submitter { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Traffic { get; set; }

        public string Remark { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
