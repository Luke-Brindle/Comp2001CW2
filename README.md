# Comp2001 Assessment 2
## Micro Service Implementation

### Overview
This is a web application developed as part of COMP2001 coursework. The application allows users to log in, view active users, update their account details, preferences and favourite activities. Many features are restricted so that only the logged in user can amend details for their own account, as detailed in the project brief. Admins can perform administrative tasks if they are logged into an account with the required permissions.

### Features
Login - Users can log into any account that exists on the database. Upon successful login the user will also be informed whether or not their account is authenticated with the API.

Limited View - Users can view all other active users userID, name, about me, location and favourite activities. This allows for users to be able to see what other users are like, where they are from, without seeing all the details of their entire account such as preferences, weight etc.

Active Users Favourite Activities and Region Breakdown views - These views can be viewed by any user and simply show all active users favourite activities and locations respectively.

Unarchive Account - A logged in user with an archived account is able to unarchive their account once they have logged in. If they have been inactive for a long period of time and their account has been archived by an admin, once they log back in again they can then unarchive it and continue as a regular active user.

Create Account - Users can create a new account in the swagger interface, upon execution of which a new account with those same details will be added to the SQL server database and the user can login and complete all other functions that a logged in active user can.

New Favourite Activity - Logged in users can add new favourite activities to their account. Which are then viewable by themselves and other users in the Views that contain this information.

Delete Favourite Activity - Logged in users can remove favourite activities from their account. The changes of are then reflected to themselves and other users in the Views that contain this information.

Update Account - Logged in users are able to update their account information, such as email, height, weight, etc. These changes are then made to the users entry on the SQL Server database.

Update Preferences - Logged in users can change their Unit Preferences and Activity Time Preferences. When the user changes their unit preferences this activates a trigger that will convert the values in height and weight between metric and imperial accordingly.

## Deployed Interface
The application can be accessed at https://web.socem.plymouth.ac.uk/COMP2001/LBrindle/swagger/index.html

## Setup

1) Clone the repository
2) Install Forticlient
3) Connect to the University of Plymouth
4) Open the application inside of your development environment
5) Run the application
