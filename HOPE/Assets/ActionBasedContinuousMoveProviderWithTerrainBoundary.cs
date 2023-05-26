using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

namespace UnityEngine.XR.Interaction.Toolkit
{
    [AddComponentMenu("XR/Locomotion/Continuous Move Provider (Action-based) with Terrain Boundary", 11)]
    public class ActionBasedContinuousMoveProviderWithTerrainBoundary : ContinuousMoveProviderBase
    {
        [SerializeField]
        private InputActionProperty m_LeftHandMoveAction;

        public InputActionProperty leftHandMoveAction
        {
            get => m_LeftHandMoveAction;
            set => SetInputActionProperty(ref m_LeftHandMoveAction, value);
        }

        [SerializeField]
        private InputActionProperty m_RightHandMoveAction;

        public InputActionProperty rightHandMoveAction
        {
            get => m_RightHandMoveAction;
            set => SetInputActionProperty(ref m_RightHandMoveAction, value);
        }

        public Transform terrain; // Reference to your terrain object

        protected void OnEnable()
        {
            m_LeftHandMoveAction.EnableDirectAction();
            m_RightHandMoveAction.EnableDirectAction();
        }

        protected void OnDisable()
        {
            m_LeftHandMoveAction.DisableDirectAction();
            m_RightHandMoveAction.DisableDirectAction();
        }

        protected override Vector2 ReadInput()
        {
            Vector2 leftHandValue = m_LeftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
            Vector2 rightHandValue = m_RightHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

            Vector2 movementInput = leftHandValue + rightHandValue;

            // Perform terrain boundary constraint check
            if (terrain != null)
            {
                // Check if the movement input is zero
                if (movementInput.sqrMagnitude <= Mathf.Epsilon)
                {
                    return Vector2.zero; // Return zero movement input
                }

                Vector3 targetPosition = transform.position + new Vector3(movementInput.x, 0f, movementInput.y);

                Vector3 clampedPosition = ClampPositionToTerrainBounds(targetPosition);

                movementInput = new Vector2(clampedPosition.x - transform.position.x, clampedPosition.z - transform.position.z);
            }

            return movementInput;
        }

        private Vector3 ClampPositionToTerrainBounds(Vector3 position)
        {
            // Get the terrain bounds (adjust this based on your terrain setup)
            Vector3 terrainMin = terrain.position - terrain.localScale * 0.5f;
            Vector3 terrainMax = terrain.position + terrain.localScale * 0.5f;

            // Clamp the position within the terrain bounds
            position.x = Mathf.Clamp(position.x, terrainMin.x, terrainMax.x);
            position.z = Mathf.Clamp(position.z, terrainMin.z, terrainMax.z);

            return position;
        }

        private void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}