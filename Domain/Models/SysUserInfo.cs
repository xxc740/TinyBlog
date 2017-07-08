using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SysUserInfo
    {
        public Guid Id { get; set; }

        public string LoginName { get; set; }

        public string LoginPassword { get; set; }

        public string RealName { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
