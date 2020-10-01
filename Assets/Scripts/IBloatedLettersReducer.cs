using System.Collections.Generic;
using UnityEngine;

public enum SolverKind
{
    TwoByTwo,
    StopOnChange,
    Progressive,
}

public interface IBloatedLettersReducer
{
    void InitializeLetters(ref List<GameObject> letters);
    bool TrySolveNext();
}
