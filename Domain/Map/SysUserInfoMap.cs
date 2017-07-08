using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Map
{
    public class SysUserInfoMap:EntityTypeConfiguration<SysUserInfo>
    {
        public SysUserInfoMap()
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.LoginName).HasMaxLength(60);
            this.Property(u => u.LoginPassword).HasMaxLength(60);
        }
    }
}
