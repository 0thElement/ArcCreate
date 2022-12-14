using System.Collections.Generic;
using ArcCreate.Compose.Components;
using ArcCreate.Gameplay;
using ArcCreate.Utility.Extension;
using ArcCreate.Utility.Parser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ArcCreate.Compose.Project
{
    public class ChartInformationUI : ChartMetadataUI
    {
        [SerializeField] private GameplayData gameplayData;
        [SerializeField] private TMP_InputField title;
        [SerializeField] private TMP_InputField composer;
        [SerializeField] private TMP_InputField illustrator;
        [SerializeField] private TMP_InputField charter;
        [SerializeField] private TMP_InputField baseBpm;
        [SerializeField] private Toggle syncBaseBpm;
        [SerializeField] private TMP_InputField chartConstant;
        [SerializeField] private TMP_InputField difficultyName;
        [SerializeField] private ColorInputField difficultyColor;
        [SerializeField] private List<Button> diffColorPresets;

        protected override void ApplyChartSettings(ChartSettings chart)
        {
            title.text = chart.Title ?? "";
            composer.text = chart.Composer ?? "";
            illustrator.text = chart.Illustrator ?? "";
            charter.text = chart.Charter ?? "";
            baseBpm.text = chart.BaseBpm.ToString();
            syncBaseBpm.isOn = chart.SyncBaseBpm;
            chartConstant.text = chart.ChartConstant.ToString();
            difficultyName.text = chart.Difficulty ?? "";

            chart.DifficultyColor.ConvertHexToColor(out Color c);
            difficultyColor.SetValue(c);

            gameplayData.Title.Value = chart.Title ?? "";
            gameplayData.Composer.Value = chart.Composer ?? "";
            gameplayData.Illustrator.Value = chart.Illustrator ?? "";
            gameplayData.Charter.Value = chart.Charter ?? "";
            gameplayData.BaseBpm.Value = chart.BaseBpm;
            gameplayData.DifficultyName.Value = chart.Difficulty ?? "";
            gameplayData.DifficultyColor.Value = c;
        }

        private new void Start()
        {
            base.Start();
            title.onEndEdit.AddListener(OnTitle);
            composer.onEndEdit.AddListener(OnComposer);
            illustrator.onEndEdit.AddListener(OnIllustrator);
            charter.onEndEdit.AddListener(OnCharter);
            baseBpm.onEndEdit.AddListener(OnBaseBpm);
            syncBaseBpm.onValueChanged.AddListener(OnSyncBaseBPM);
            chartConstant.onEndEdit.AddListener(OnChartConstant);
            difficultyName.onEndEdit.AddListener(OnDifficultyName);
            difficultyColor.OnValueChange += OnDifficultyColor;

            for (int i = 0; i < diffColorPresets.Count; i++)
            {
                Button btn = diffColorPresets[i];
                btn.onClick.AddListener(() =>
                {
                    OnDiffColorPreset(btn);
                });
            }
        }

        private void OnDestroy()
        {
            title.onEndEdit.RemoveListener(OnTitle);
            composer.onEndEdit.RemoveListener(OnComposer);
            illustrator.onEndEdit.RemoveListener(OnIllustrator);
            charter.onEndEdit.RemoveListener(OnCharter);
            baseBpm.onEndEdit.RemoveListener(OnBaseBpm);
            chartConstant.onEndEdit.RemoveListener(OnChartConstant);
            difficultyName.onEndEdit.RemoveListener(OnDifficultyName);
            difficultyColor.OnValueChange -= OnDifficultyColor;

            for (int i = 0; i < diffColorPresets.Count; i++)
            {
                Button btn = diffColorPresets[i];
                btn.onClick.RemoveAllListeners();
            }
        }

        private void OnTitle(string value)
        {
            Target.Title = value;
            gameplayData.Title.Value = value;
        }

        private void OnComposer(string value)
        {
            Target.Composer = value;
            gameplayData.Composer.Value = value;
        }

        private void OnIllustrator(string value)
        {
            Target.Illustrator = value;
            gameplayData.Illustrator.Value = value;
        }

        private void OnCharter(string value)
        {
            Target.Charter = value;
            gameplayData.Charter.Value = value;
        }

        private void OnBaseBpm(string value)
        {
            if (Evaluator.TryFloat(value, out float bpm))
            {
                Target.BaseBpm = bpm;
                gameplayData.BaseBpm.Value = bpm;
            }
        }

        private void OnSyncBaseBPM(bool value)
        {
            Target.SyncBaseBpm = value;
        }

        private void OnChartConstant(string value)
        {
            if (Evaluator.TryFloat(value, out float cc))
            {
                Target.ChartConstant = cc;
            }
        }

        private void OnDifficultyName(string value)
        {
            Target.Difficulty = value;
            gameplayData.DifficultyName.Value = value;
        }

        private void OnDifficultyColor(Color color)
        {
            Target.DifficultyColor = color.ConvertToHexCode();
            gameplayData.DifficultyColor.Value = color;
        }

        private void OnDiffColorPreset(Button button)
        {
            int index = 0;
            for (int i = 0; i < diffColorPresets.Count; i++)
            {
                if (diffColorPresets[i] == button)
                {
                    index = i;
                    break;
                }
            }

            Color c = Services.Project.DefaultDifficultyColors[index];
            OnDifficultyColor(c);
            difficultyColor.SetValueWithoutNotify(c);
        }
    }
}