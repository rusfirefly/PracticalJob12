using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class InvisibleMaterial : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _curentValueAlpha;
    [Header("Время появления/растворения объекта в мс")]
    [SerializeField] private int _animationDissolutionSpeed;
    [SerializeField] private bool _isVisible;
  
    private Renderer _render;
    private Shader _shader;
    private float _min = 0f;
    private float _max = 1f;
    private float _speed = 0.05f;
    private MeshCollider _collider;

    private void Start()
    {
        _render = GetComponent<Renderer>();
        _collider = GetComponent<MeshCollider>();
        _shader = _render.material.shader;

        AnimationDissolution(_curentValueAlpha);
    }

    public void SetVisible()
    {
        _isVisible=!_isVisible;
        ShowInvivsibleObjects();
    }

    private async void ShowInvivsibleObjects()
    {
        while (true)
        {
            if (_isVisible)
            {
                if (_curentValueAlpha >= _max)
                {
                    _collider.enabled = true;
                    return;
                }

                _curentValueAlpha += _speed;
            }
            else
            {
                if (_curentValueAlpha <= _min)
                {
                    _collider.enabled = false;
                    return;
                }

                _curentValueAlpha -= _speed;
            }

            AnimationDissolution(_curentValueAlpha);
            await Task.Delay(_animationDissolutionSpeed);
        }

    }
    private void AnimationDissolution(float value)
    {
        _render.material.SetFloat("_Edge", value);
    }

}
