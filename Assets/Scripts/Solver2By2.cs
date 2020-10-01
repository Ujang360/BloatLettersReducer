using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Solver2By2 : Solver, IBloatLettersSolver
{
    public Solver2By2() : base()
    {
    }

    public IEnumerator SolveNext(Func<IEnumerator, Coroutine> coroutineStarter)
    {
        yield return null;

        if (letters.Count < 2)
        {
            yield break;
        }

        if (!HasBloat())
        {
            yield break;
        }

        var solverKeys = solverLookupTable.Keys;
        var clippedLetter = letters.Take((letters.Count / 2) * 2).ToList();
        var currentStepHasChange = false;

        for (var i = 0; i < clippedLetter.Count; i += 2)
        {
            var stringRepresentation = GetStringRepresentation(clippedLetter, i, 2);

            foreach (var solverKey in solverKeys)
            {
                if (stringRepresentation.Contains(solverKey))
                {
                    DoReduce(letters, i, solverLookupTable[solverKey]);
                    currentStepHasChange = true;
                    break;
                }
            }
        }

        if (letters.Count % 2 > 0 && !currentStepHasChange)
        {
            var firstLetter = GetLetter(letters, letters.Count - 2);
            var secondLetter = GetLetter(letters, letters.Count - 1);
            var word = firstLetter + secondLetter;

            foreach (var solverKey in solverKeys)
            {
                if (word.Contains(solverKey))
                {
                    DoReduce(letters, letters.Count - 2, solverLookupTable[solverKey]);
                    break;
                }
            }
        }
    }
}
