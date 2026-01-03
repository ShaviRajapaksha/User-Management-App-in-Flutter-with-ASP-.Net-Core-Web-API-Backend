# User Management App (Flutter + ASP.NET Core Web API)

## Table of Contents

* [Project Overview](#project-overview)
* [Features](#features)
* [Technologies](#technologies)
* [Architecture](#architecture)
* [Setup & Installation](#setup--installation)

  * [Backend (ASP.NET Core Web API)](#backend-aspnet-core-web-api)
  * [Frontend (Flutter)](#frontend-flutter)
* [Usage](#usage)
* [Screenshots](#screenshots)
* [Security](#security)
* [Future Enhancements](#future-enhancements)

---

## Project Overview

This project is a **Role-Based User Management System** built using **Flutter** for the frontend and **ASP.NET Core Web API** for the backend.

It includes **user registration, login, role-based authentication, and JWT token management**, allowing different views for **Admin** and **User**.

The project also integrates **Swagger UI** for API testing and **CORS configuration** for frontend-backend communication.

---

## Features

* User registration with role selection (Admin/User)
* Login with **JWT authentication**
* Role-based navigation:

  * Admin → Admin Dashboard
  * User → User Home
* Display username dynamically on screens
* Password hashing for security
* Protected APIs with `[Authorize]` attributes
* Swagger UI for API exploration
* CORS enabled for Flutter Web or other frontend apps

---

## Technologies

**Backend:**

* ASP.NET Core 10 Web API
* Entity Framework Core (SQL Server)
* JWT Authentication
* Swagger / OpenAPI

**Frontend:**

* Flutter (Android, iOS, Web)
* jwt_decode for token parsing

**Database:**

* SQL Server

---

## Architecture

```
Flutter Frontend <---- HTTP Requests ----> ASP.NET Core Web API
       |                                      |
       |                                      |
     JWT Token <------------------------------|
       |
   Role-based Routing
(Admin / User Screens)
```

* Backend issues **JWT tokens** on login
* Token contains **username & role**
* Flutter decodes token for **username display** and **screen routing**
* APIs are **role-protected**

---

## Setup & Installation

### Backend (ASP.NET Core Web API)

1. **Clone the repo**:

```bash
git clone <repo-url>
cd UserManagement.Api
```

2. **Update `appsettings.json`** with SQL Server connection and JWT settings:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=UserManagementDb;Trusted_Connection=True;"
},
"Jwt": {
  "Key": "YOUR_SECRET_KEY",
  "Issuer": "UserManagementApi",
  "Audience": "UserManagementApi"
}
```

3. **Install NuGet packages**:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore
```

4. **Enable CORS** in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
app.UseCors("AllowFrontend");
```

5. **Run Migrations**:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

6. **Run API**:

```bash
dotnet run
```

---

### Frontend (Flutter)

1. **Install Flutter** (if not already)
2. **Install packages** in `pubspec.yaml`:

```yaml
dependencies:
  flutter:
    sdk: flutter
  http: ^1.1.0
```

3. **Run the app**:

```bash
flutter pub get
flutter run -d chrome   # for Web
flutter run -d emulator # for Android/iOS
```

4. **Update API URL** in `api_service.dart`:

```dart
static const String baseUrl = "http://localhost:5250";
```

---

## Usage

1. Open app → Go to **Register** → Enter username, password, select role → Submit
2. Go to **Login** → Enter credentials → Submit
3. App automatically navigates:

   * Admin → Admin Dashboard
   * User → User Home
4. Username is displayed dynamically on the screen
5. Logout clears JWT token and returns to Login

---

## Screenshots


## Flutter UI Screenshots
<table>
 <tr>
 <td>
<img height="500" alt="image" src="https://github.com/user-attachments/assets/381f492a-64b8-417a-9998-498ecd41df7e" />
 </td>
  <td>
<img height="500" alt="image" src="https://github.com/user-attachments/assets/6d2bbf4e-f9c2-4633-80b6-8a7e796834db" />
 </td>
<td>
<img height="500" alt="image" src="https://github.com/user-attachments/assets/bc47b7c5-b5c2-42af-bdd7-ed651943a497" />
 </td>
<td>
  <img height="500" alt="image" src="https://github.com/user-attachments/assets/dadca8a9-156b-48bc-9f0c-4787332e4513" />
 </td>  
 </tr>
</table>

## Backend Screenshots
<table>
 <tr>
 <td>
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/de0564c6-fbc4-47ac-a98a-429bdb860abc" />
 </td>
  <td>
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/e2f4a85c-1b8a-4622-88b0-0929fabc2ba1" />
 </td>
 </tr>
 <tr>
 <td>
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/d696249f-1941-49e8-96b7-fd9e94a91d08" />
 </td>
 <td>
  </td>
 </tr>
</table>



---

## Security

* JWT tokens for authentication
* Role-based `[Authorize(Roles="Admin")]` and `[Authorize(Roles="User")]` protection
* Passwords hashed using ASP.NET Identity / BCrypt
* Backend enforces security regardless of frontend manipulation

---

## Future Enhancements

* Auto-login with stored token
* Token refresh mechanism
* Admin → View all users
* Flutter profile page
* Restrict Admin creation from UI for production
* Improved Flutter UI with Material 3

---


