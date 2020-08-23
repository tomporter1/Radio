# Radio
### Description
A basic radio that offers simple controls to stream four present radio stations over the internet.

# User Guide
When the application is launched, the following screen is shown.<br/>
*When it is launched for the first time there will be four stations saved in the radio by default but these can be changed*

![Image of powered off main page](/ReadMeImages/PoweredOffMain.png) <br/>

|Button|Function|
|-|-|
|![Image of the power button](/ReadMeImages/PowerButton.png)|Turns the radio on or off|
|![Image of the volume up button](/ReadMeImages/VolUpButton.png)|Turns the volume up (max is 10)|
|![Image of the volume down button](/ReadMeImages/VolDownButton.png)|Turns the volume down|
|![Image of the mute button](/ReadMeImages/MuteButton.png)|Mutes the audio output|
|![Image of the station button](/ReadMeImages/StationButton.png)|Tunes the radio to that station|

### Modifying the saved radio stations
Change to the information that is stored by the application about the radio stations is done at the Manage Stations Window.<br/>
This window is accessed via clicking on File.<br/>
Once you are on this window the information can be edited by selecting the station that needs changing then changing the information.<br/>
![Image of the manage stations window](/ReadMeImages/ManageStationsWindow.png)

# Class Diagrams

### Radio Backend
All interactions with this project are done via the following interfaces:
1. IStreamable - a representation of a streamable radio station
2. IRadio - used by the GUI to interact with the radio functionality
3. IRadioConstructor - used for the static method to create an IRadio object

![Image of backend diagram](/ReadMeImages/BackEndClassDiagram.png)

### Radio GUI
![Image of GUI diagram](/ReadMeImages/GUIClassDiagram.png)
