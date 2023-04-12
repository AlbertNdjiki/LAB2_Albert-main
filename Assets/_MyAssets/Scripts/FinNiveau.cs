using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    // ***** Attributs *****

    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu

    // ***** M?thode priv?es  *****

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // r?cup?re sur la sc?ne le gameObject de type GestionJeu
    }

    /*
     * M?thode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  // Si la collision est produite avec le joueur et la partie n'est pas termin?e
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du mat?riel ? vert
            int noScene = SceneManager.GetActiveScene().buildIndex; // R?cup?re l'index de la sc?ne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 2))  // Si nous somme sur le dernier niveau de jeu
            {
                _gestionJeu.SetTempsFinal(Time.time);
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                // Appelle la m?thode publique dans gestion jeu pour conserver les informations du niveau 1
                //_gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                // Charge la sc?ne suivante
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
