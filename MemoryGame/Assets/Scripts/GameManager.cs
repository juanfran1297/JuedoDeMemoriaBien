using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Sprite> images;
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    //public Text matchText;
    private int numMatches;

    //public GameObject confetis;
    [SerializeField] private GameObject confeti;
    [SerializeField] private Transform posConfeti;

    private bool init = false;
    public int matches;

    public GameObject panelVictoria;

    public Animator trompetas1;
    public Animator trompetas2;

    private bool victoria;

    private Sprite[] ImagenAleatoria(List<Sprite> images)
    {
        Sprite[] random = new Sprite[images.Count];
        for (int i = 0; i < matches; i++)
        {
            int aux = Random.Range(0, images.Count);
            random[i] = images[aux];
            images.Remove(images[aux]);
        }
        return random;
    }
    private void Start()
    {
        numMatches = 0;
        //matchText.text = "Marcador: " + numMatches;
        cardFace = ImagenAleatoria(images);

        victoria = false;

        panelVictoria = GameObject.Find("PanelVictoria");
        if(panelVictoria != null)
        {
            panelVictoria.SetActive(false);
        }
        else
        {
            Debug.LogError("No se encuentra 'PanelVictoria' en la escena");
        }
    }
    private void Update()
    {
        if(!init)
        {
            InitializeCards();
        }

        if(Input.GetMouseButtonUp(0))
        {
            CheckCards();
        }

        if(victoria == true)
        {
            FindObjectOfType<Timer>().enabled = false;
        }
        else
        {
            FindObjectOfType<Timer>().enabled = true;
        }
    }

    private void InitializeCards()
    {
        for(int id = 0; id < 2; id++)
        {
            for(int i = 1; i <= matches; i++)
            {
                bool test = false;
                int choice = 0;
                while(!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().Initialized);
                }
                cards[choice].GetComponent<Card>().CardValue = i;
                cards[choice].GetComponent<Card>().Initialized = true;
            }
        }
        foreach(GameObject c in cards)
        {
            c.GetComponent<Card>().SetUpGraphics();
        }

        if(!init)
        {
            init = true;
        }
    }

    public Sprite GetCardBack()
    {
        return cardBack;
    }

    public Sprite GetCardFace(int i)
    {
        return cardFace[i - 1];
    }

    private void CheckCards()
    {
        List<int> c = new List<int>();

        for(int i = 0; i < cards.Length; i++)
        {
            if(cards[i].GetComponent<Card>().State == 1)
            {
                c.Add(i);
            }
        }

        if(c.Count == 2)
        {
            CardComparison(c);
        }
    }

    private void CardComparison(List<int> c)
    {
        Card.doNot = true;

        int x = 0;

        if(cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            x = 2;
            matches--;
            numMatches++;
            //matchText.text = "Marcador: " + numMatches;
            Image carta1 = cards[c[0]].GetComponent<Card>().image;
            carta1.color = Color.grey;

            Image carta2 = cards[c[1]].GetComponent<Card>().image;
            carta2.color = Color.grey;

            FindObjectOfType<AudioManager>().Play("Acierto");

            if (matches == 0)
            {
                confeti.transform.position = posConfeti.position;
                panelVictoria.SetActive(true);
                victoria = true;
                
                FindObjectOfType<AudioManager>().Play("Victoria");
                StartCoroutine(PararAnimacion());
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Fallo");
        }
        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().FalseCheck();
        }
    }

    IEnumerator PararAnimacion()
    {
        yield return new WaitForSeconds(4f);
        trompetas1.SetTrigger("Parar");
        trompetas2.SetTrigger("Parar");
    }
}
