using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public GameObject Panel;
    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; // R?cup?re l'index de la sc?ne en cours
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        
        if(Panel !=null)
        {
            Panel.SetActive(true);
        }
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

}
