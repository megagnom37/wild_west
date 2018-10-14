# Wild West
A game for Android platforms about shooting in the Wild West

## Configuration Plan
* The latest version of the source code can be taken from the master branch.
* Specific build versions are tagged with the RELEASE_xx_xxx tag, where the first two digits indicate the version number, and the last three digits
* Build:
  - Clone repository
  - Launch the Unity3d development environment
  - If necessary, install the SDK, NDK, JDK tool packages
  - Go to File -> Build Settings ... Select the Android platform. Click the Build button. Build will begin
  - Result: a compiled * .apk file that can be tested on a real device or emulator
*  For testers, you need to collect the product version in a * .apk file and transfer it for testing. The development team can send the file to the testing team testers. If necessary, testers can assemble the necessary version of the product manually using the Unity3d environment. For the build version will match the tag number. The team of testers has the ability to test directly in Unity3d without assembly (no need to download tool packages, emulators or have a physical device)
* The user's machine requires an installed version of Android not lower than 5.0. To deploy the product, you need to download the * .apk file to the device and run it. Installation is automatic.
* In order to find out the version of the installed product:
  - You need to go to the device in Settings -> Apps -> "App name"
  - Need to go to the application in the About
* Testing with debug information output is available only when testing in the Unity3d development environment in the Console window.


