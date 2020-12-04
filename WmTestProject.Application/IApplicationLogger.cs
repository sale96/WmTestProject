using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Application
{
    public interface IApplicationLogger
    {
        void Log(string name, object data);
    }
}
