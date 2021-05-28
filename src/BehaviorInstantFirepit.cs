using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace InstantFirepits {
  public class BehaviorInstantFirepit : BlockBehavior {
    public BehaviorInstantFirepit(Block block) : base(block) {}

    public override void OnBlockPlaced(IWorldAccessor world, BlockPos blockPos, ref EnumHandling handling) {
      if (!world.BlockAccessor.GetBlock(blockPos.DownCopy()).Code.Path.Equals("firewoodpile")) {
        int completedFirepitBlockId = world.GetBlock(new AssetLocation("firepit-cold"))?.Id ?? 0;
        if (completedFirepitBlockId != 0) {
          world.BlockAccessor.SetBlock(completedFirepitBlockId, blockPos);
        }
      }
    }
  }
}
