# TPLinkControl-Console
Accessing TP-Link Cloud services through .NET Console

*This documentation is unofficial ⚠️*

## Step 1 - Getting Logged In

Login URL: https://wap.tplinkcloud.com

To access the API, a user is required to login with a POST request to the main site containing the user’s Username and Password. A UUID is also required, basically stating that you are a unique terminal accessing this service. You can generate a free one here. The json content structure is as follows.
```
{	
"method": "login",
"params": 
{	
"appType": "Kasa",
"cloudUserName": "USERNAME",
"cloudPassword": "PASSWORD",
"terminalUUID": "TERMUUID"
}}
```
## Step 2 - Viewing Devices

Secure URL: https://wap.tplinkcloud.com?token=[***TOKEN***] 

Now that the user is logged in, you will receive a token in the response body. This token only lasts around 4 hours, so petitioning for a new one is required when making a new call. 

To get a list of devices, we are going to make an adjustment to the method, changing it from login to getDeviceList. We don’t require parameters for this action, but we do need to pass the login token into the url using the format listed above. This is also a POST request. The json content structure is as follows.
```
{	
"method": "getDeviceList"
}
```

## Step 3 - Changing Bulb State (On -Off)

The response from step 2 should have provided you with a list of devices and accompanying information, you will need this. Once you decide which device you want to control, make sure to grab it’s deviceId. The method used for this event is passthrough. In the request below, we will change the state of that device by providing a 1 (On) or 0 (Off). This is also a POST request. The json content structure is as follows.
```
{
"method": "passthrough",
"params": {
"deviceId": "DEVICEID",
"requestData": { 
"smartlife.iot.smartbulb.lightingservice": { 
"transition_light_state": {
"on_off:  "ONEORZERO” 
} , 
"brightness": 100,
"hue”: 100,
"saturation": 100
}}}}
```
## Step 4 - Changing Bulb Color

Luckily for us, changing the color of the bulb is mostly the same as the step above, but dropping Brightness (aka Lightness) down to 50, and adjusting Hue for the color we desire. Common Hue colors are Red (0), Green (120), and Blue(240), with the scale spanning from 0-360. This is also a POST request. The json content structure is as follows.

```
"brightness": 50,
"hue”: 360,
"saturation": 100
```


Links: 
UUID Generator: https://www.uuidgenerator.net/
