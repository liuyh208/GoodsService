// ***********************************************************************
// Assembly         : GoodsService.Domain
// Author           : Liuyh
// Created          : 02-14-2014 13:29:15
//
// Last Modified By : Liuyh
// Last Modified On : 02-14-2014 12:50:37
// ***********************************************************************
// <copyright file="User.cs" company="Tecocity">
//     Copyright (c) Tecocity. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using GoodsService.Core.Data;

/// <summary>
/// The Entities namespace.
/// </summary>

namespace GoodsService.Domain
{
    /// <summary>
    ///     Class User.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        ///     名称
        /// </summary>
        /// <value>The name.</value>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        /// <value>The email.</value>
        [Required, StringLength(320)]
        public string Email { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        /// <value>The hashed password.</value>
        [Required]
        public string HashedPassword { get; set; }

        /// <summary>
        ///     密码偏转量
        /// </summary>
        /// <value>The salt.</value>
        [Required]
        public string Salt { get; set; }

        /// <summary>
        ///     是否锁定
        /// </summary>
        /// <value><c>true</c> if this instance is locked; otherwise, <c>false</c>.</value>
        public bool IsLocked { get; set; }

        /// <summary>
        ///     创建日期
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     最后更新日期
        /// </summary>
        /// <value>The last updated on.</value>
        public DateTime? LastUpdatedOn { get; set; }

        /// <summary>
        ///     所属部门
        /// </summary>
        /// <value>The department identifier.</value>
        public Guid? DepartmentID { get; set; }
    }
}