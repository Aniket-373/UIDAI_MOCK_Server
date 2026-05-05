* * *

# ADV eKYC Mock UIDAI Server Documentation

* * *

## 1\. Overview

Mock UIDAI Server is a lightweight service designed to simulate UIDAI APIs for development and testing of the ADV eKYC system.

It provides mock implementations for authentication, OTP verification, and KYC XML responses.

* * *

## 2\. Purpose

This server is used to:

*   Simulate UIDAI endpoints during development
    
*   Remove dependency on real UIDAI APIs
    
*   Enable end-to-end testing of the ADV system
    
*   Provide predictable and consistent test data
    

* * *

## 3\. Features

*   Simulated Authentication API
    
*   OTP generation and verification
    
*   KYC XML response generation
    
*   Predefined Aadhaar mock data
    

* * *

## 4\. Project Structure

MockUIDAI

Controllers

*   AuthController.cs
    
*   OtpController.cs
    
*   KycController.cs
    

Services

*   IKycService.cs
    
*   KycService.cs
    

Models

*   AadhaarUser.cs
    

Data

*   AadhaarMockData.cs
    

Middleware

*   MockMiddleware.cs
    

Program.cs

* * *

## 5\. Setup and Run

Prerequisites:

*   .NET 8 SDK
    
*   Visual Studio or VS Code
    

Run the project:

dotnet build  
dotnet run

Default URL:

https://localhost:5001

* * *

## 6\. Available APIs

### 6.1 Auth API

Endpoint: POST /auth

Description:  
Simulates Aadhaar authentication request.

* * *

### 6.2 OTP API

Send OTP:  
POST /otp/send

Request Body:  
{  
"uid": "123456789012"  
}

Description:  
Generates OTP for given Aadhaar number.

* * *

Verify OTP:  
POST /otp/verify

Request Body:  
{  
"uid": "123456789012",  
"otp": "123456"  
}

Description:  
Validates OTP.

* * *

### 6.3 KYC API

Endpoint: GET /kyc/{uid}

Description:  
Returns mock KYC XML response.

* * *

## 7\. Sample KYC Response

<KycRes> <UidData> <Poi name="John Doe" dob="01-01-1990" gender="M" /> <Poa dist="Mumbai" state="MH" pc="400001" /> </UidData> </KycRes>

* * *

## 8\. Mock Data

Location:  
Data/AadhaarMockData.cs

Contains:

*   Aadhaar Number
    
*   Name
    
*   Date of Birth
    
*   Gender
    
*   Address details
    

* * *

## 9\. Integration Flow

ADV API calls MockUIDAI

MockUIDAI returns KYC XML

ADV system uses XML for encryption and storage

* * *

## 10\. Notes

*   This is a mock server only
    
*   No real UIDAI integration
    
*   OTP and authentication are simulated
    
*   Not suitable for production use
    

* * *

## 11\. Future Improvements

*   Add dynamic Aadhaar data generation
    
*   Add failure scenarios (invalid OTP, failed auth)
    
*   Add request validation
    
*   Add logging and tracing
