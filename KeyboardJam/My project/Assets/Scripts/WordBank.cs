using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class WordBank : MonoBehaviour
{
    
    private List<string> originalWords = new List<string>()
    {
        "compassion mercy and love!", "oh goddess of mercy hear my prayer!", "please grant us a bountiful harvest!", "i love you goddess of mercy!", "compassion and kindness!", "i love you!", "you are so beautiful!", "compassion and love!", "mercy and kindess!", "you are so compassionate!", "your kindess is astounding!", "oh great goddess of mercy!", "grant us good health and wealth!", "kindess conquers all!", "thank you for your mercy!", "thank you o great goddess of mercy!"
    };
    private List<string> workingWords = new List<string>();


    private void Awake()
    {
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLower(workingWords);
        
    }

    private void Shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }

    }


    private void ConvertToLower(List<string> list)
    {

        for(int i = 0;i < list.Count;i++)
        
            list[i] = list[i].ToLower();
        
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }
   
}
