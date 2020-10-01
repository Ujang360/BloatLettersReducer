using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SolverKind
{
    TwoByTwo,
    StopOnChange,
    Progressive,
}

public interface IBloatLettersSolver
{
    void InitializeLetters(ref List<GameObject> letters);
    bool HasBloat();
    IEnumerator SolveNext(Func<IEnumerator, Coroutine> coroutineStarter);
}
