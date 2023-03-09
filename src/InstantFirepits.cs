using Vintagestory.API.Common;
using Vintagestory.API.Util;

namespace InstantFirepits {
  public class InstantFirepits : ModSystem {
    public override void Start(ICoreAPI api) {
      base.Start(api);
      api.RegisterBlockBehaviorClass("InstantFirepit", typeof(BehaviorInstantFirepit));
    }

    public override void AssetsFinalize(ICoreAPI api) {
      if (api.Side == EnumAppSide.Server) {
        AddInstantFirepitBehavior(api);
      }
    }

    public void AddInstantFirepitBehavior(ICoreAPI api) {
      var stageOneFirepitBlock = api.World.BlockAccessor.GetBlock(new AssetLocation("firepit-construct1"));
      if (stageOneFirepitBlock != null) {
        stageOneFirepitBlock.BlockBehaviors = stageOneFirepitBlock.BlockBehaviors.Append(new BehaviorInstantFirepit(stageOneFirepitBlock));
        api.Logger.Notification($"[InstantFirepits] Applied BehaviorInstantFirepit to {stageOneFirepitBlock.Code}");
      }
      else {
        api.Logger.Warning("[InstantFirepits] Could not locate firepit block. No changes made.");
      }
    }
  }
}
