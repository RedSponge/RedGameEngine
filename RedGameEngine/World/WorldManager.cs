using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGameEngine.World
{
    public class WorldManager
    {
        private GameEngine engine;

        private List<WorldEntity> entities;
        private WorldPlayer player;

        public WorldManager(GameEngine engine)
        {
            this.engine = engine;
            this.entities = new List<WorldEntity>();
            this.player = null;
        }

        public void SetPlayer(WorldPlayer player) // A Player.
        {
            player.WorldIn = this;
            this.player = player;
        }

        public void AddEntity(WorldEntity entity)
        {
            entity.WorldIn = this;
            this.entities.Add(entity);
        }


        // Tick and Render
        public void Tick()
        {
            if(player == null)
            {
                throw new Exception("Player Not Defined! Use Engine.SetPlayer to set a player!");
            }
            player.Update();
            entities.ForEach(e => {
                e.Update();
                player.InteractWith(e);
            });
            entities.RemoveAll((e) => e.dead);
        }

        public void Render(Graphics g)
        {
            if(player == null)
            {
                return;
            }
            player.Render(g);
            entities.ForEach(e => e.Render(g));
        }

        public List<WorldEntity> GetEntities()
        {
            return entities;
        }
    }
}
