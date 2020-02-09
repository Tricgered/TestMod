using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Projectiles
{
	public class ReverseBombProj : ModProjectile
	{
        float yGrav = 0f;
        public override void SetDefaults()
        {
            projectile.Name = "ReverseBomb"; // Name of projectile
            projectile.width = 10;   // hitbox width
            projectile.height = 24;   // hitbox height
            projectile.aiStyle = 16;   // projectile type: 16 is Grenades, Dynamite, Bombs, Sticky Bombs.
            projectile.friendly = true;  // Friendly to players/Npcs or not
            projectile.penetrate = -1;   // amount of enemies it can hit before being destroyed
            projectile.timeLeft = 200;   // projectile lifetime
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 8;    // Explosive radius

            for(int x = -radius; x <= radius; x++)
            {
                for(int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if(Math.Sqrt(x * x + y * y) <= radius + 0.5)   // this makes it so the explosion radius is a circle
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);   // this makes the explosion destroy tiles
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f); // this is the dust that will spawn after the explosion
                    }
                }
            }
        }
        public override void AI()
        {
            if (projectile.velocity.Y <= -2f)
            {
                if(projectile.velocity.Y < -5f)
                {
                    projectile.velocity.Y = -5f;
                } else yGrav -= 0.075f;
            }
            else if(projectile.velocity.Y > -2f) yGrav -= 0.1f;
            projectile.velocity.Y = yGrav;
        }
    }
}