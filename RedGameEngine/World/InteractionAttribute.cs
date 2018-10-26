using System;

namespace RedGameEngine.World
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InteractionAttribute : Attribute
    {
        public Type type { get; set; }
    }
}