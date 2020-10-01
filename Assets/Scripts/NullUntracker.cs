using System.Collections.Generic;
using UnityEngine;

public class NullUntracker : MonoBehaviour
{
    private List<GameObject> trackable;

    public void InitTrackable(ref List<GameObject> gameObjects) => trackable = gameObjects;

    public bool TryUntrack()
    {
        var pendingRemoval = new List<GameObject>();

        foreach (var letter in trackable)
        {
            if (!letter)
            {
                pendingRemoval.Add(letter);
            }
        }

        if (pendingRemoval.Count == 0)
        {
            return false;
        }

        foreach (var item in pendingRemoval)
        {
            trackable.Remove(item);
        }

        return true;
    }
}
