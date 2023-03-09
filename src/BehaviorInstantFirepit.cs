using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace InstantFirepits {
  public class BehaviorInstantFirepit : BlockBehavior {
    public BehaviorInstantFirepit(Block block) : base(block) { }

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling) {
      if (world.BlockAccessor.GetBlock(blockPos.DownCopy()) is BlockGroundStorage) {
        return;
      }

      int completedFirepitBlockId = world.GetBlock(new AssetLocation("firepit-cold"))?.Id ?? 0;
      if (completedFirepitBlockId != 0) {
        world.BlockAccessor.SetBlock(completedFirepitBlockId, blockPos);
      }
    }
  }
}
