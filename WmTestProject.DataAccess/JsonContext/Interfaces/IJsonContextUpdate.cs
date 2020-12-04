using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.DataAccess.JsonContext.Interfaces
{
    public interface IJsonContextUpdate<TEntity>
    {
        public void Update(TEntity entity);
    }
}
