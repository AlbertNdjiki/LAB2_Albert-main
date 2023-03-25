using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs
    [SerializeField] private float _vitesse = 10f;
    private Rigidbody _rb;

    // Methodes privees
    private void Start()
    {
        // position initiale du joueur
        this.transform.position = new Vector3(44.9f, 0.72f, -45.2f);
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {

    }
    private void Update()
    {
        MouvementsJoueur();
    }

    private void MouvementsJoueur()
    {
        float positionY = Input.GetAxis("Horizontal");
        float positionX = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionY, 0f, positionX);
        //transform.Translate(direction * Time.deltaTime * _vitesse);
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

    public void finPartieJoueur()
    {
        this.gameObject.SetActive(false);
    }

}