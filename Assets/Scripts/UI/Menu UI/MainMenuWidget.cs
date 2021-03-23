using UnityEngine;

namespace UI.Menus
{
    public class MainMenuWidget : MenuWidget
    {
        [SerializeField] private string StartMenuName = "Load Game Menu";
        [SerializeField] private string OptionsMenuName = "Options Menu";

        public void OpenStartMenu()
        {
            MenuController.EnableMenu(StartMenuName);

        }

        public void OpenOptionsMenu()
        {
            MenuController.EnableMenu(OptionsMenuName);

        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}

