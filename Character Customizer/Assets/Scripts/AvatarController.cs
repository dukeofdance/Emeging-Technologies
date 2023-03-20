using UnityEngine;

/*
 
 Script is utilizing the code from:

 https://www.youtube.com/watch?v=RaDSUd6GSjs

 Avatar Rigging for VR: A Step-by-Step Guide (1/2)
 
 */

[System.Serializable]

public class MapTransforms 
	{
	public Transform vrTarget;
	public Transform ikTarget;

	public Vector3 trackingPositionOffset;
	public Vector3 trackingRotationOffset;

	public void VRMapping() 
		{

		ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
		ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);

		}
	}

public class AvatarController : MonoBehaviour
	{

	[SerializeField] private MapTransforms head;
	[SerializeField] private MapTransforms lefthand;
	[SerializeField] private MapTransforms rightHand;


	[SerializeField] private float turnSmoothness;
	[SerializeField] Transform IKHead;
	[SerializeField] Vector3 headBodyOffset;

	private void LateUpdate()
		{
		transform.position = IKHead.position + headBodyOffset;
		transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(IKHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

		head.VRMapping();
		lefthand.VRMapping();
		rightHand.VRMapping(); 

		}
	}
