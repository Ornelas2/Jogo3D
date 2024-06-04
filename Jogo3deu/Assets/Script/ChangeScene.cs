using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void Quitgame()
    {
        Application.Quit();
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Demo");
    }

    public void Controlos()
    {
        SceneManager.LoadScene("Controlos");
    }
        
    public void Definições()
    {
        SceneManager.LoadScene("Definições");
    }

    public void Créditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void Voltar()
    {
        Debug.Log("Botão Voltar clicado!");
        SceneManager.LoadScene("menu");
    }
}

