# Unity's most useful tools
# Installation
Download and import [this unity package](https://github.com/Behnamjef/Unity_Utils/blob/main/Utils_UnityPackage.unitypackage) into your project.

# Package Content
## Object pool
Object Pooling optimizes projects by reusing pre-instantiated GameObjects, reducing CPU burden from repetitive creation and destruction. This design pattern is crucial for top-down shooter games, like Space Shooter, with frequent bullet operations, ensuring smoother gameplay and improved performance. Efficient resource utilization and recycling mechanisms make Object Pooling an essential practice for game developers.

https://github.com/Behnamjef/Unity_Utils/assets/14978260/9f56fbf8-d859-4367-8883-c0051f521664


## Ragdoll
Download and import [this unity](https://github.com/Behnamjef/Unity_Utils) package into your project.
- Attach RagdollComponent to your character in Unity.
- Populate Ragdoll Rigidbodies and Ragdoll Colliders lists in the Inspector.
- During gameplay, call SetRagdollActive(bool active) to enable or disable ragdoll physics.

https://github.com/Behnamjef/Unity_Utils/assets/14978260/ac3732c2-d9e1-45c5-a968-e3686a920780

## Inverted Mask
This class can be used to invert a mask in Unity. To use it, simply add [this component](https://github.com/Behnamjef/Unity_Utils/blob/main/InverseMask/InverseMask.cs) to your masked object instead of the unity Image component.
![InverseMask1](https://github.com/Behnamjef/Unity_Utils/assets/14978260/f602c792-1394-427f-9e3c-3e3f2cf6dc37)

## Flying Objects in UI
This repository contains a Unity utility script for adding captivating flying coin animations to your user interface elements. The script utilizes the powerful [DoTween](https://dotween.demigiant.com/) library to create smooth and engaging animations that can enhance the visual appeal of your UI.


https://github.com/Behnamjef/Unity_Utils/assets/14978260/bef17588-328d-49f0-99d4-cc3341963d3d

## Safe area
[This Unity Safe Area script](https://github.com/Behnamjef/Unity_Utils/blob/main/SafeArea/SafeArea.cs) streamlines mobile UI development by automatically adjusting elements for notches, rounded corners, and diverse screen sizes, eliminating manual tweaks. Easily integrated, the script ensures a polished UI across devices. Elevate your Unity game development with this efficient solution.
![1](https://github.com/Behnamjef/Unity_Utils/assets/14978260/7aa2b863-db35-429d-b068-fb7294cc2dcb)

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



