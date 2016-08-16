
General Information

The first step in the SiteConnect process is for you to build a room list endpoint to connect to our Retrieve Rooms API; this will ensure SiteConnect can access rooms and rate plans on your site for testing purposes. This step must be completed before any further progress is made with the SiteConnect integration. The required information is located in the above SiteConnect link but we have provided a direct link to the specific information that will assist with building to our SOAP message structure and Retrieve Rooms API:
https://siteminder.atlassian.net/wiki/display/SITECONNECT/SOAP+Message+Structure
https://siteminder.atlassian.net/wiki/display/SITECONNECT/Retrieve+Rooms+API
It is extremely important that this is built first so we can progress with setting up a test account and test hotel for you to start development.
We recommend you download SoapUI if you want to test sending messages to your service. That way you can post an identical SOAP request as the one we're sending and check the SOAP and HTTP logs to troubleshoot.
Note: Please input your username, password and HotelCode in the OTA_HotelAvailRQ xml and push to your API for testing, once you are confident with the result let us know these details so we can complete our testing.
Here is the information required to access the Test SiteConnect web service:
Web Service = https://smtpi.siteminder.com/siteconnect/services
WSDL URL = https://smtpi.siteminder.com/siteconnect/services/siteconnect.wsdl
 
Note:
There are a number of known issues that will arise when using proxy generators from the .NET framework (such as wsdl.exe or svcutil.exe) with the OTA spec.
An alternative url https://smtpi.siteminder.com/siteconnect/services/siteconnect_inlined.wsdl is recommended for use for .NET clients.




Our Credentials are

Requestor ID: EVG
Username: EvasionVoyage
Password: 4ez7ak4zQ5srEeq






