using UnityEngine;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        Rect Start = new Rect(Screen.width / 2 - 3 * buttonWidth / 2,
            (2 * Screen.height / 3) - (buttonHeight / 2) ,
              buttonWidth,
              buttonHeight);
        Rect Creator = new Rect(Screen.width / 2 + buttonWidth / 2,
            (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight);
        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
             Start,
            "Start!")
        )
        {
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("Map");
        }

        if (
          GUI.Button(
             Creator,
            "Create!")
        )
        {
            // Sur le clic, on démarre le premier niveau
            // "Stage1" est le nom de la première scène que nous avons créés.
            Application.LoadLevel("Create");
        }

    }
}
