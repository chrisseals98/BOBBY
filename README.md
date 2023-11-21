# BucStop
### A Team Bobby Project
### Members:
> Isaac Camacho, Richard Cashion, Dylan Cowell, Thomas Foreman,
> Dionte Jones, Matt Justis, Jacob Klucher, Dylan Lynch, 
> Caleb Rains, Chris Seals, Kyle Wittman
#### CSCI 4350
#### Fall 2023, East Tennessee State University

### Overview:
This project is a game website made by and for ETSU students. It
is a place to put games created by ETSU students. 

### Backlog Information:
https://docs.google.com/document/d/1qtNMQAEP9aWnK6pfo39iGT0Dhm9uwL6oDHdy6B-Vy-4/edit#heading=h.mgz5ua27kudv

### Project Structure: 
To understand the project structure, familiarize yourself with the
MVC (Model View Controller) structure. When clicking on a game, 
a value will be passed to the controller, which will decide which 
game to load. This is divided between the MVC folders in the main
BucStop folder.

* Bucstop
	* Controllers
		* This folder has the controllers, which allow pages to 
			link together and pass information between them.
	* Models
		* This folder has the basis for the Game class.
	* Views
		* Games
			* This folder has the pages related to games, such as
				the index page and the default game page.
		* Home
			* This folder contains the main pages used by the site, 				
				such as the home page, admin page, and privacy page.
		* Shared 
			* This contains other important pages and/or resources 
				that aren't in the other two folders, including the
				default layout and the error page.
	* wwwroot
		* This folder contains the resources used by the project, 
			including images, the javascript games, the icons, etc.
