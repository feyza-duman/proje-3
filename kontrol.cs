using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : MonoBehaviour {

    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true ;
    int kusSayac = 0;
    float kusAnimasyonZaman= 0;
    bool oyunBitti = true;
    Rigidbody2D fizik;
    int puan = 0;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>(); }
	void Update () {
        if (Input.GetMouseButtonDown(0)&& oyunBitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0,200));
        }
         Animasyon();
}
    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.1f)
        {
           kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            { kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                { kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
       }
    }
    private void OntriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "engel")
        {
           oyunBitti = false;    
        }
    }



}


