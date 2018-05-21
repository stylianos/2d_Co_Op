using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                if ( this.tag == "Player_1")
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump_P1");
                }
                if (this.tag == "Player_2")
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump_P2");
                }
            }

            if ( CrossPlatformInputManager.GetButtonDown("Fire_P1") )
            {

            }

            if (CrossPlatformInputManager.GetButtonDown("Fire_P1"))
            {

            }
        }


        private void FixedUpdate()
        {
            float h = 0;
            bool player_exists = false; 
            if (this.tag == "Player_1")
            {
           
                h = CrossPlatformInputManager.GetAxis("Horizontal_P1");
                player_exists = true;
            }

            if (this.tag == "Player_2")
            {
                
                h = CrossPlatformInputManager.GetAxis("Horizontal_P2");
                player_exists = true;   
            }
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            // Pass all parameters to the character control script.
            if (player_exists)
            {
                m_Character.Move(h, crouch, m_Jump);
            }
            
            m_Jump = false;
            // Read the inputs.

        }
    }
}
