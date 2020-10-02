using System;
using System.Collections;
using UnityEngine;

public class SolverProgressive : Solver, IBloatLettersSolver
{
    public SolverProgressive() : base()
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

        var lastChange = string.Empty;
        var loopCounter = 0;

        do
        {
            var firstLetter = string.IsNullOrEmpty(lastChange) ? GetLetter(letters, loopCounter) : lastChange;
            var secondLetter = GetLetter(letters, loopCounter + 1);
            var stringRepresentation = firstLetter + secondLetter;

            if (solverLookupTable.ContainsKey(stringRepresentation))
            {
                lastChange = solverLookupTable[stringRepresentation];
                DoReduce(letters, loopCounter, lastChange);
                yield return new WaitForSeconds(0.5f);
                continue;
            }

            lastChange = string.Empty;
            loopCounter++;
        } while (loopCounter + 1 < letters.Count);

        yield return new WaitForSeconds(0.1f);
    }
}

