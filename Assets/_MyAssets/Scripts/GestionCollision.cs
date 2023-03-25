using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    private GestionJeu _gestionjeu;
    private bool _touche;
    private void Start()
    {
        _gestionjeu = FindObjectOfType<GestionJeu>();
        _touche = false;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_touche)
            {
                GetComponent<MeshRenderer>().material.color = Color.black;
                _gestionjeu.AugmenterPointage();
                _touche = true;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
