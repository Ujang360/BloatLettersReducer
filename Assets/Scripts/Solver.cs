using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Solver
{
    protected List<GameObject> letters;
    protected readonly Dictionary<string, string> solverLookupTable;

    public Solver()
    {
        solverLookupTable = new Dictionary<string, string>
        {
            { "AB", "C" },
            { "BA", "C" },
            { "AC", "B" },
            { "CA", "B" },
            { "BC", "A" },
            { "CB", "A" }
        };
    }

    protected string GetLetter(List<GameObject> letterGameObjects, int index) => letterGameObjects[index].GetComponent<TMP_Text>().text;

    protected void SetLetter(List<GameObject> letterGameObjects, int index, string newLetter) => letterGameObjects[index].GetComponent<TMP_Text>().SetText(newLetter);

    protected void DestroyLetter(List<GameObject> letterGameObjects, int index) => Object.Destroy(letterGameObjects[index]);

    protected string GetStringRepresentation(List<GameObject> letterGameObjects, int startIndex = 0, int count = -1)
    {
        if (count == -1)
        {
            count = letterGameObjects.Count;
        }

        var endIndex = startIndex + count - 1;

        if (letterGameObjects == null || letterGameObjects.Count == 0 || endIndex >= letterGameObjects.Count)
        {
            return "";
        }

        var chars = "";

        for (var i = 0; i < count; ++i)
        {
            chars += GetLetter(letterGameObjects, i + startIndex);
        }

        return chars;
    }

    protected void DoReduce(List<GameObject> letterGameObjects, int index, string newLetter)
    {
        SetLetter(letterGameObjects, index, newLetter);
        DestroyLetter(letterGameObjects, index + 1);
    }

    public virtual bool IsBloated()
    {
        var solverKeys = solverLookupTable.Keys;
        var lettersStringRepresentation = GetStringRepresentation(letters);

        foreach (var solverKey in solverKeys)
        {
            if (lettersStringRepresentation.Contains(solverKey))
            {
                return true;
            }
        }

        return false;
    }
}
