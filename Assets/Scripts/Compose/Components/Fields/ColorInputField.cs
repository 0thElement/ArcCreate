using System;
using ArcCreate.Utility.Extension;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ArcCreate.Compose.Components
{
    public class ColorInputField : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TMP_Text hexText;
        [SerializeField] private Image colorPreview;
        [SerializeField] private Image colorWithAlphaPreview;
        [SerializeField] private Color currentColor;

        public event Action<Color> OnValueChange;

        public Color Value => currentColor;

        public void OnPointerDown(PointerEventData eventData)
        {
            Services.ColorPicker.OpenAt(eventData.position, currentColor);
            Services.ColorPicker.OnColorChanged = OnColorPickerChange;
        }

        private void OnColorPickerChange(Color color)
        {
            currentColor = color;
            SetColorPreview(color);
            hexText.text = currentColor.ConvertToHexCode();
            OnValueChange?.Invoke(color);
        }

        private void Awake()
        {
            hexText.text = currentColor.ConvertToHexCode();
            SetColorPreview(currentColor);
        }

        private void SetColorPreview(Color color)
        {
            colorWithAlphaPreview.color = color;
            color.a = 1;
            colorPreview.color = color;
        }
    }
}