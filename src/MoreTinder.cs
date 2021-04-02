using Vintagestory.API.Common;

[assembly: ModInfo("More Tinder", "moretinder", Version = "2.0.0", Authors = new string[] { "JapanHasRice", "goxmeor", "BotenRedWolf" },
        Website = "https://github.com/JapanHasRice/VSMod-MoreTinder", Description = "More ways to start a firepit!... sort of", RequiredOnClient = true)]

namespace MoreTinder {
  public class MoreTinder : ModSystem {
    public override void Start(ICoreAPI api) {
      base.Start(api);
      api.RegisterItemClass("ItemDryGrassMoreTinder", typeof(ItemDryGrassMoreTinder));
    }
  }
}
