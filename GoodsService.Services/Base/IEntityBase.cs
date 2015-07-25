using System;

namespace GoodsService.Core.Data
{
    public interface IEntityBase<Tid>
    {
        Tid Id { get; set; }
    }

    public interface IEntityBase : IEntityBase<Guid>
    {
    }
}