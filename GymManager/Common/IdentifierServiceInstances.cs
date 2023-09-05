using System;
using System.Collections.Generic;

namespace GymManager.Common
{
    public class IdentifierServiceInstances
    {
        private static readonly Dictionary<string, IdentifierService> instances = new();

        public void Add(IdentifierService service, string name)
        {
#if !DEBUG
            if (instances.ContainsKey(name))
                throw new Exception($"Nazwa usługi {name} już występuje.");
#else
            if(instances.ContainsKey(name))
            {
                return;
            }
#endif

            instances.Add(name, service);
        }

        public IdentifierService GetIdentifierService(string name)
        {
            if(!instances.ContainsKey(name))
            {
                throw new Exception($"Wybrana usługa {name} nie występuje.");
            }

            return instances[name];
        }

        public void Remove(string name)
        {
            instances.Remove(name);
        }
    }
}