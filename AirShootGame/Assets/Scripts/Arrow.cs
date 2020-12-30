using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Size
    {
        get
        {
            return _size;
        }
        private set
        {
            if(_size >= 0.5f)
            {
                _size = 0.49f;
                transform.localScale = new Vector3(0.2f, _size, 0);
            }
            else if(_size <= 0.2)
            {
                _size = 0.2f;
                transform.localScale = new Vector3(0.2f, _size, 0);
            }
            else _size = value;
            transform.localScale = new Vector3(0.2f, _size, 0);
            isReady = true;
        }
    }
    public float Power
    {
        get
        {
            return _power;
        }
        private set
        {
            if(_power > 11f)
            {
                _power = 10.9f;
            }
            else if(_power < 5f)
            {
                _power = 5f;
            }
            else
            {
                _power = value;
            }

        }
    }
    public Vector3 ArrowDirection
    {
        get { return transform.position; }
        set
        {
            if(value.z <= 30 && value.z >= -30)
            {
                transform.Rotate(value); // Страшные попытки ограничить вращение стрелки
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
           
        }
    }

    public Action<Vector3, float> ReadyShoot;
    public bool isReady = false;

    private float _size = 0.2f;
    private float _power = 2;

    private Quaternion _defoltCourse;
    private Vector3 course;


    [SerializeField] private Joystick _joystick;

    private void Start() {
        _defoltCourse = transform.rotation;
    }

    private void FixedUpdate() {
        //Причина использования new в Update и FixedUpdate такая, что скорее всего эта игра не будет требовательна к ресурсам
        if(_joystick.Vertical > 0.5f)
        {
            course = new Vector3(_joystick.Horizontal * -1, 0, _joystick.Vertical * -1);
            Size -= 0.005f;
            Power -= 0.5f;
        }

        if(_joystick.Vertical <= -0.5f)
        {
            course = new Vector3(_joystick.Horizontal * -1, 0, _joystick.Vertical * -1);
            Size += 0.005f;
            Power += 0.5f;
        }
    }

    void Update() {

        if(_joystick.Horizontal >= 0.3 || _joystick.Horizontal <= -0.3)
        {
            course = new Vector3(_joystick.Horizontal * -1, 0, _joystick.Vertical * -1);
            ArrowDirection = new Vector3(0, 0, _joystick.Horizontal);
        }

        if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            if(isReady)
            {
                ReadyShoot?.Invoke(course, Power);
                transform.rotation = _defoltCourse;
                Power = 5f;
                Size = 0.2f;
                isReady = false;
            }
        }
    }
}