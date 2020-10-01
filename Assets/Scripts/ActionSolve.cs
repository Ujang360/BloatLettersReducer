using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionSolve : MonoBehaviour
{
    [SerializeField]
    private GameObject menuActionPrefab;
    [SerializeField]
    private GameObject problemPrefab;
    [SerializeField]
    private Text solverKindTitle;
    [SerializeField]
    private Button buttonStepSolving;
    [SerializeField]
    private Button buttonAutoSolving;
    [SerializeField]
    private Button buttonExitToMenu;

    private GameObject problemGameobject;
    private LetterReducers letterReducers;

    private void Awake()
    {
        problemGameobject = Instantiate(problemPrefab, null);
        problemGameobject.name = problemGameobject.name.Replace("(Clone)", "");
    }

    public void InitializeSolver(SolverKind solverKind)
    {
        switch (solverKind)
        {
            case SolverKind.TwoByTwo:
                solverKindTitle.text = "Solver: 2-by-2";
                break;
            case SolverKind.StopOnChange:
                solverKindTitle.text = "Solver: Stop-On-Change";
                break;
            case SolverKind.Progressive:
                solverKindTitle.text = "Solver: Progressive";
                break;
            default:
                break;
        }

        letterReducers = problemGameobject.GetComponent<LetterReducers>();
        letterReducers.InitSolver(solverKind);
    }

    private void DisableButtons()
    {
        buttonAutoSolving.interactable = false;
        buttonStepSolving.interactable = false;
        buttonExitToMenu.interactable = false;
    }

    private void EnableButtons()
    {
        buttonAutoSolving.interactable = true;
        buttonStepSolving.interactable = true;
        buttonExitToMenu.interactable = true;
    }

    private IEnumerator StepSolvingCoroutine()
    {
        DisableButtons();
        yield return letterReducers.SolveNext();
        EnableButtons();
    }

    private IEnumerator AutoSolvingCoroutine()
    {
        DisableButtons();
        yield return letterReducers.SolveAutomatically();
        EnableButtons();
    }

    public void DoStepSolving() => StartCoroutine(StepSolvingCoroutine());

    public void DoAutoSolving() => StartCoroutine(AutoSolvingCoroutine());

    public void DoExitToMenu()
    {
        DisableButtons();
        var startMenu = Instantiate(menuActionPrefab, transform.parent.parent);
        startMenu.name = startMenu.name.Replace("(Clone)", "");
        Destroy(problemGameobject);
        Destroy(transform.parent.gameObject);
    }
}
