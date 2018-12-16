using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IPointerUpHandler{
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;

	private void Start(){
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();
	}

	void Update() {
		if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
            	Vector2 pos = touch.position - (Vector2)(bgImg.rectTransform.position);
                //Debug.Log("touch.position" + touch.position);
                //Debug.Log("bgImg" + bgImg.rectTransform.position);
				{
					pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
					pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
					inputVector = new Vector3(pos.x, 0, pos.y);
					inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized:inputVector;
					
					//Move Joystick IMG
					joystickImg.rectTransform.anchoredPosition = 
						new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
									,inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
				}
            }
        }
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal(){
		if (inputVector.x != 0){
			return inputVector.x;
		}
		else{
			return Input.GetAxis("Horizontal");
		}
	}

	public float Vertical(){
		if (inputVector.z != 0){
			return inputVector.z;
		}
		else{
			return Input.GetAxis("Vertical");
		}
	}
}
