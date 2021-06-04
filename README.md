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

  _Login to get authentication token_

* **URL**

  /api/user/login

* **Method:**
  
  `POST`
  
*  
   **Body Params:**
 
   `{
        "username" : "username",    
        "password" : "password123"
    }`

* **Success Response:**
  
  
  * **Code:** 200 <br />
    **Content:** `{
    "user": {
        "id": 40,
        "username": "cristina.mariano",
        "email": "cristina.mariano@gmail.com"
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjQwIiwiRW1haWwiOiJjcmlzdGluYS5tYXJpYW5vQGdtYWlsLmNvbSIsIlVzZXJuYW1lIjoiY3Jpc3RpbmEubWFyaWFubyIsIm5iZiI6MTYyMjgzMjk3OCwiZXhwIjoxNjIyODQwMTc4LCJpYXQiOjE2MjI4MzI5Nzh9.S0BAKpdbC8Dvt6cEaII9_Yy3zpR4xpxBJhA03vmsTqU"
}`



**Exchange Transactions**
----
  _Make an exchange transaction_

* **URL**

  /api/transaction

* **Method:**
  
  `POST`
  
*  
   **Header:**
 
   `Authorization : "Bearer {TOKEN}"`

    **Body Params:**
 
   `{
        "SourceCurrency": "EUR",
        "SourceAmount" : 100.50,
        "TargetCurrency": "BRL"
    }`

* **Success Response:**
  
  
  * **Code:** 200 <br />
    **Content:** `{
    "isSuccess": true,
    "message": "Call was Successful!",
    "content": {
        "userId": 40,
        "sourceAmount": 100.50,
        "sourceCurrency": "EUR",
        "targetAmount": 616.72,
        "targetCurrency": "BRL",
        "tax": 6.14,
        "id": 9,
        "createdDate": "2021-06-04T18:59:51.51"
    }
}`
 
  _Get my transactions_

* **URL**

  /api/transaction/getmytransactions

* **Method:**
  
  `GET`

     **Header:**
 
   `Authorization : "Bearer {TOKEN}"`


* **Success Response:**
  
  
  * **Code:** 200 <br />
    **Content:** `{
    "isSuccess": true,
    "message": "Call was Successful!",
    "content": [
        {
            "userId": 40,
            "sourceAmount": 900.50,
            "sourceCurrency": "EUR",
            "targetAmount": 5540.73,
            "targetCurrency": "BRL",
            "tax": 6.15,
            "id": 8,
            "createdDate": "2021-06-04T08:44:15.687"
        },
        {
            "userId": 40,
            "sourceAmount": 100.50,
            "sourceCurrency": "EUR",
            "targetAmount": 616.72,
            "targetCurrency": "BRL",
            "tax": 6.14,
            "id": 9,
            "createdDate": "2021-06-04T18:59:51.51"
        }
    ]
}`







