using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCore.Utilities.Tools
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
