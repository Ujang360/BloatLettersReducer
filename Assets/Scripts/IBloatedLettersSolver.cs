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

public interface IBloatedLettersSolver
{
    void InitializeLetters(ref List<GameObject> letters);
    bool IsBloated();
    IEnumerator SolveNext(Func<IEnumerator, Coroutine> coroutineStarter);
}
