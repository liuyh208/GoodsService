using System;
using System.ComponentModel;

namespace GoodsService.Services
{
    public enum EnumTakeOutStatus :int
    {
        /// <summary>
        /// 为提货
        /// </summary>
        New=0,
        /// <summary>
        /// 已派单
        /// </summary>
        Send=5,
        /// <summary>
        /// 提货完成
        /// </summary>
        Over=10
    }
}