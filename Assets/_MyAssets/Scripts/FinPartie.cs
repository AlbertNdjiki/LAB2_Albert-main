using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****

    private bool _finPartie = false;  // boolÈen qui dÈtermine si la partie est terminÈe
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** MÈthode privÈes  *****

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // rÈcupËre sur la scËne le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // rÈcupËre sur la scËne le gameObject de type Player
    }

    /*
     * MÈthode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas terminÈe
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du matÈriel ‡ vert
            _finPartie = true; // met le boolÈen ‡ vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // RÈcupËre l'index de la scËne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1))  // Si nous somme sur la derniËre scËne
            {
                int accrochages = _gestionJeu.GetPointage();  // RÈcupËre le pointage total dans gestion jeu
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1
                float _tempsNiveau2 = Time.time - _gestionJeu.GetTempsNiv1(); // Calcul le temps pour le niveau 2
                int _accrochagesNiveau2 = _gestionJeu.GetPointage() - _gestionJeu.GetAccrochagesNiv1(); // Calcul le nombre d'accrochages pour le niveau 2
                float tempsTotalniv2 = _tempsNiveau2 + _accrochagesNiveau2; // Calcul le temps total pour le niveau 2

                // Affichage des rÈsultats finaux dans la console
                Debug.Log("Fin de partie !!!!!!!");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accrochÈ au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");
                Debug.Log("Le temps pour le niveau 2 est de : " + _tempsNiveau2.ToString("f2") + " secondes");
                Debug.Log("Vous avez accrochÈ au niveau 2 : " + _accrochagesNiveau2 + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");
                Debug.Log("Le temps total pour les deux niveau est de : " + (tempsTotalniv1 + tempsTotalniv2).ToString("f2") + " secondes");

                _player.finPartieJoueur();  // Appeler la mÈthode publique dans Player pour dÈsactiver le joueur
            }
            else
            {
                // Appelle la mÈthode publique dans gestion jeu pour conserver les informations du niveau 1
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
                // Charge la scËne suivante
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
