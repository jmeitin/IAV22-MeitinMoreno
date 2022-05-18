using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour //abstract si quieres que sea un template para el raycast
{
    bool jefe = false;
    [SerializeField] private GameObject explosion;

    private void Start() //no es awake dado que se tiene que crear el GM primero
    {
        GameManager.instance.AddBird();
        //NO SIGUE A OTRO PAJARO ==> ES EL JEFE
        if (!GetComponent<PajaroSeguir>()) 
            jefe = true;
    }

    public void KillBird()
    {
        GameObject g = Instantiate<GameObject>(explosion);
        g.transform.position = transform.position;

        if (!jefe)
        {
            GameManager.instance.NormalBirdDied(10, transform.position);
        }
        else
        {
            GameManager.instance.PajaroJefeDied(30);
        }
        this.gameObject.SetActive(false);
    }
}
