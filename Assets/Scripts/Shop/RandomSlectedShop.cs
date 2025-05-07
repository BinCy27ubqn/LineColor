using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSlectedShop : MonoBehaviour
{
    public GameObject[] allCharacters;
    public GameObject[] showCharacters;
    public GameObject[] randomObjects;
    public GameObject[] selectObjects;
    public float rollDuration;
    private int indexCharacter;
    private bool isClickRandom = false;

    private List<int> randomlySelected;

    private void Start()
    {
        randomlySelected = new List<int>();
    }
        
    public void OnClickRandom()
    {
        if(isClickRandom == false)
        {
            isClickRandom = true;
            StartCoroutine(RandomSelect());
        }
    }

    public void ChooseCharacter(int idCharacter)
    {
        for(int i =0; i < allCharacters.Length; i++)
        {
            if(i == idCharacter)
            {
                allCharacters[idCharacter].SetActive(true);
                selectObjects[idCharacter].SetActive(true);
            }
            else
            {
                allCharacters[i].SetActive(false);
                selectObjects[i].SetActive(false);
            }
        }
    }

    private IEnumerator RandomSelect()
    {
        float timer = 0;
        int index = 0;

        while (timer < rollDuration)
        {
            index = Random.RandomRange(0, allCharacters.Length - 1);

            if (randomlySelected != null)
            {
                do
                {
                    index = Random.RandomRange(0, allCharacters.Length - 1);
                } while (randomlySelected.Contains(index));
            }
            
            randomObjects[index].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            randomObjects[index].SetActive(false);
            timer += 0.3f;
        }

        showCharacters[index].SetActive(false);

        float blinkDuration = 2f;
        float blinkTimer = 0;
        bool isOn = true;

        while(blinkTimer< blinkDuration)
        {
            isOn = !isOn;
            randomObjects[index].SetActive(isOn);
            yield return new WaitForSeconds(0.4f);
            blinkTimer += 0.4f;
        }

        indexCharacter = index;
        isClickRandom = false;

        randomlySelected.Add(indexCharacter);
    }
}
