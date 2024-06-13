using UnityEngine;

public class PillarPushAudio : MonoBehaviour
{
   [SerializeField] private Rigidbody2D pushableRb2D;
   private bool justGotPushed = false; 
   [Header("AUDIO")]
   [SerializeField] private FMODUnity.EventReference pillarPushSfx;
  
   
   private readonly ExtendedAudioContainer pillarPushAc = new ExtendedAudioContainer();
   private const float PUSH_ABS_VELOCITY = 0.1f;
   private void Start()
   {
      pillarPushAc.InitAudio(pillarPushSfx);
      pillarPushAc.ConnectTo3DAudio(pushableRb2D.gameObject.transform, pushableRb2D);
   }
 
   private void Update()
   {
      if (IsPushableMoving())
      {
         if (!justGotPushed)
         {
            justGotPushed = true;
            pillarPushAc.StartAudio();
         }
      }
      else
      {
         if (justGotPushed)
         {
            justGotPushed = false;
            pillarPushAc.StopAudio();
         }
      }
   }

   private bool IsPushableMoving()
   {
     
      return pushableRb2D.velocity.magnitude > PUSH_ABS_VELOCITY;
   }
}
