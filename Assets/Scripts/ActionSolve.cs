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

    private GameObject problemGameobject;

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
    }

    public void DoStepSolving()
    {
    }

    public void DoAutoSolving()
    {
    }

    public void DoExitToMenu()
    {
        var startMenu = Instantiate(menuActionPrefab, transform.parent.parent);
        startMenu.name = startMenu.name.Replace("(Clone)", "");
        Destroy(problemGameobject);
        Destroy(transform.parent.gameObject);
    }
}
