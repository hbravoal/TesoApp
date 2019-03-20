namespace TesoApp.Common.Entities
{
    using System;
    public interface IEntity
    {
         int Id { get; set; }
         DateTime CreateDate{ get; set; }
    }
}
