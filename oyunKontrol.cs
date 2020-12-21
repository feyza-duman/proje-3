using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunKontrol : MonoBehaviour {

    public GameObject GokyuzuBir;
    public GameObject Gokyuzuİki;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikİki;

    public GameObject engel;
    public int kacAdetEngel;
    GameObject[] engeller;
    float degisimZamani = 0;
   

    int sayac = 0;
    void Start () {
        fizikBir = GokyuzuBir.GetComponent<Rigidbody2D>();
        fizikİki = Gokyuzuİki.GetComponent<Rigidbody2D>();


        fizikBir.velocity = new Vector2(-1.5f,0);
        fizikİki.velocity = new Vector2(-1.5f, 0);

        
        engeller = new GameObject[kacAdetEngel];

        for (int i =0;i<engeller.Length;i++)
        {

            engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(-1.5f,0);


        }

    }
	
	
	void Update () {

        

        degisimZamani += Time.deltaTime;
        if (degisimZamani>2f)
        {
            degisimZamani = 0;
            float Yeksenim = Random.Range(-9f,0.4f);
            engeller[sayac].transform.position = new Vector3(18, Yeksenim);
            sayac++;
            if (sayac>=engeller.Length)
            {
                sayac = 0;
            }



        }



	}
}
