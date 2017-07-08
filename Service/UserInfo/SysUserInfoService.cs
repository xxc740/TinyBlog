using Domain.Models;
using Repository.UserInfo;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserInfo
{
    public class SysUserInfoService:BaseService<SysUserInfo>,ISysUserInfoService
    {
        ISysUserInfoRepository dal;

        public SysUserInfoService(ISysUserInfoRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
