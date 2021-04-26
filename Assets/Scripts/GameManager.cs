using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject[] baraja = new GameObject[10];

    public int[] CardsUp = new int[2];
    public string State = "Inicial";

    public Sprite[] Cartas = new Sprite[5];
    public GameObject Marcador;
    public GameObject PrefabCard;
    int parejas = 0;

    public void Start()
    {

        Marcador.GetComponent<Text>().text = "Parejas " + parejas;

        for (int i = 0; i < 10; i++)
        {
            PrefabCard.name = "PrefabCard" + i;
            PrefabCard.GetComponent<Cardscript>().Index = i;

            if (i < 5)
            {
                PrefabCard.GetComponent<Cardscript>().Value = i;
                PrefabCard.GetComponent<Cardscript>().Front = Cartas[i];
                Instantiate(PrefabCard, new Vector3(i - (8 - 3 * i), 2, 0), Quaternion.identity);
            }
            else
            {

                PrefabCard.GetComponent<Cardscript>().Value = i - 5;
                PrefabCard.GetComponent<Cardscript>().Front = Cartas[i - 5];
                Instantiate(PrefabCard, new Vector3((i - 5) - (8 - 3 * (i - 5)), -1, 0), Quaternion.identity);
            }

            
        }

        baraja = GameObject.FindGameObjectsWithTag("Card");

        CardsUp[0] = -1;
        CardsUp[1] = -1;

    }


    public void MoveState(int index)
    {
        GameObject Card1;
        GameObject Card2;

        if (State == "Inicial")
        {
            baraja[index].GetComponent<Cardscript>().Toggle();
            CardsUp[0] = index;
            State = "carta_descubierta";
        }
        else if (State=="carta_descubierta" && CardsUp[0] != index)
        {
            baraja[index].GetComponent<Cardscript>().Toggle();

            CardsUp[1] = index;

            Card1 = baraja[CardsUp[0]];
            Card2 = baraja[CardsUp[1]];

            

            if ((Card1.GetComponent<Cardscript>().Value) == (Card2.GetComponent<Cardscript>().Value))
            {
                Debug.Log("Las cartas son pareja.");
                parejas++;
                Marcador.GetComponent<Text>().text = "Parejas " + parejas;

                //Desactivar las cartas
                baraja[CardsUp[0]].gameObject.SetActive(false);
                baraja[CardsUp[1]].gameObject.SetActive(false);

                State = "Inicial";
                

                if (parejas == 5)
                {
                    Marcador.GetComponent<Text>().text = "Fin del Juego";
                }
                else
                {
                    Marcador.GetComponent<Text>().text = "Parejas " + parejas;
                }
            }
            //NO ACIERTO
            else
            {

                //baraja[CardsUp[1]].GetComponent<Cardscript>().Toggle();
                
                baraja[CardsUp[0]].GetComponent<Cardscript>().Toggle();
                baraja[CardsUp[1]].GetComponent<Cardscript>().Toggle();
               

                State = "Inicial";
                //Dar la vuelta a las cartas.

            }
        }
    }
}



