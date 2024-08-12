using System;

namespace Assets.Scripts.UI.Windows
{
    public class EndGameScreen : Window
    {
        public event Action RestartButtonClicked;

        public override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}