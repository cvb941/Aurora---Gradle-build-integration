# Aurora script - Gradle build integration

## Get notified about successful/failed gradle builds on your RGB keyboard.
Stop getting distracted while waiting for your builds to finish without actually stopping distracting yourself.
You can keep on browsing your favourite cat photos while you're waiting for your build to finish.
Your keyboard notifies you with color-coded blinking when the build is finished, so that you don't forget to get back to work!

## Requirements
* [Aurora](https://github.com/antonpup/Aurora "Aurora GitHub Repository") - Utility that unifies RGB lighting devices

## Installation
This repository contains two files (**AuroraNotify.gradle**, **GradleBuildsScript.cs**). 

**Setting this script up requires some steps upfront!**

1. Make sure you have Aurora installed and set-up.
2. Clone this repository into Aurora's desktop script folder, which should be: `C:\Users\Johny\AppData\Roaming\Aurora\Profiles\desktop\Scripts`
3. Open **AuroraNotify.gradle** and change the auroraPath variable to your Aurora folder.

    ```
    //CHANGE THIS TO YOUR AURORA PATH
    public const string auroraPath = "C:\\Users\\Johny\\Folder\\Aurora\\";
    ```
4. Open **GradleBuildsScript.cs** and do the same - change the auroraPath variable to your Aurora folder.

    ```
    //CHANGE THIS TO YOUR AURORA PATH
    String auroraPath = "C:\\Users\\Johny\\Folder\\Aurora\\"
    ```
5. Include the following line in your project's **build.gradle** file.
    **Replace the path with the path to your AuroraNotify.gradle**

    ```
    //Aurora script
    if (file('C:\\Users\\Johny\\AppData\\Roaming\\Aurora\\Profiles\\desktop\\Scripts\\AuroraNotify.gradle').exists())
        apply from: 'C:\\Users\\Johny\\AppData\\Roaming\\Aurora\\Profiles\\desktop\\Scripts\\AuroraNotify.gradle'
    ```
6. Restart Aurora, go to your desktop profile and enable "Gradle Builds" in the scripts window, in the bottom right corner.

That's it! Your keyboard should now blink with green color every time a successful gradle build happens. If it fails, it blinks red.

## Customization
You can change the following properties:
* Successful build blink color
* Failed build blink color
* Blink duration
* Blink interval
* Optional secondary blink color instead of black = LED off

These properties can be changed in **GradleBuildsScript.cs** inside the **SETTINGS** comment block.
After saving the file, Aurora needs to be **restarted** in order to apply these changes.