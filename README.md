UDK WP7 Controller
=======================

UDK Game that receives input data from a WP7's accelerometer sensor.

## Configuration
### Visual Studio - UDKWP7Controller
At default the game project will not compile nor run, a valid UDK directory must be first specified.
* General
  * UCC Path: YourUDKDir\Binaries\Win32\UDK.exe
  * Reference Source Path: YourUDKDir\Development\Src
* Debug
  * Start Game Executable: YourUDKDir\Binaries\Win32\UDK.exe
  * optional, Load map at startup: UDKWP7_TestMap. `this map is located at UDKWP7Controller\Content\Maps\`

### UDK
Add the following line below the [UnrealEd.EditorEngine] section of DefaultEngine.ini. `located at UDK_DIR\UDKGame\Configs` 

	+EditPackages=UDKWP7Controller
