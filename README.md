# Video-Sharing-WebSite
This Web Application Project is a video sharing platform developed with ASP.NET programming language. The main purpose of the project is to apply sentiment analysis in the comments.

## 1. Bilvideo - Video Sharing Platform

![bilvideo](https://user-images.githubusercontent.com/37222672/61372760-a7811880-a8a0-11e9-9659-06958345aed0.png)

Social Video Sharing Platform is a system where users can upload, watch and share videos. Figure 1 shows the logo of "bilvideo.com". In this study, importance was given to visuality. It is designed to be used for all users who want to make sales over the internet in a way that appeals to the eye tastes of users by concentrating on design. The system uses the C # programming language that contains the MVC pattern that is compatible with the ASP.NET Web Programming language. The main objective of the system is to provide a system where the videos to be shared include educational content so that students can watch the topics they cannot understand over and over again. In the Project, a simple system was developed considering the users. It is seen that ASP.NET applications used in the project are widely used in our country. Microsoft's software continues to be developed. This language gives us the opportunity to work with the powerful C # object oriented programming language. By using MVC (Model View Controller) layout, complexity management and reusability of the code are provided.

## 2. Database Creation

![UMLDiagrami](https://user-images.githubusercontent.com/37222672/61372291-69cfc000-a89f-11e9-80c4-13f2b94e6c37.png)

In this study, it was preferred to use MSSQL Server which works in the most compatible way with ASP.Net as the database system. Figure 2 above shows the UML Diagram of the database. There are 11 tables in total for the system. 2 of these tables are directly related to the "Member" table, 3 of them are directly related to the "Video" table, 3 of them are the common table between "Video" and "Member". In the diagram shown in Figure 2 above, 5 tables related to the "Member" of the system and the relations of these tables are given. There is an n-1 relationship between the "VideoView", "VideoLike", "CommentLike", "UComment" and "Comment" tables and the "Member" table. Here a user can have multiple video likes, views, comments, comment likes, and responses to comments. In the diagram shown in Figure 2, 6 tables related to the "Video" table of the system and their relations are given. There is a 1-n relationship between the "Content", "Member", and "Comment" tables and the "Video" table, where a video can have only one category, shared location, and user, while there can be multiple videos in one category, location, and user. There is an n-1 relationship between the "VideoLike", "VideoTag", "VideoView" and "Comment" tables and the "Video" table, where a video can have multiple likes, comments, tags, and views.

# Materiel And Method

## 1. .Net Framework

The .NET Framework is an "application" development platform developed by Microsoft based on open Internet protocols and standards. It shows significant similarities to the Java platform previously developed by Sun Microsystems.
The scope of the application concept here is very wide. Everything from a desktop application to a web browser application is considered and supported on this platform. It is possible to easily create web services for communication of these applications with each other and regardless of the environment in which they are developed. This platform is designed to be more portable than the operating system and hardware.
The .Net architecture consists of a common execution environment, a common variable type system, and dynamically linked libraries. The .Net library is a class of APIs (many functions for programmers) designed for legacy visual basic. Because the API was not classified and these reasons became a nightmare for programmers. The .Net library allows the program to work in harmony with the operating system.

## 2. Internet Information Services(IIS)
### What is IIS?
IIS, called Internet Information Services, are services used to publish Web pages, run Web applications, and set up and publish Web servers. IIS works with Microsoft Windows server-based operating systems. It meets and responds to requests from clients with protocols such as HTTP, HTTPS, FTP on servers with Microsoft Windows operating systems installed. In addition, software developers who will develop software and use Web services in the .NET environment need a Windows operating system with IIS.

## 3. MSSQL Database

In the simplest sense, the database is all records and files organized for a specific purpose. You may have collected the names and addresses of your friends or customers on your computer system. Maybe you collect all the letters you write and arrange them according to the recipient. You may also have a group of files in which you collect your financial data such as debit and balance of your accounts or checkbook for payment and collection. Word processing documents that you organize according to their subjects are, in the broadest sense, a kind of database. Spreadsheet files that you organize by use are also a separate type database. All program shortcuts on the Windows Start menu are also a database. It is a database of Internet shortcuts arranged in the Favorites folder.
If you are very organized, you can manage several hundred spreadsheets or shortcuts using folders and subfolders. When you do this, you become the database administrator. What are you going to do as the problems you're trying to solve grow? How can you easily gather information about all customers and their orders when data is stored in various documents or spreadsheets? How can you maintain links between files when you enter new information? How do you make sure the data is entered correctly? What do you do when you need to share your information with many people and don't want two people trying to update the same data at the same time? If you have experienced such difficulties, you need a database management system (DBMS).
The purpose of the databases is to process large amounts of corporate data. The data is stored in an electronic format on a regular basis. This information, which is regularly backed up and checked, is made available to a large number of applications and users. One of the most important features of databases is the ability to quickly and securely convert large amounts of data into the information needed.

## 4. ASP.NET MVC

![MVC](https://user-images.githubusercontent.com/37222672/61373255-ff6c4f00-a8a1-11e9-89ec-4dae408e5c36.png)

The Model View Controller relationship is given in Figure 3 above. ASP.Net MVC is a framework developed by Microsoft to add the MVC pattern to ASP.Net. In order to understand what ASP.Net MVC is, first of all it is useful to examine what MVC is.
MVC is one of the architectural patterns that play an important role in application development (especially web application development). Today, MVC comes to mind with the ASP.NET MVC Framework developed by Microsoft, whereas since 1979 (Microsoft was founded in 1975) it has been in the software world.
It consists of the initials of the words MVC, Model, View, Controller, and each word represents a different layer of MVC.

### Model
In the MVC world, the model is where the application data or status is stored, usually in the database or xml / json file format.
The model isolates the data layer (database, xml, json file, etc.) from the application so that there is no need to know where the data layer is on the other layers.
The model layer is often used in Entity Framework, Nhibernate, LLBLGen, and so on. It is created using such tools.
### View
View is the layer that contains the interface that the client sees, usually created using the data in the Model layer. By separating the View layer from the Model and Controller layers, interface changes can be made without changing the other layers of the application.
It is possible to use the latest version technologies such as HTML5 and CSS3 in the View layer. With HTML5 and CSS3, it is very easy to develop applications that can run on desktop and mobile browsers. You can even use HTML5 and CSS3 technologies to develop Windows Store applications.
### Controller
The controller performs tasks such as processing the request from the client and bridging the Model and View layers. There can be one or more Actions in the Controller, usually every Action is used to produce a web page. Figure 4 below gives the MVC Lifecycle.

![MVC_02](https://user-images.githubusercontent.com/37222672/61373413-6f7ad500-a8a2-11e9-853e-ad44ab630cef.png)

Another important building block of MVC is the routing mechanism.

### Routing
Routing is the structure that directs the client's request to the application to the appropriate Controller and Action. The client sends the request to a specific address of the application, and the routing mechanism determines the most appropriate Controller and Action in it for that address.

# Use Of The System
## 1. Video Interface

![A_Video](https://user-images.githubusercontent.com/37222672/61373616-fa5bcf80-a8a2-11e9-9612-f7f3eb417052.png)

It is intended to allow users to quickly find videos uploaded in the system. The most important function for the user is to reach the search and video details as soon as possible.
## 2. Video Detail View

![V_Detay](https://user-images.githubusercontent.com/37222672/61373752-4eff4a80-a8a3-11e9-9934-050bce0153f8.png)

The system is created for the user to review any video even if the user is not registered.
## 3. Registration

![A_KayitOl](https://user-images.githubusercontent.com/37222672/61373614-fa5bcf80-a8a2-11e9-8d18-4701c4aaa8c5.png)

The user must register to the system in order to upload videos and comment and appreciate the videos. It is designed for the user to register to the system in the simplest way.
## 4. Login

![A_GirisYap](https://user-images.githubusercontent.com/37222672/61373613-f9c33900-a8a2-11e9-9406-e0cacf8a26cc.png)

The user must first activate the e-mail to log in. After the account has been activated, the user has been created in order to enter the system with their information.

# Results

![S_Comment1](https://user-images.githubusercontent.com/37222672/61374401-f0d36700-a8a4-11e9-9408-77a296f29cbe.png)

We are commenting on the video we reviewed in Figure 10.

![S_Comment2](https://user-images.githubusercontent.com/37222672/61374403-f29d2a80-a8a4-11e9-8e96-c6a460f51de7.png)

We determined that the interpretation we made in Figure 11 is positive or negative.

If we evaluate the results of the project, our system allows the user to register, log in, share videos, comment and appreciate videos. Emotion analysis, which is our main goal, was also successfully accomplished.
Although there are deficiencies in our project, it can fulfill many features required for a social video sharing system. After this stage, the existing deficiencies will be focused on and the deficiencies will be covered. In the later stages of the project, the accuracy of emotion analysis will be increased.
