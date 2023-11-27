using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractTile : MonoBehaviour
{
   [SerializeField]
   private LayerMask _layer;

   [SerializeField]
   private Color _color;

   [SerializeField]
   private Material _defaultMaterial;
   
   private Renderer _currentRenderer;
   private Renderer _previousRenderer;

   private void Update()
   {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out var hitInfo, 100f, _layer))
      {
         _currentRenderer = hitInfo.collider.gameObject.GetComponent<Renderer>();
         
         if (_currentRenderer != _previousRenderer || _previousRenderer == null)
         {
            TryResetHighlight();
            HighlightTile(hitInfo);
         }
      }
      else
      {
        TryResetHighlight();
      }
   }

   private void TryResetHighlight()
   {
      if (_previousRenderer != null)
      {
         _previousRenderer.material.color = _defaultMaterial.color;
      }
   }

   private void HighlightTile(RaycastHit hitInfo)
   {
      _currentRenderer.material.color = _color;
      _previousRenderer = _currentRenderer;
   }
}

