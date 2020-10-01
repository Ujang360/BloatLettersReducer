using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LettersAligner))]
public class LetterReducers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> letters;
    [SerializeField]
    private IBloatLettersSolver solver;

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

    private IEnumerator SolveIt()
    {
        while (solver.HasBloat())
        {
            yield return solver.SolveNext(StartCoroutine);
            yield return new WaitForSeconds(3f);
        }
    }

    public void InitSolver(SolverKind solverKind)
    {
        switch (solverKind)
        {
            case SolverKind.TwoByTwo:
                solver = new Solver2By2();
                break;
            case SolverKind.StopOnChange:
                solver = new SolverStopOnChange();
                break;
            case SolverKind.Progressive:
                break;
            default:
                break;
        }

        solver.InitializeLetters(ref letters);
    }

    public Coroutine SolveNext() => StartCoroutine(solver.SolveNext(StartCoroutine));

    public Coroutine SolveAutomatically() => StartCoroutine(SolveIt());
}
