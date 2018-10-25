using System;

namespace RedGameEngine.World
{
    public class InteractionAttribute : Attribute
    {
        public Type type { get; set; }
    }
}