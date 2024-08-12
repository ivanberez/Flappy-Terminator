using System;

namespace Assets.Scripts.UI.Windows
{
    public class StartGameScreen : Window
    {
        public event Action PlayButtonClicked;        

        public override void OnButtonClick()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}