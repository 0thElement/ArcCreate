// <auto-generated> to shut up linter
using ArcCreate.Gameplay.Data;
using UnityEngine;

namespace ArcCreate.Gameplay.Skin
{
    public abstract class GamemodeNoteSkinOption : ScriptableObject, INoteSkinProvider
    {
        public string Name;
        public Material ArcTapSfxSkin;
        public Color ConnectionLineColor;
        public Mesh ArcTapMesh;
        public Mesh ArcTapSfxMesh;

        public abstract (Mesh mesh, Material material) GetArcTapSkin(ArcTap note);
        public abstract (Sprite normal, Sprite highlight) GetHoldSkin(Hold note);
        public abstract Sprite GetTapSkin(Tap note);
        public abstract Sprite GetArcCapSprite(Arc arc);
    }
}