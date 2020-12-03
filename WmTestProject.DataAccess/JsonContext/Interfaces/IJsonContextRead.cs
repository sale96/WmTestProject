using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.DataAccess.JsonContext.Interfaces
{
    public interface IJsonContextRead<TData>
    {
        TData Read();
    }
}
