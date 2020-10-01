using System;
using System.Collections;
using UnityEngine;

public class SolverStopOnChange : Solver, IBloatLettersSolver
{
    public SolverStopOnChange() : base()
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

        for (var i = 0; i < letters.Count; ++i)
        {
            var stringRepresentation = GetStringRepresentation(letters, i, 2);

            if (string.IsNullOrEmpty(stringRepresentation))
            {
                yield break;
            }

            foreach (var solverKey in solverKeys)
            {
                if (stringRepresentation.Contains(solverKey))
                {
                    DoReduce(letters, i, solverLookupTable[solverKey]);
                    yield break;
                }
            }
        }
    }
}
