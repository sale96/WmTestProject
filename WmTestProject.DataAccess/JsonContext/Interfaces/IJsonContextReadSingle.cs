using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.DataAccess.JsonContext.Interfaces
{
    public interface IJsonContextReadSingle<TEntity>
    {
        public TEntity ReadSingle(int id);
    }
}
