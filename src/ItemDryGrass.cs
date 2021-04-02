using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace MoreTinder {
    public class ItemDryGrassMoreTinder : ItemDryGrass {
        public override void OnHeldInteractStart(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling) {
            if (blockSel == null || byEntity?.World == null || !byEntity.Controls.Sneak) return;

            IWorldAccessor world = byEntity.World;
            Block firepitBlock = world.GetBlock(new AssetLocation("firepit-construct1"));
            if (firepitBlock == null) return;


            BlockPos onPos = blockSel.DidOffset ? blockSel.Position : blockSel.Position.AddCopy(blockSel.Face);

            IPlayer byPlayer = byEntity.World.PlayerByUid((byEntity as EntityPlayer)?.PlayerUID);
            if (!byEntity.World.Claims.TryAccess(byPlayer, onPos, EnumBlockAccessFlags.BuildOrBreak))
            {
                return;
            }

            

            Block block = world.BlockAccessor.GetBlock(onPos.DownCopy());
            Block atBlock = world.BlockAccessor.GetBlock(onPos);

            string useless = "";

            if (!block.CanAttachBlockAt(byEntity.World.BlockAccessor, firepitBlock, onPos.DownCopy(), BlockFacing.UP)) return;
            if (!firepitBlock.CanPlaceBlock(world, byPlayer, new BlockSelection() { Position = onPos, Face = BlockFacing.UP }, ref useless)) return;

            // Switch to a fully constructed firepit except if building a charcoal pit
            if (!block.Code.Path.Equals("firewoodpile")) {
                firepitBlock = world.GetBlock(new AssetLocation("firepit-cold"));
            }
            if (firepitBlock == null) return;
            // end of added code

            world.BlockAccessor.SetBlock(firepitBlock.BlockId, onPos);

            if (firepitBlock.Sounds != null) world.PlaySoundAt(firepitBlock.Sounds.Place, blockSel.Position.X, blockSel.Position.Y, blockSel.Position.Z, byPlayer);

            itemslot.Itemstack.StackSize--;
            handHandling = EnumHandHandling.PreventDefaultAction;
        }
    }
}
