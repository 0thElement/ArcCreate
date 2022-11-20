// <auto-generated> to shut up linter
using ArcCreate.Gameplay.Data;
using UnityEngine;

namespace ArcCreate.Gameplay.Skin
{
    [CreateAssetMenu(fileName = "GamemodeNoteSkin", menuName = "Skin Option/NoteGamemode/Joycon")]
    public class TouchNoteSkinOption : GamemodeNoteSkinOption
    {
        public Sprite TapSkin;
        public Sprite HoldSkin;
        public Sprite HoldHighlightSkin;
        public Material ArcTapSkin;

        public override (Mesh mesh, Material material) GetArcTapSkin(ArcTap note)
            => note.Sfx == "none" ? (ArcTapMesh, ArcTapSkin) : (ArcTapSfxMesh, ArcTapSfxSkin);

        public override (Sprite normal, Sprite highlight) GetHoldSkin(Hold note)
            => (HoldSkin, HoldHighlightSkin);

        public override Sprite GetTapSkin(Tap note)
            => TapSkin;
    }
}