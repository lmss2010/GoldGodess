using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Dom
{
    public class MyRead
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户的可用余额
        /// </summary>
        public int fPPT { get; set; }
        /// <summary>
        /// 每期的最大可压注值
        /// </summary>
        public int fSet { get; set; }
        /// <summary>
        /// 每天总的最大可压注值
        /// </summary>
        public int fSetM { get; set; }
        /// <summary>
        /// 当前用户当天已经用掉的可压注值
        /// </summary>
        public int fGameM { get; set; }
    }
}
