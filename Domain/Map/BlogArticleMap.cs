using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    public class BlogArticleMap:EntityTypeConfiguration<BlogArticle>
    {
        public BlogArticleMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Title).HasMaxLength(256);
            this.Property(p => p.Submitter).HasMaxLength(60);
            this.Property(p => p.Content).HasColumnType("Text").IsMaxLength();
        }
    }
}
