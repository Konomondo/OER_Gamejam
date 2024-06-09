﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;
using TMPro;

public class Function : MonoBehaviour
{
    public LineRenderer lineRenderer;
    EdgeCollider2D edge;
    public Slider rotationSlider;
    public Slider parameter1;
    public Slider parameter2;
    public TMP_Text FunctionDynamicLabel;
    public TMP_Text LabelParameter1;
    public TMP_Text LabelParameter2;

    public Projectile projectile;
    public int WeaponID = 0;

    public int numberOfPoints = 200;
    public float par1 = 0.5f;
    public float par2 = 1f;
    float startValue = -2.0f;
    float endValue = 2.0f;
    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        edge = GetComponent<EdgeCollider2D>();
        rotationSlider.minValue = -180;
        rotationSlider.maxValue = 180;

        // phase
        parameter1.minValue = -10;
        parameter1.maxValue = 10;
        // amplitude
        parameter2.minValue = -2;
        parameter2.maxValue = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    SpawnProjectile();
        //    FreezeController.current.Unfreeze();
        //}

        //angle = Math.Clamp(angle + Input.GetAxis("Mouse ScrollWheel") * 180.0f, -180.0f, 180.0f);
        par1 = Math.Clamp(par1 + Input.GetAxis("Mouse ScrollWheel") * 2, -5, 5);
    }

    public void Shoot()
    {
        FreezeController.current.Unfreeze();
        PlayerController.current.UnfreezeMovementAfterDelay();
    }

    public void SpawnProjectile()
    {
        List<Vector3> vec = GetPath(0.0f, endValue).ToList();
        Instantiate(projectile).InitializePath(vec);

        List<Vector3> vec2 = GetPath(0.0f, startValue).ToList();
        Instantiate(projectile).InitializePath(vec2);
       
    }

    private Vector3[] GetPath(float startValue, float endValue)
    {        
        float increment = (endValue - startValue) / (numberOfPoints + 1);
        float[] parameterVals = new float[numberOfPoints];
        float[] functionVals = new float[numberOfPoints];
        Vector3[] vertexPositions = new Vector3[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            float yValue = 0;
            if (WeaponID == 0)
            {
                yValue = EvalFunctionLinear(startValue + i * increment, par1, par2);
            }
            else if (WeaponID == 1)
            {
                yValue = EvalFunctionQuadratic(startValue + i * increment, par1, par2);
            }
            else if (WeaponID == 2)
            {
                yValue = EvalFunction(startValue + i * increment, par1, par2);
            }
            GetDynamicFunctionString();
            Vector3 temp_vector = new Vector3(startValue + i * increment, yValue, 0);
            vertexPositions[i] = Quaternion.AngleAxis(angle, Vector3.forward) * temp_vector + transform.parent.transform.position;
        }
        return vertexPositions;
    }

    public void Draw()
    {
        Vector3[] vertexPositions = GetPath(startValue, endValue);
        Vector3[] shiftedVertexPositions = new Vector3[vertexPositions.Length];
        
        // add shift to real coordinates
        for (int i = 0; i < numberOfPoints; i++)
        {
            shiftedVertexPositions[i] = vertexPositions[i] - transform.parent.transform.position;
        }
        DrawLine(numberOfPoints, vertexPositions);
        addCollider(shiftedVertexPositions.ToList());
    }

    void addCollider(List<Vector3> colliderPoints)
    {
        List<Vector2> colliderPoints2 = new List<Vector2>();

        for (int i = 0; i < colliderPoints.Count; i++)
        {
            colliderPoints2.Add(new Vector3(colliderPoints[i].x, colliderPoints[i].y, 0f));
        }

        for (int i = colliderPoints.Count - 1; i > 0; i--)
        {
            colliderPoints2.Add(new Vector3(colliderPoints[i].x, colliderPoints[i].y, 0f));
        }

        edge.points = colliderPoints2.ToArray();
    }

    void DrawLine(int nPoints, Vector3[] vertexPositions)
    {
        lineRenderer.positionCount = nPoints;
        lineRenderer.SetPositions(vertexPositions);
    }


    float EvalFunctionLinear(float x, float param1, float param2)
    {
        return param1 * x + param2;
    }

    float EvalFunctionQuadratic(float x, float param1, float param2)
    {
        return param1 * x * x + param2;
    }

    float EvalFunction(float x, float param1, float param2)
    {
        return param2 * (float)Math.Sin(param1 * x);
    }

    public void UpdateAngle()
    {
        angle = rotationSlider.value;
    }

    public void UpdatePar1()
    {
        par1 = parameter1.value;
    }

    public void UpdatePar2()
    {
        par2 = parameter2.value;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Name of collider: " + collision.name);
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().health.Decrement();
        }
    }

    public string GetDynamicFunctionString()
    {
        string functionString = "";
        if (WeaponID == 0)
        {
            functionString = "f(x) = " + Math.Round(par1, 2) + " * x + " + Math.Round(par2, 2);
            LabelParameter1.text = "k: " + Math.Round(par1, 2);
            LabelParameter2.text = "d: " + Math.Round(par2, 2);
        }
        else if (WeaponID == 1)
        {
            functionString = "f(x) = " + Math.Round(par1, 2) + " * x² + " + Math.Round(par2, 2);
            LabelParameter1.text = "a: " + Math.Round(par1, 2);
            LabelParameter2.text = "b: " + Math.Round(par2, 2);
        }
        else if (WeaponID == 2)
        {
            functionString = "f(x) = " + Math.Round(par1, 2) + " * sin(" + Math.Round(par2, 2) + " * x)";
            LabelParameter1.text = "a: " + Math.Round(par1, 2);
            LabelParameter2.text = "b: " + Math.Round(par2, 2);
        }
        FunctionDynamicLabel.text = functionString;
        return functionString;
    }

    public string GetFunctionString()
    {
        string functionString = "";
        if (WeaponID == 0)
        {
            functionString = "k * x + d";
        }
        else if (WeaponID == 1)
        {
            functionString = "a * x^2 + b";
        }
        else if (WeaponID == 2)
        {
            functionString = "a * sin(b * x)";
        }
        return functionString;
    }
}
