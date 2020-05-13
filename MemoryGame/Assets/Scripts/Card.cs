using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool doNot = false;

    [SerializeField] private int state;
    [SerializeField] private int cardValue;
    [SerializeField] private bool initialized = false;

    private Sprite cardBack;
    private Sprite cardFace;

    private GameManager gameManager;

    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        state = 1;
        GameObject aux = GameObject.Find("GameManager");
        if(aux != null)
        {
            gameManager = aux.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("No se encuentra el GameManager, asegurate de que está en la escena");
        }
    }

    public void SetUpGraphics()
    {
        cardBack = gameManager.GetCardBack();
        cardFace = gameManager.GetCardFace(cardValue);

        FlipCard();
    }

    public void FlipCard()
    {
        if (doNot)
        {
            return;
        }
        else
        {
            if (state == 0)
            {
                state = 1;
            }
            else if (state == 1)
            {
                state = 0;
            }

            if (state == 0 && !doNot)
            {
                GetComponent<Image>().sprite = cardBack;
            }
            else if (state == 1 && !doNot)
            {
                GetComponent<Image>().sprite = cardFace;
            }
        }
    }

    public void FalseCheck()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(.5f);
        if(state == 0)
        {
            GetComponent<Image>().sprite = cardBack;
        }
        else if(state == 1)
        {
            GetComponent<Image>().sprite = cardFace;
        }
        doNot = false;
    }

    #region GetSet
    public int CardValue
    {
        get { return cardValue; }
        set { cardValue = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }

    public bool Initialized
    {
        get { return initialized; }
        set { initialized = value; }
    }
    #endregion
}
