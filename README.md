# IdentityAPI Menu tree challenge

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* SQL Server
* Net Core 5 SDK

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Clone the repo
   ```sh
   git clone https://github.com/rhernandez90/IdentityAPIPuzzle.git   
   ```
2. Update **appsettings.json** to upate sql connecction string and JWT Secret
   ```sh
    "ConnectionStrings": {
    "SqlConnection": "Server=.;Initial Catalog=WEBAPI01; Integrated Security=true; MultipleActiveResultSets=True;"
  },

  "AllowedHosts": "*",
  "JWT": {
    "ValidAudience": "http://localhost:4200",
    "ValidIssuer": "http://localhost:61955",
    "Secret": "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"
  }
   ```
2. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```




