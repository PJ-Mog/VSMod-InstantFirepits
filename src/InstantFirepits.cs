using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Util;

[assembly: ModInfo("Instant Firepits", "instantfirepits")]

namespace InstantFirepits {
  public class InstantFirepits : ModSystem {
    public override void Start(ICoreAPI api) {
      base.Start(api);
      api.RegisterBlockBehaviorClass("InstantFirepit", typeof(BehaviorInstantFirepit));

      if (api.Side == EnumAppSide.Server) {
        var sapi = api as ICoreServerAPI;
        sapi.Event.ServerRunPhase(EnumServerRunPhase.ModsAndConfigReady, () => {
          var stageOneFirepitBlock = sapi.World.BlockAccessor.GetBlock(new AssetLocation("firepit-construct1"));
          if (stageOneFirepitBlock != null) {
            stageOneFirepitBlock.BlockBehaviors = stageOneFirepitBlock.BlockBehaviors.Append(new BehaviorInstantFirepit(stageOneFirepitBlock));
            sapi.Logger.Notification($"[InstantFirepits] Applied BehaviorInstantFirepit to {stageOneFirepitBlock.Code}");
          }
          else {
            sapi.Logger.Warning("[InstantFirepits] Could not locate firepit block. No changes made.");
          }
        });
      }
    }
  }
}
