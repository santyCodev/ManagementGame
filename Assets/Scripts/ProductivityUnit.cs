using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurentPile = null;
    public float ProductivityMultiplyer = 2;

    /**
        Lo que sucede cuando la unidad de productividad esta
        dentro del rango de una pila de recursos

        Queremos que la velocidad de produccion aumente durante 
        el marco cuando la unidad de productividad se encuentre
        dentro del alcance de la pila de recursos

        Se tiene que evitar que el codigo se ejecute en los 
        siguiente fotogramas o de lo contrario la velocidad
        de produccion seguira aumentando
    */
    protected override void BuildingInRange()
    {
        if(m_CurentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_CurentPile = pile;
                m_CurentPile.ProductionSpeed *= ProductivityMultiplyer;
            }
        }
    }

    private void ResetProductivity()
    {
        if(m_CurentPile != null)
        {
            m_CurentPile.ProductionSpeed /= ProductivityMultiplyer;
            m_CurentPile = null;        
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        //run method from base class
        base.GoTo(target);
    }
}
