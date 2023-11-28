namespace PersistenceTests;

public partial record GenerationValuesRecord()
{
    
    
    
    
    public const string MAIN_MENU_ASCII_ART1 =
            @"@@@@**@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*******@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@**@@@
@********/@@@@@@@@@@@@@@@@*****************************@@@@@@@@@@@@@@@@*********
*************@@@@@@@@***************************************@@@@@@@@************
@*******************************************************************************
@*******************************************************************************
@%*****************************************************************************@
@@****************************************************************************/@
@@@/*************************************************************************&@@
@@@@@***********************************************************************@@@@
@@@@************************************************************************(@@@
@@@***************************************************************************@@
@@****************************************************************************/@
@%*****************************************************************************@
@*******************************************************************************
@*************%%%%%%%%%%%%*****************************%%%%%%%%%%%%*************
***************%%%%%%%%%%%%%%%%/*****************(%%%%%%%%%%%%%%%%**************
************************%%%%%%%%%%%***********%%%%%%%%%%#***********************
***********************%%%%%%%%%%%%%*********%%%%%%%%%%%%%**********************
@**********************%%%%%%%%%%%*************%%%%%%%%%%%**********************
@**********************%%%%%%%%%%#*************%%%%%%%%%%%**********************
@@**********************%%%%%%%%%***************%%%%%%%%%**********************@
@@************************%%%%#*******************%%%%%***********************/@
@@@***************************************************************************@@
@@@@***************%%%*************************************%%#**************(@@@
@@@@@@***************%%%%%#***************************%%%%%%***************@@@@@
@@@@@@@****************%%%%%%%%%%%*************%%%%%%%%%%%***************/@@@@@@
@@@@@@@@@*****************%%%%%%%%%%%%%%%%%%%%%%%%%%%%%*****************@@@@@@@@
@@@@@@@@@@@*******************%%%%%%%%%%%%%%%%%%%%%******************#@@@@@@@@@@
@@@@@@@@@@@@@@*****************************************************@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@***********************************************@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@***************************************@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@/***************************%@@@@@@@@@@@@@@@@@@@@@@@@@
";

    public const string MAIN_MENU_ASCII_ART2 =
        @"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@///%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@/////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@/////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@///////////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@////////////////@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@///////////########@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@////////////###########@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@//######//##############@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@/#########################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@###########################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@#############################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@###############################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@#################################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@###################################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@#######################################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@#############################################@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@##################################################@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@(####################################################@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@######################################################@@@@@@@@@
@@@@@@@@@@@@@@@@@@@######################################################@@@@@@@
@@@@@@@@@@@@@@@@@@@@@#####################################################@@@@@@
@@@@@@@@@@@@@@@@@@@@@@#####################################################@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@%###################################################@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@#################################################@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###############################################@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@############################################@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#########################################@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#####################################@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@################################@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#########################@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#########&@@@@@@@@@@@@@@@@@
";

    public const string MAIN_MENU_ASCII_ART3 =
     @"                            ...:;88@@X@X@X@XSXSSXS%SXt%.  888t@ S%SXSSXX8X8X%S  X X:@.% 8. @. :.      ::.;;tt%t%%XSSSSSXXS@@XXXX88t.            ..    
 .  . .  . .  . . ...   .. ...:t888@@8X8@X@SSSS@XXXXS::.X.888:@S:@ @t@t8X@8S8 8S%8S@X@88.8t   .: . ..:.:;tt%tX@X8XSS8@SXX@88SXX@@88t:..........   ....
  ..   . .  .. .%888t.      ..;8888@@@8SXXSSSXXX@SS%;t: @8%8X8%8St@SS;@;SS%8 @ @X.XSS888..8;.: .  .;:..;S%SSSXXXX@@XSSXXXX8S@SXX8XX88:...... . .. . . 
       .     ..8%@@X;@..   . :8888@88XXX888888@S@X%%S: 888.888@8@X XS% X.XX.@ 8.@X%@888;88 8t :::..;tt;tS@SSSXSX8@SS@S8XSXSXX8SXX8S8XS;........    ...
     ..  ....:@;@@8@%8;.  . .S8@8@@88XX8X@X8XXXS%XS;tt. tt888.888XX;X%X;@ XS 8%@S@888t8 8 ;888..;.:%%XSXt%S@@@8XSSSS88SSS8SSSS88888X8XX:....... ..... 
   .  .:S@X8SStXX@8X;t%%. ..S88@@8S8S888X@8XSSXXS%%t%..88..::8.88@88@@X@;@%X8X@88888.8:8:888:; .t88XS8S8@XSSS@SSXSSXSSX@@XXXS8S8@@X8S8X8;;;::........ 
......t;SXS;%@tSX88t%%%;t .X88@8S8X8@@88@8XXXS%S:tX@t;:;; 888; 88888888888@8@@88888:8 8888.8;;:88tS@S%XSX@S8XXXXSSSSXSXSXXXSSX8888@X@8@88;;;:::...... 
.:;::;;SS88S;;;X%XXSX@SS;8@8888X88@S8X8SXSSSSSXSSS8@St%tt:.:.:88t.8t:888t888888.88;8:88888 ..:SXSXX@@XSXX@@SSXSSXXSXSSS88888X888888888888%t;;;;::.....
.;;;;%t@@88SS:.:St%X%SSS@8tX%@88X8X8@8S888XSXXSSSXXStS%St%8S;;.8:;%88;: 8t 8t:8888888:8;.. 888%@8S8SSXXXS@XSXSSX@SXXXSS88S@X88@8@@@@8@8888tttt;;;;:::.
.:;;;%%@@888t8:.@XS:8SXX88:8;88X8XXSX8888@X@@S%%XXXSSS@%8%Stt88%SX%::..:%:.;.8t888:%ttSt;%888X@8S%XSSSSX@SSXXSSXXXXXX8@SSSX@SX8@X8888SXSS8@;t%%%%tt;::
 ::t%XSS%S%@8@%XSX%X%SX8@%8;;8@88StSt:%8X8XXX@@SXS@XSXXX88%S%@88%SXX88888;:888888t.;%XS%@8%X@S@@@@@SX@@XS@@XXXSXX@X888X@8@@8X@8888@X@@X@@t@;t%X%Xtt;;:
 ::tt8SSX8XX8@@8X@XS%8@X%S::@X8@%XS@XX::X@88XSS@SXSXSXXX@SS%8@8XX@8XS8@88@8%:;SSXS8S@XX@%X@SSXS@8@SSXXXX@@@@XXX@88888@SXXS@SX@888888X%X;t;%@%S;t%%%tt;
 :;tS8%Xt8%8%t;8X888S8X8tX:.:S@tX@8t.@%%:8%8XS88X%SSSSSX@S@S%XXSS@XX@X@@@X@SX8@S8@@X8XX@XXSXXX@@@S8S@SSSX@X@X@@8@8@8X888XSXX888X88XXXS:;t:;Xtt@tSX;t%t
.:;S88XS%XS8S888t88@X888;t;;t;;;:;8%.SSS;t88@@XSXXS%XSX@@XXX8@XS@XXS%XSXSXSXSSX@X@@@@8X@@@S@@@X8@@S@XXXX@@@@8@888@8SX@8@@X@XX@@8X88@%%tt;.:SStXtX;t%S;
.;t8%8X888888%X%888@8%888;:::;:;:;8X::XS;.88X@@SXSX@SXXXXXX@8XX8@S@XXXXSXXX8888888@8888888888@8@8@X@X@X88X8@@X888@@8X8SXX8X88888888%SS:;...;XStXt%%ttt
.;8S8888t@8X;X;;S@@888SX......::.:X%;:t8S;@SX8XXSXXXXSXSX@@XXX@888@@X@88@88@X88888888888@@@888888@8@8@88X@@@@8S8@@XXX@8@@@@@888888@@tt;:...St@%%@tS;tt
.tS@X@88@@X@@8SX8@S8@X%8;.. .....:St;:;SS8t8@888@@@@8SS88@@@@X8@888@88@88@888X8888@888X8@%888888X@X8X8@8@@88X@88S8X8X8X88888888X88S@X;;:...SXt@%SSt%%t
.:8%8@8:t8%XStt8;S@888%X%;..   ..:::..;X8;t8@XX8@8@88888@8X888@@8@88888888888X88%@X@S@8@S8@88888888@X8888888888@8@@@8888X8X@@88@S8XX@tt;...SX@%XS@tS%%
.:;%@8t%8%t%SStXt8@88@Xt:XX:....::..:;tS;;S88@88X8S8888X8@8X8X8@8888@S8X8S@S8SXX888S8@S@8XXS8X8888@@8S88%88@88X8X@8X8888X@S8@@@@S8@t%tt:..:@XXXtSS%%Xt
.:;;;:t:8;XS8XSX8t8@S8:..;8ttt;;;...:;S;:;8888X@88SX8@88@8@88888888S@XXXXX8XX8%@@@@8@SXtt@@@@8@8@@@@@XSX888X@@X8@SXX%SSXS@@@X%@%8@X%tt;:. .XXXSXt%X;tX
 .::;:tt%@88@%8XX@X@S;...:XStt;;:.::tt;:t88888@88X88@888888888888888@@@X@XXXX@@%8@tXt@t@@tSX@8@@XX8%8@@XSXSXtXttt%tStXtSXSXXXX@S%@;tt;;:. .;8X%XtS%Xt8
 .:::::SS8888t8%;;@@88;:...t%%t;:::t;;:S8888888888@@8888@88@88888S@@S%SXtXt8XSX@XXX@8X88@8@@t%Xt@%%Sttttt;::;:;;:;;:;;tttttXttttttt;;;:.  ..;@X%SXt%X@
 ....:.tt8@X8;:;t%@8888:...:;%t;;;::..;88X88@8X8888888888888S@X@@XSSS@X@X%@%%%%XSSSX@@8@@XXX@Xt%%Stt;;::::::.:::::.:;;tt%%tt%S;ttt;;::... ..;@SXtX%Xt@
 .......;XXt;::t%@88888X....::::::::.:tXSX@@SX@8888888@@X88S88@%@@8@XtXStXSX@Xt%8@@888@SX%@tttt%;;;:::::.......::::;;;tttt;t;;:;;;::..     :Xt@SSS%%Xt
 .......:::;::tS%8888888@tt:::;ttt::;tXtX%X%8X%@8%X@@@X8@X@8@@8@XXtt%St%%t;;;t@%SXXt@;%X;t;;;::;:..:......  .:.::::::;;:;;::::.::.....    :XX@XXXX@XXX
 .........:::;;;X88888@888Xt%StStXt@SXSX%XS%@Xtt%%X%S%Xt@%XX@@8X%@XtXtt%S;tt%%%X;tXt;t;;:::........  .. .  ....:::;;:::.:::......... ..  :@88888888XX@
 ........:::::;;X@888@8X8888@@8@888XXS@@@@@@t@@St%ttStt%St@@@@%@@%X%Xtt%tt;;;;;;;;;t;t;:..........    .   ..:::.::::::::::::...... .    :@888888888888
;;:.....:.:::.::S@88@@@8@8@8888888888888%@@XXtXSXtSt;;t%tS;tX@@tX%@t%SX;:;::::::;.::::....... .  . .. .  ......:::::::;;::::..         .@8@8X88@8@@88@
S%t;:....:.....:t@88888X88888@8888@88888@88888t@XXt%ttttt;%%X;S@@%%@%S::;;:...:.:.......  .   .  ..  . .......:::;;;;tttt;....  .. . ..S8@888S8@X8X88@
X@Xt;::..:.....:%X@X88@8@@@88@8@8@8@88X88888888@@XtSXt%t;t%t;;tt%%%%t;:;;:.......... .  .   ..        ....:.:.:;;;t;;ttt;:..  ..      ;8@S8@@SX8S8S88@
XXXStt;:::......;tX@888888@@8888@@@8X8@88888888888@X;;;ttt;:;;t;;t:;;::......  . .    .....    ..   ......::::tttttttt;;;:....       .S8S@@@88XSX88S@8
8XXXStt::.......:;tXX88@8X8888X8888@@8@8@X888888888@Xt%%t;::::::::.:......   ..     :8;::X8:.     .  ......:;%S;%t%tt;;:....     ..   :8@@SX@@XX88888S
888SSt%;:........:;;S@S888888@888888888888@8X88888@XXXXttt;::::::.......  ..     .tX @%.tX@8X::.    .  ...:;tttXtS;t;t::...   ...     .:8SS@X8SS88@88@
88888@Xtt;:t%@S...:::%@S@8888@8888888888888@88X8@%XXt%%S%;;:.:......    .       ;@t%S8Xtt;;;:;;:..     ...:;%%;;ttt;;:.. .  .    . .  ..;X@X@X@@@S@X8@
88888@@@@@@8888%:...;t%8@X8X8@8@888888888888S@@%Sttt%XtStt;::.....  .. ..      ;XS8: ..:::.......  .   ...::t;t;%t;;::...  .  . ..   .  .8XSX@XSXSXXX@
@@XX88888888X@@8%;..:;ttXt@@88@@88@88SXS@SSX%S;%%S;%t;;:;;:::... .    .     ..:8@@t:. ...... ..  .  .  ...::;:;;;;;:...    . ..    .    :S@XXX8XSXSXX@
XXXXXXX@@@@SXX@88@t.:.::;tXtXt%X%X8t@S@%t%%tt;;t;;:;::::::::...    ..    .  ..t8@8;.  . .    .    .....  ...::::::...   ..       . .   ;X;%@XXX@SSSS88
XX@X888XXX888XX8@X@%;....:.;tSt%@Xt@%XtX;%tt;;;:.::::........    .    . .  ...t@88:;;.  .   .     .:::.............  ..     .  .      ;%%StXSSSX888S88
XXSXX8XX@@X888@8SSSS@.  ....::;ttXStXt%%StS;;;;::.:........  .. .   . .   . ..;tX;;8S.    .     ..:;t;;.. .  . .   .   . ... . . .   ;SX%SS%SS@XS@X@XS
SSXSXSX8888@8XXXSS88X8;:  ...:;tt;tXt@t@;tt%tt;::.......  .   .   ..   .     .;;;:.t;... .   .....;SS%%;::...           .        ..X@SSSS%@XSXSXS@@888
X8SSX8SX@888@XX8@S@SSSS8;.....:;t%ttS%St%X;Xt;;;;:::....   .   ..   .   .  . ..:......     .:.. .:t8XXtt;::.  ..  . ..  . . . .   .8t%%SXSS8@@SXSSXXXS
tS88SSXX@88@XX@@@S%XS%@X8t:....;ttSXttSS;t%t%tS;;;;:....    .  . .. .. .  .  .... ...     .....  :t%%S@tt;.. .   .    ..  ..  .    :@;%XSXXS8XS8XXXSS@
tSS@8S8SSSSSXXX@@XXX%SSS%XX:....:;;tttttSt%t%%ttt;t;;:....   .     .  . ..   .     . .:X;..    ..:t@SXttt;....  .  .     .  .      .8;XSSS@XS8S@SXSSXS
t%XSX@S@8@88SS8X8@8XXS@S%XS@@;...:.:;t;;t%%tt;;t;t;;;::.... .  . . .  .   . .      .::8%S8:.. ..:;t;;ttt;;:.  ...  .  ..  . . ..   .8tS%S%SXS%8XSS@SSX
;%XStXS%SSX@8X@8@X8XSXXXXSS@X8;.. ..:;tt;tt%ttt;;;;;;:::::.....          ...  ..   .;@X.  8.   .:;tt%%t;;:.. ..     ..   . .    .  .S;%SStXXXXX@XXSSXS
t%@X@StXS%X8@SSSX@XXSS@XXXXXS%X@;....:;;;;;tt;;;;;;;;:::::.....     . . .   .       .:8S%S8;.  ..:;;;:::..     .  ..    .  ..   . .8;:;;%%XX%@XSS%XSXS
:%tX;t;:;tSSt%t%@XSXX@8@XX@SXXSSX8%:..:::;;;::::::::;:::::::::......   . . . ..  .. .. . :.S..........:...  ..  .     .   .  ..   ::.::;%@SXXSXSSXSXSX
;:;;t. .:::t;;:;S%t%8X@@88X8X8SXXSX8;:...::::;:::::::;;;:::::......       . .  ..         .;;... ...... .  .   .   . .  ..        :tt:;%8XSXX8S@@XXSX@
...:........  .:;tSXSX8@8X@8X@@@@8S88t;:::::::::::::::::;:::..:...  .. . . .  .  .  .. .  ....    .. .   . . .. . .    .  .  ..   SSSSSSX%8@S%@SX@SSSS
:::. .;88;;.t: . .t%S@88X8888X88888@@@8t;:::;;::::::::;:;:::::...      .  .. .. . .      ..... ..  .  ...  .  .  . .  . .   .   .8%SSXX@@XStSSS@XXX8X8
 . ..888X.8.8 8 8t.tS8XS8888X88888888888@t;::;;;::::::::::::......  ..  ..  .  .. .  ..    ..   . . ..   .. .  ..  ..    . .    8;tSSX@XSSt%SSSS8@@SXX
 . 888;:88888888;.;;%XSSSXXX8888S8X88888@@Stt;;;;;:;:::::;:....... .        ..  .  ..  . . .  .. .. .  .. .  ..  . .   . .    .8.::S8S@XX@S;tt%SSSSSX@
  888;888.8888:888;:;tXXXXX@S88888XXXX@X@XS%S%%t;;:;::::::.....      .   ..   .. .  . . ..  .. .  .  .. .  . . ..   . .    . .S    .:tXXXS%%%::;t@@SX@
..t8888888888888888;:;S88@S8XX@8888@X%XS@tXXXt@;tt;;:::::....    ..  . .    .. .  .. .  . ..  .  .  . .  . .    . .      .  .S 888   :tXSX%%S%ttSS88XS
 8888888888888888 888;%XS@@XXX@8888%@S%%t@tXS%t@%ttt::..:...    .      .  .   .  . .  ..  .  .. .. . .  .. . ... .  .. .   .8 8 8 S.8ttXS%SSt%XS%@XSSS
 8.8888.888888888888  :SXX8@X@@@8@8@X@X%StSSt@tt%%t;:::.....   .   ..   .  .   .. .  .  .. .. .  .  . ..  .  .  .  .   .   8  8 8;.8S .:;X@XXSXSS%SSSS
X.8 888888888:88888888;;S@X88@888888@%8XSXt%SXt%Stt;;:..:...      .   . ..  .. .   .. .. .  .  .. .. .  .  .. . . .   .   @:  .:;:tt %  :;;SSXXXSX@8XS
";
}


// DateTime startDate = new DateTime(2021, 8, 4); // Start date
// DateTime endDate = new DateTime(2023, 12, 16); // End date
// static DateTime GenerateRandomDateTime(DateTime start, DateTime end)
// {
//     Random random = new Random();
//     int range = (end - start).Days;
//     return start.AddDays(random.Next(range)).AddHours(random.Next(24)).AddMinutes(random.Next(60)).AddSeconds(random.Next(60));
// }
//
// Location location1 = new Location(1, "Home", 40.7128, -74.0060, "123 Main St, New York");
// Location location2 = new Location(2, "Office", 34.0522, -118.2437, "456 Elm St, Los Angeles");
// Location location3 = new Location(3, "Park", 51.5074, -0.1278, "789 Oak St, London");
// Location location4 = new Location(4, "Mall", 48.8566, 2.3522, "101 Rue de Rivoli, Paris");
// Location location5 = new Location(5, "Gym", -33.8688, 151.2093, "200 George St, Sydney");
// Location location6 = new Location(6, "School", 37.7749, -122.4194, "789 Market St, San Francisco");
// Location location7 = new Location(7, "Hospital", 35.6895, 139.6917, "123 Shibuya St, Tokyo");
// Location location8 = new Location(8, "Library", 55.7558, 37.6176, "456 Red Square, Moscow");
// Location location9 = new Location(9, "Cafe", -22.9068, -43.1729, "101 Copacabana Beach, Rio de Janeiro");
// Location location10 = new Location(10, "Theater", 52.5200, 13.4050, "200 Brandenburg Gate, Berlin");
// Location location11 = new Location(11, "Stadium", 37.7749, -122.4194, "123 Stadium St, San Francisco");
// Location location12 = new Location(12, "Airport", 40.6413, -73.7781, "789 Airport Ave, New York");
// Location location13 = new Location(13, "Beach", -33.8688, 151.2093, "456 Beach Blvd, Sydney");
// Location location14 = new Location(14, "Museum", 51.5074, -0.1278, "101 Museum St, London");
// Location location15 = new Location(15, "Zoo", 48.8566, 2.3522, "200 Zoo Ave, Paris");
// Sensor sensor1 = new Sensor(1, "SN123", "ThermoPro", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor2 = new Sensor(2, "SN456", "EcoSense", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor3 = new Sensor(3, "SN789", "HeatMaster", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor4 = new Sensor(4, "SN101", "TempGuard", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor5 = new Sensor(5, "SN202", "ChillMate", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor6 = new Sensor(6, "SN303", "FrostAlert", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor7 = new Sensor(7, "SN404", "SwiftSense", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor8 = new Sensor(8, "SN505", "Polaris", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor9 = new Sensor(9, "SN606", "ArcticWatch", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor10 = new Sensor(10, "SN707", "FreezeGuard", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor11 = new Sensor(11, "SN808", "SensorX", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor12 = new Sensor(12, "SN909", "SensorY", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor13 = new Sensor(13, "SN1010", "SensorZ", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor14 = new Sensor(14, "SN1111", "SensorA", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor15 = new Sensor(15, "SN1212", "SensorB", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor16 = new Sensor(16, "SN1313", "SensorC", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor17 = new Sensor(17, "SN1414", "SensorD", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor18 = new Sensor(18, "SN1515", "SensorE", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor19 = new Sensor(19, "SN1616", "SensorF", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor20 = new Sensor(20, "SN1717", "SensorG", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor21 = new Sensor(21, "SN1818", "SensorH", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor22 = new Sensor(22, "SN1919", "SensorI", GenerateRandomDateTime(startDate,endDate));
// Sensor sensor23 = new Sensor(23, "SN2020", "SensorJ", GenerateRandomDateTime(startDate,endDate));
//
// repository.AddLocations(location1,location2,location3,location4,location5,location6,location7,location8,location9,location10,location11,location12,location13,location14,location15);
// repository.AddSensors(sensor1,sensor2,sensor3,sensor4,sensor5,sensor6,sensor7,sensor8,sensor9,sensor10,sensor11,sensor12,sensor13,sensor14,sensor15,sensor16,sensor17,sensor18,sensor19,sensor20,sensor21,sensor22,sensor23);
// repository.LinkSensorToLocation(sensor16,location8);
// repository.LinkSensorToLocation(sensor11,location1);
// repository.LinkSensorToLocation(sensor7,location2);
// repository.LinkSensorToLocation(sensor4,location9);
// repository.LinkSensorToLocation(sensor18,location11);
// repository.LinkSensorToLocation(sensor17,location13);
// repository.LinkSensorToLocation(sensor8,location10);
// repository.LinkSensorToLocation(sensor22,location12);
// repository.LinkSensorToLocation(sensor1,location6);
// repository.LinkSensorToLocation(sensor10,location4);
// repository.LinkSensorToLocation(sensor21,location3);
// repository.LinkSensorToLocation(sensor14,location5);
// repository.LinkSensorToLocation(sensor2,location15);

// class ConsoleGUI
// {
//     private int locationCounter = 0;
//     private int sensorCounter = 0;
//
//     public void Run()
//     {
//         while (true)
//         {
//             Console.Clear();
//             Console.WriteLine($"Location Counter: {locationCounter}");
//             Console.WriteLine($"Sensor Counter: {sensorCounter}");
//             Thread.Sleep(7000);
//         }
//     }
//
//     public void UpdateLocationCounter()
//     {
//         Interlocked.Increment(ref locationCounter);
//     }
//
//     public void UpdateSensorCounter()
//     {
//         Interlocked.Increment(ref sensorCounter);
//     }
// }