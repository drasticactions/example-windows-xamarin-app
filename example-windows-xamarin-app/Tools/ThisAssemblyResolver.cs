using Bezysoftware.Navigation.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace example_windows_app.Tools
{
    public class ThisAssemblyResolver : IAssemblyResolver
    {
        public async Task<IEnumerable<Assembly>> GetAssembliesAsync()
        {
            return new[] { typeof(ThisAssemblyResolver).GetTypeInfo().Assembly };
        }
    }
}
