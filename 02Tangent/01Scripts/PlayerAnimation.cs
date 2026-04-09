using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovementSO playerMovementSO;
    private Vector3 inputDir => playerMovementSO.InputDir;
    private Vector3 oldDir;
    private readonly int moveXHash = Animator.StringToHash("MoveX");
    private readonly int moveYHash = Animator.StringToHash("MoveY");
    private readonly int oldXHash = Animator.StringToHash("OldX");
    private readonly int oldYHash = Animator.StringToHash("OldY");
    private readonly int isMoveHash = Animator.StringToHash("isMove");
    
    private bool isMove;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        if (Time.timeScale == 0)
        {
            animator.speed = 0;
            return;
        }
        else
            animator.speed = 1;

        if (oldDir != inputDir)
            oldDir = inputDir;

        if (inputDir == Vector3.zero)
            isMove = false;
        else
        {
            animator.SetFloat(oldXHash, oldDir.x);
            animator.SetFloat(oldYHash, oldDir.y);
            isMove = true;
        }

        animator.SetFloat(moveXHash, inputDir.x);
        animator.SetFloat(moveYHash, inputDir.y);
        animator.SetBool(isMoveHash, isMove);
    }
}
