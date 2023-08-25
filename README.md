# Unity's most useful tools
## Object pool

Object Pooling optimizes projects by reusing pre-instantiated GameObjects, reducing CPU burden from repetitive creation and destruction. This design pattern is crucial for top-down shooter games, like Space Shooter, with frequent bullet operations, ensuring smoother gameplay and improved performance. Efficient resource utilization and recycling mechanisms make Object Pooling an essential practice for game developers.
Download this [unitypackage](https://github.com/Behnamjef/Unity_Utils/blob/main/Object%20Pool/Object%20Pool.unitypackage) or go to [this folder](https://github.com/Behnamjef/Unity_Utils/tree/main/Object%20Pool).

https://github.com/Behnamjef/Unity_Utils/assets/14978260/9f56fbf8-d859-4367-8883-c0051f521664


## Ragdoll
Download this [unitypackage](https://github.com/Behnamjef/Unity_Utils/blob/main/Ragdoll/Ragdoll.unitypackage) or go to [this folder](https://github.com/Behnamjef/Unity_Utils/blob/main/Ragdoll/).
- Attach RagdollComponent to your character in Unity.
- Populate Ragdoll Rigidbodies and Ragdoll Colliders lists in the Inspector.
- During gameplay, call SetRagdollActive(bool active) to enable or disable ragdoll physics.

https://github.com/Behnamjef/Unity_Utils/assets/14978260/ac3732c2-d9e1-45c5-a968-e3686a920780

## Inverted Mask
This class can be used to invert a mask in Unity. To use it, simply add [this component](https://github.com/Behnamjef/Unity_Utils/blob/main/InverseMask/InverseMask.cs) to your masked object instead of the unity Image component.
[Here is a package](https://github.com/Behnamjef/Unity_Utils/blob/main/InverseMask/InverseMask.unitypackage) with a sample scene.
![InverseMask1](https://github.com/Behnamjef/Unity_Utils/assets/14978260/f602c792-1394-427f-9e3c-3e3f2cf6dc37)

## Utils
### Extension
[Extentions](https://github.com/Behnamjef/Unity_Utils/blob/main/Utils/Extensions.cs) contains extensions to make development easier.

### Dynamic Shake Animation 
[ShakeOnTrigger](https://github.com/Behnamjef/Unity_Utils/blob/main/Utils/ShakeOnTrigger.cs) is a shake animation.
How it Works:
1. Attach the ShakeOnTrigger script to your desired GameObject.
2. Set your preferred values for Shake Duration, Shake Power, and Vibrate Count in the Inspector.
3. Watch the magic happen! When another collider enters the trigger zone, the object shakes vibrantly, adding a touch of dynamism to your scene.

https://github.com/Behnamjef/Unity_Utils/assets/14978260/2634a44f-83bc-4a83-899d-251639fbe7cf



