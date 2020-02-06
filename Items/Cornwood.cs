using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items
{
	public class Cornwood : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cornwood"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This sword is corny!");
		}

		public override void SetDefaults() 
		{
            System.Random rnd = new System.Random();
            int dice = rnd.Next(1, 7);   // creates a number between 1 and 6

            item.damage = 4;
			item.melee = true;
			item.width = 48;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            //System.Random rnd = new System.Random();
            //int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
            //item.scale = dice;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 10);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}