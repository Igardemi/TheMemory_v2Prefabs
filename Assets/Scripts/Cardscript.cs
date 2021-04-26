using System.Collections;
using UnityEngine;

public class Cardscript : MonoBehaviour
{

    public Sprite Front;
    public Sprite Back;
    public int Value;
    private SpriteRenderer carta;
    private bool FaceUp = false;
    public int Index;

    public GameObject gm;


    public void Awake()
    {
        carta = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("Manager");
        //carta.sprite = Back;

    }
    public void Toggle()
    {
        //if (FaceUp == false)
        //{
        //    carta.sprite = Front;
        //    FaceUp = true;
        //}
        //else if (FaceUp == true)
        //{
        //    carta.sprite = Back;
        //    FaceUp = false;
        //}

        StartCoroutine("Espera");

    }

    IEnumerator Espera()
    {
        if (FaceUp == false)
        {
            carta.sprite = Front;
            FaceUp = true;
        }
        else if (FaceUp == true)
        {
            yield return new WaitForSeconds(1f);
            carta.sprite = Back;
            FaceUp = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Has clickado en una carta.");
        gm.GetComponent<GameManager>().MoveState(Index);

    }
}
