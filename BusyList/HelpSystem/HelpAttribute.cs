using System;

namespace BusyList.HelpSystem
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HelpAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public string Syntax { get; }

        public HelpAttribute(string name, string description, string syntax)
        {
            Name = name;
            Description = description;
            Syntax = syntax;
        }
    }
}
