<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/leonfgama/JayaTech-LeonTest">
    <img src="https://jaya.tech/images/logo-white.png" alt="Logo" width="80" height="80">
  </a>

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you use this application

### Usage

This is an example of how to list things you need to use the software and how to install them.
* Postman - <a href="https://www.postman.com/downloads/" target="_blank">Download Postman</a>
* Copy this link to import Postman Collection - <a href="#" target="_blank">https://www.getpostman.com/collections/adb2b793eb180608607b</a>
* Enjoy ;)

### API Documentation

**Authentication**
----
  _Create an account to gain access to our services_

* **URL**

  /api/user/createAccount

* **Method:**
  
  <_The request type_>

  `POST`
  
*  
   **Body Params:**
 
   `{
        "username" : "username",
        "email" : "email@email",
        "fullname" : "Your Fullname",
        "password" : "password123"
    }`

* **Success Response:**
  
  
  * **Code:** 200 <br />
    **Content:** `{
    "isSuccess": true,
    "message": "Call was Successful!",
    "content": {
        "username": "username",
        "email": "email@email",
        "fullname": "password123"
    }
}`
 
* **Error Response:**

  If you fill something wrong in the form, the API will return the status 400 (Bad Request) informing which field was not filled in correctly.

  * **Code:** 400 BAD REQUEST <br />
    **Content:** `{
    "Email": [
        "The Email field is not a valid e-mail address."
    ]
}`