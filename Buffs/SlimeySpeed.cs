using Terraria;
using Terraria.ModLoader;

namespace TestMod.Buffs
{
    public class SlimeySpeed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("SlimeySpeed");
            Description.SetDefault("35% MORE SPEED!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += .35f;

        }
    }
}
