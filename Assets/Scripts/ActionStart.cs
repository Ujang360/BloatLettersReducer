using UnityEngine;

public class ActionStart : MonoBehaviour
{
    [SerializeField]
    private GameObject menuSolverPrefab;

    private void StartSolver(SolverKind solverKind)
    {
        var solverMenu = Instantiate(menuSolverPrefab, transform.parent.parent);
        solverMenu.name = solverMenu.name.Replace("(Clone)", "");
        var solverAction = solverMenu.GetComponentInChildren<ActionSolve>();
        solverAction.InitializeSolver(solverKind);
        Destroy(transform.parent.gameObject);
    }

    public void StartTwoByTwo()
    {
        StartSolver(SolverKind.TwoByTwo);
    }

    public void StartStopOnChange()
    {
        StartSolver(SolverKind.StopOnChange);
    }

    public void StartProgressive()
    {
        StartSolver(SolverKind.Progressive);
    }
}
