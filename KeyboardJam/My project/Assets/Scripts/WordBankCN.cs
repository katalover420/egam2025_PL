using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordBankCN : MonoBehaviour
{
  private List<string> originalWords = new List<string>()
  {
     "慈悲仁爱！","哦,观音,请听我的祈祷！", "请赐予我们丰收！","我爱你,观音！","慈悲仁爱！","我爱你！", "你是如此美丽！", "慈悲仁爱 ", "慈悲和仁慈！", "你是如此富有同情心！", "你的仁慈令人震惊！", "哦,伟大的观音！", "赐予我们健康和财富！", "仁慈战胜一切！","感谢你的仁慈！", "感谢你,伟大的观音！"


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
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }

    }


    private void ConvertToLower(List<string> list)
    {

        for (int i = 0; i < list.Count; i++)

            list[i] = list[i].ToLower();

    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }

}
