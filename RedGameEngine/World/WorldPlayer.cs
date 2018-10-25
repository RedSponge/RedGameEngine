using RedGameEngine.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGameEngine.World
{
    public abstract class WorldPlayer : WorldEntity
    {
        public readonly Dictionary<Type, MethodInfo> actions;
        public KeyHandler KeyHandler;

        public WorldPlayer(WorldManager worldIn=null) : base(worldIn)
        {
            actions = new Dictionary<Type, MethodInfo>();
            SetupInteractionMethods();
        }

        private void SetupInteractionMethods()
        {
            foreach(MethodInfo info in GetType().GetMethods())
            {
                foreach(Attribute a in info.GetCustomAttributes().Where(attr => attr.GetType() == typeof(InteractionAttribute)))
                {
                    Type type = ((InteractionAttribute)a).type;
                    if(!type.IsSubclassOf(typeof(WorldEntity)) && type != typeof(WorldEntity))
                    {
                        throw new Exception("Interaction with non WorldEntity object! " + type.Name + " does not extend WorldEntity!");
                    }
                    actions.Add(type, info);
                }
            }
        }

        public void InteractWith(WorldEntity e)
        {
            Type t = e.GetType();
            if(actions[t] != null)
            {
                MethodInfo info = actions[t];
                info.Invoke(this, new object[] { e });
            }
        }

        [Interaction(type = typeof(WorldEntity))]
        public void InteractionWorldEntity(WorldEntity e)
        {
            MessageBox.Show("Interacted with world entity! " + e);
        }

        public override Color GetRepesentingColor()
        {
            return Color.Green;
        }
    }
}
