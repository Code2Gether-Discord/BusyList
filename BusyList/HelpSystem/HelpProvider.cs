using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BusyList.HelpSystem
{
    public class HelpProvider
    {
        private readonly Dictionary<string, (string, string)> _helpText = new();

        public HelpProvider()
        {
            _helpText = Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(x => x.IsDefined(typeof(HelpAttribute)))
                .Select(x => x.GetCustomAttribute<HelpAttribute>())
                .ToDictionary(x => x.Name.ToLowerInvariant(), x => (x.Description, x.Syntax));
        }

        public (string, string)[] GetAllHelpText() => _helpText.Select(x => (x.Key, x.Value.Item1)).ToArray();

        public (string, string) GetHelpText(string key)
        {
            if(_helpText.TryGetValue(key, out var value))
            {
                return value;
            }

            return (null, null);
        }
    }
}
