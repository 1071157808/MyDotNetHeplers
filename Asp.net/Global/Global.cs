Events in the Global.asax file

//The purpose of these event handlers is discussed in this section below.
Application_Init
//The Application_Init event is fired when an application initializes the first time.
Application_Start
//The Application_Start event is fired the first time when an application starts.
Session_Start
//The Session_Start event is fired the first time when a user’s session is started. This typically contains for session initialization logic code.
Application_BeginRequest
//The Application_BeginRequest event is fired each time a new request comes in.
Application_EndRequest
//The Application_EndRequest event is fired when the application terminates.
Application_AuthenticateRequest
//The Application_AuthenticateRequest event indicates that a request is ready to be authenticated. If you are using Forms Authentication, this event can be used to check for the user's roles and rights.
Application_Error
//The Application_Error event is fired when an unhandled error occurs within the application.
Session_End
//The Session_End Event is fired whenever a single user Session ends or times out.
Application_End
//The Application_End event is last event of its kind that is fired when the application ends or times out. It typically contains application cleanup logic.
Using the Global.asax file

//The following code sample shows how we can use the 
//events in the Global.asax file to store values in 
//the Application state and then retrieve them when necessary.
//The program stores an Application and a Session counter in the 
//Application state to determine the number of times the application 
//has been accessed and the number of users currently accessing the
//application.

using System;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
public class Global : HttpApplication 
{
 protected void Application_Start(Object sender, EventArgs e) 
 {
    Application["appCtr"] = 0;
    Application["noOfUsers"] = 0;
 }
 protected void Application_BeginRequest(Object sender, EventArgs e) 
 {
   Application.Lock();
   Application["appCtr"] = (int) Application["appCtr"] + 1;
   Application.UnLock(); 
 }
 
 protected void Session_Start(Object sender, EventArgs e) 
 {
  Application.Lock();
  Application["noOfUsers"] = (int) Application["noOfUsers"] + 1;
  Application.UnLock(); 
 }
 // Code for other handlers
}


After storing the values in the Application state, 
they can be retrieved using the statements given 
in the code sample below.


Response.Write("This application has been accessed "+Application["appCtr"] + " times");
Response.Write("There are "+ Application["noOfUsers"] + " users accessing this application");





