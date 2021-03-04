<a name='assembly'></a>
# Application

## Contents

- [AuthenticationController](#T-Application-Controllers-AuthenticationController 'Application.Controllers.AuthenticationController')
  - [AuthenticateExternalUser(request)](#M-Application-Controllers-AuthenticationController-AuthenticateExternalUser-Application-Requests-Authentication-UserLogonRequest- 'Application.Controllers.AuthenticationController.AuthenticateExternalUser(Application.Requests.Authentication.UserLogonRequest)')
  - [AuthenticateInternalUser(request)](#M-Application-Controllers-AuthenticationController-AuthenticateInternalUser-Application-Requests-Authentication-UserLogonRequest- 'Application.Controllers.AuthenticationController.AuthenticateInternalUser(Application.Requests.Authentication.UserLogonRequest)')
  - [Login()](#M-Application-Controllers-AuthenticationController-Login 'Application.Controllers.AuthenticationController.Login')
- [BaseController](#T-Application-Controllers-BaseController 'Application.Controllers.BaseController')
  - [GetSessionUser()](#M-Application-Controllers-BaseController-GetSessionUser 'Application.Controllers.BaseController.GetSessionUser')
- [QuoteResponseController](#T-Application-Controllers-QuoteResponseController 'Application.Controllers.QuoteResponseController')
  - [Create(newResponse)](#M-Application-Controllers-QuoteResponseController-Create-Services-EntityFramework-DbEntities-QuoteResponse- 'Application.Controllers.QuoteResponseController.Create(Services.EntityFramework.DbEntities.QuoteResponse)')
  - [QuoteResponseModal(request)](#M-Application-Controllers-QuoteResponseController-QuoteResponseModal-Application-Requests-Vendor-BaseQuoteRequest- 'Application.Controllers.QuoteResponseController.QuoteResponseModal(Application.Requests.Vendor.BaseQuoteRequest)')
- [VendorHomeController](#T-Application-Controllers-VendorHomeController 'Application.Controllers.VendorHomeController')
  - [Index()](#M-Application-Controllers-VendorHomeController-Index 'Application.Controllers.VendorHomeController.Index')

<a name='T-Application-Controllers-AuthenticationController'></a>
## AuthenticationController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-AuthenticationController-AuthenticateExternalUser-Application-Requests-Authentication-UserLogonRequest-'></a>
### AuthenticateExternalUser(request) `method`

##### Summary

Authenticates external vendor users into the system. Will redirect them to their homepage

##### Returns

Returns a json result to tell the javascript if their login was successful

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Authentication.UserLogonRequest](#T-Application-Requests-Authentication-UserLogonRequest 'Application.Requests.Authentication.UserLogonRequest') | Request asks for their email address |

<a name='M-Application-Controllers-AuthenticationController-AuthenticateInternalUser-Application-Requests-Authentication-UserLogonRequest-'></a>
### AuthenticateInternalUser(request) `method`

##### Summary

Authenticates abc users into the system. Will redirect them to their homepage

##### Returns

Returns a json result to tell the javascript if their login was successful

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Authentication.UserLogonRequest](#T-Application-Requests-Authentication-UserLogonRequest 'Application.Requests.Authentication.UserLogonRequest') | Request asks for their email address |

<a name='M-Application-Controllers-AuthenticationController-Login'></a>
### Login() `method`

##### Summary

Used for loading the login screen

##### Returns

Returns a login screen for external and internal users.

##### Parameters

This method has no parameters.

<a name='T-Application-Controllers-BaseController'></a>
## BaseController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-BaseController-GetSessionUser'></a>
### GetSessionUser() `method`

##### Summary

Used as a shared mthod across all controllers to quickly access the 
current user session.

##### Returns

Returns the active user session, will reutrn null if there is no user session

##### Parameters

This method has no parameters.

<a name='T-Application-Controllers-QuoteResponseController'></a>
## QuoteResponseController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-QuoteResponseController-Create-Services-EntityFramework-DbEntities-QuoteResponse-'></a>
### Create(newResponse) `method`

##### Summary

For creating a new quote response for a given quote. Used by external vendor users

##### Returns

Quote response object asks for a price and a text response.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newResponse | [Services.EntityFramework.DbEntities.QuoteResponse](#T-Services-EntityFramework-DbEntities-QuoteResponse 'Services.EntityFramework.DbEntities.QuoteResponse') | Wull respond with a json object for the javascript to determine if the request has been completed |

<a name='M-Application-Controllers-QuoteResponseController-QuoteResponseModal-Application-Requests-Vendor-BaseQuoteRequest-'></a>
### QuoteResponseModal(request) `method`

##### Summary

Loads up the html for the modal that allows for external vendor users
to respond to a specific quote

##### Returns

Returns a html string for the javascript to render in a modal

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Vendor.BaseQuoteRequest](#T-Application-Requests-Vendor-BaseQuoteRequest 'Application.Requests.Vendor.BaseQuoteRequest') | Requests a quote id fot the associated quote |

<a name='T-Application-Controllers-VendorHomeController'></a>
## VendorHomeController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-VendorHomeController-Index'></a>
### Index() `method`

##### Summary

This is for the home screen of external users, it will load up a list of thier current
quotes that are active for the vendor that they work for.

##### Returns

Returns a View

##### Parameters

This method has no parameters.
