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
        
    public void Defini��es()
    {
        SceneManager.LoadScene("Defini��es");
    }

    public void Cr�ditos()
    {
        SceneManager.LoadScene("Cr�ditos");
    }

    public void Voltar()
    {
        Debug.Log("Bot�o Voltar clicado!");
        SceneManager.LoadScene("menu");
    }
}

