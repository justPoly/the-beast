using UnityEngine;
using System.Collections;

public class ButtonPop : MonoBehaviour
{
    [Range(0.25f, 5f)]
    public float scaleSpeed = 0.6f;
    public AnimationCurve animationCurve;
    private Transform _transform;
    private float step;
    private float objScale;

    public void Start()
    {
        _transform = this.transform;
    }

    void Update()
    {
        step += scaleSpeed * Time.deltaTime;
        objScale = animationCurve.Evaluate(step);
        _transform.localScale = new Vector2(objScale, objScale);

        if (step >= 1)
        {
            step = 0;
        }
    }
}
