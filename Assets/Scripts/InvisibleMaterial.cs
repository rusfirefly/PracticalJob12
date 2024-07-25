using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class InvisibleMaterial : MonoBehaviour
{
    private Renderer _render;
    private Shader _shader;

    private bool _isVisible;
    private bool _isStop;
    private float _curentValueAlpha;

    private float _min = 0f;
    private float _max = 1f;

    private MeshCollider _collider;

    private void Start()
    {
        _render = GetComponent<Renderer>();
        _collider = GetComponent<MeshCollider>();

        _collider.enabled = false;

        _shader = _render.material.shader;
    
        _curentValueAlpha = 0;
        ChangeValue(_curentValueAlpha);
    }

    public void SetVisible(bool visible)
    {
        _isVisible = visible;
        ShowInvivsibleObjects();
    }

    
    private void ChangeValue(float value)
    {
        _render.material.SetFloat("_Edge", value);
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
                _curentValueAlpha += 0.05f;
            }
            else
            {
                if (_curentValueAlpha <= _min)
                {
                    _collider.enabled = false;
                    return;
                }

                _curentValueAlpha -= 0.05f;
            }

            ChangeValue(_curentValueAlpha);

            await Task.Delay(20);
        }
        
    }

}
