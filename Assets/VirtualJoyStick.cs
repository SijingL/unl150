using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;

	private void Start(){
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();

		EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
	}

	/*void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }*/

	public virtual void OnDragDelegate(PointerEventData ped)
	{
		Vector2 pos;
		Debug.Log("Hi");
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
																	,ped.position
																	,ped.pressEventCamera
																	,out pos))
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

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDragDelegate(ped);
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
