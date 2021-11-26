using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static int blueTowers;
    public static int yellowTowers;

    public TextMeshProUGUI message;
    public TextMeshProUGUI result;

    private void Start()
    {
        message.text = blueTowers == yellowTowers ?
            "Empate" : blueTowers > yellowTowers ?
            "Felicidades" :
            "Mejor suerte a la próxima";
        result.text = blueTowers == yellowTowers ?
            "El tiempo se acabó" : blueTowers > yellowTowers ?
            "El equipo azul ha ganado" :
            "El equipo amarillo ha ganado";
    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
