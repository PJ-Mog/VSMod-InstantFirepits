using Vintagestory.API.Common;

[assembly: ModInfo("More Tinder", "moretinder")]

namespace MoreTinder {
  public class MoreTinder : ModSystem {
    public override void Start(ICoreAPI api) {
      base.Start(api);
      api.RegisterItemClass("ItemDryGrassMoreTinder", typeof(ItemDryGrassMoreTinder));
    }
  }
}
