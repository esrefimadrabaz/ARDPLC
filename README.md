# ARDPLC - Context, Brief and Future
This project is still being developed as my undergraduate thesis in Electrical and Electronics Engineering. It is developed with C# using Winforms, Arduino is the chosen MCU for the project for the easiness of the compiling proccess. The software is mainly designed for use in small/prototype PLC-type operations. It also consists of a basic Structured Text to C++ translator. Antlr was used for the translation. It also consists of a simulation mode, saving loading previously drawn files aswell.


It is planned to integrate wireless code uploading to an Arduino that is connected to internet.

# ARDPLC - Main
The app opens up to this screen, it is the main window for drawing Ladder apps. 
It is divided into two parts, the left part is for workspace, current pin and Used pins panels, that show information about current drawing and chosen coil/pin.

<p align="center">
<img height=450 width=750 src="https://user-images.githubusercontent.com/49105196/158995167-08de7e29-90de-4623-80b9-8f90f91a0ace.png">
  
Each row is named as Networks and even though there is no limit for number of Networks there is only 9 columns (-1 as the first one is not usable) for coil/pin usage. Some coils and pins can only be used in specific columns. 
  
[The limit for column number can be altered easily with some minor modifications.]

Current version only supports one parallel coil/pin for each coil/pin. It is also in planned to add support for multiple parallel coils/pins.
#
The top bar at the drawing window is for coils and functions.
<p align="center">
<img height=35 width=400 src="https://user-images.githubusercontent.com/49105196/158996392-16bafac9-f639-41c0-9485-a06d6e977b7c.png">

(I won't be explaining each function here as it is planned to add help menu to each of them.)

# ARDPLC - Pin Configuration
Each pin is configured as below before the main cycle begins. Pins 0 and 1 are reserved for serial use that is going to be implemented as soon as possible.
  
<p align="center">
<img width=550 src="https://user-images.githubusercontent.com/49105196/158998293-4ca255ac-7fb4-4bea-93db-2497d0f5e24b.png">
  
[Support for Arduino Mega or ESP32 with SD card support for storing the drawn .lae files may be added in the future. SD card support wasn't added to UNO as it would have decreased the usable pins and leave us with even fewer pins.]
  
# ARDPLC - Building
The building first creates a C++ header file containing functions for each function written specifically for Arduino UNO. Then it translates the latter diagram into a C++ .ino file.(Translation from ST to C++ happens here as well.) The start function consists of pin declarations done with pin manipulation. The loop function is split into three main parts. Like in a PLC these three logical blocks are I/O Scan, program cycle and I/O writing. Each pin is read first to be used as Bool values in the program cycle. Then these bool values are used to write to outputs in I/O writing part at the end of the loop function.

Lastly the Arduino IDE builds the hex file for us and puts it in a build folder created by us in the workpath. Hex files for each example is also provided in the corresponding example folder.
  
*Building requires a Arduino IDE and the path to Arduino IDE needs to be changed located in  WindowsFormsApp -> Classes -> Listing.cs -> Build_Init method. strCmdText string should be changed with path to Arduino folder. (This is going to be modifiable in runtime from the GUI ASAP.)

  
# ARDPLC - Examples
Examples for showing basics of each function is in the examples folder, each folder also consists of a Proteus drawing or simulating the coils with LED's. 
(Missing functions such as STF and ISF will be added as soon as possible.)
  
<p align="center">
<img height=350 width=500 src="https://user-images.githubusercontent.com/49105196/158997894-55c5abf1-62d1-4b32-ab61-cb43f6fb0758.png">
<img height=350 width=500 src="https://user-images.githubusercontent.com/49105196/158997896-a0d233fa-8fbd-41d5-b550-e6d3956e9772.png">



  
