using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items
{
    public class ReverseBombItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ReverseBomb");
            Tooltip.SetDefault("This doesn't feel right");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 10;
            item.height = 24;
            item.maxStack = 16;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ReverseBombProj");
            item.shootSpeed = 6f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 16);
            recipe.AddIngredient(ItemID.GravitationPotion, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 16);
            recipe.AddRecipe();
        }

    }
}
