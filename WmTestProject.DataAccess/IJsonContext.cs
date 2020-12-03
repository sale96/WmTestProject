using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.DataAccess
{
    public interface IJsonContext
    {
        IEnumerable<TEntity> Read<TEntity>() where TEntity : BaseDto;
        void Write<TEntity>(TEntity entity) where TEntity : BaseDto;
    }
}
