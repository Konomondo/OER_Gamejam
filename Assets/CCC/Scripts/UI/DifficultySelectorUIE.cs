using CCC.Utility;
using UnityEngine;
using UnityEngine.UIElements;


namespace CCC.UI
{
    public class DifficultySelectorUIE : VisualElement
    {
        private Button _increaseButton;
        private Button _decreaseButton;
        private Label _difficultyIndicator;


        // public int Difficulty { get; private set; }

        private IntReference _difficultyVar;

        public DifficultySelectorUIE()
        {
            // Difficulty = 0;
            _increaseButton = new Button() { name = "increaseDifficultyButton", text = "+" };
            _decreaseButton = new Button() { name = "decreaseDifficultyButton", text = "-" };
            _difficultyIndicator = new Label() { name = "difficultyIndicator", text = "0" };

            Add(_decreaseButton);
            Add(_difficultyIndicator);
            Add(_increaseButton);

            _increaseButton.style.width = new StyleLength(new Length(24, LengthUnit.Percent));
            _decreaseButton.style.width = new StyleLength(new Length(24, LengthUnit.Percent));

            style.flexDirection = FlexDirection.Row;

            _increaseButton.clicked += OnIncreaseDifficulty;
            _decreaseButton.clicked += OnDecreaseDifficulty;
        }

        private void OnIncreaseDifficulty()
        {
            UpdateDifficulty(_difficultyVar.Value + 1);
        }

        private void OnDecreaseDifficulty()
        {
            UpdateDifficulty(_difficultyVar.Value - 1);
        }

        private void UpdateDifficulty(int newDifficulty)
        {
            _difficultyVar.Variable.Value = Mathf.Clamp(newDifficulty, 5, 9); // TODO magic numbers for min/max values
            _difficultyIndicator.text = _difficultyVar.Value.ToString();
        }


        public new class UxmlFactory : UxmlFactory<DifficultySelectorUIE, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
        }

        public void SetScriptObjVarReference(IntReference difficultyIndicator)
        {
            _difficultyVar = difficultyIndicator;
            UpdateDifficulty(_difficultyVar.Value);
        }
    }
}