using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LettersAligner))]
public class LetterReducers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> letters;
    
    private LettersAligner aligner;

    private void Awake()
    {
        if (letters == null)
        {
            letters = new List<GameObject>();
        }

        foreach (Transform letter in transform)
        {
            letters.Add(letter.gameObject);
        }

        aligner = GetComponent<LettersAligner>();
        aligner.InitLetters(ref letters);
    }

    private void Update()
    {
        _ = aligner.TryRepositionLetters();
    }
}
