// <auto-generated> to shut up linter
using ArcCreate.Gameplay.Data;
using UnityEngine;

namespace ArcCreate.Gameplay.Skin
{
    [CreateAssetMenu(fileName = "NoteSkin", menuName = "Skin Option/Note")]
    public class NoteSkinOption : ScriptableObject, INoteSkinProvider
    {
        public string Name;
        public GamemodeNoteSkinOption TouchSkin;
        public GamemodeNoteSkinOption JoyconSkin;

        private InputMode CurrentMode => (InputMode)Settings.InputMode.Value;

        public Sprite GetTapSkin(Tap note)
        {
            if (CurrentMode == InputMode.Controller
             || CurrentMode == InputMode.AutoController)
            {
                return JoyconSkin.GetTapSkin(note);
            }
            else
            {
                return TouchSkin.GetTapSkin(note);
            }
        }

        public (Sprite normal, Sprite highlight) GetHoldSkin(Hold note)
        {
            if (CurrentMode == InputMode.Controller
             || CurrentMode == InputMode.AutoController)
            {
                return JoyconSkin.GetHoldSkin(note);
            }
            else
            {
                return TouchSkin.GetHoldSkin(note);
            }
        }

        public (Mesh mesh, Material material) GetArcTapSkin(ArcTap note)
        {
            if (CurrentMode == InputMode.Controller
             || CurrentMode == InputMode.AutoController)
            {
                return JoyconSkin.GetArcTapSkin(note);
            }
            else
            {
                return TouchSkin.GetArcTapSkin(note);
            }
        }

        public Sprite GetArcCapSprite(Arc arc)
        {
            if (CurrentMode == InputMode.Controller
             || CurrentMode == InputMode.AutoController)
            {
                return JoyconSkin.GetArcCapSprite(arc);
            }
            else
            {
                return TouchSkin.GetArcCapSprite(arc);
            }
        }
    }
}