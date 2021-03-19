<a name='assembly'></a>
# Application

## Contents

- [AuthenticationController](#T-Application-Controllers-AuthenticationController 'Application.Controllers.AuthenticationController')
  - [AuthenticateExternalUser(request)](#M-Application-Controllers-AuthenticationController-AuthenticateExternalUser-Application-Requests-Authentication-UserLogonRequest- 'Application.Controllers.AuthenticationController.AuthenticateExternalUser(Application.Requests.Authentication.UserLogonRequest)')
  - [AuthenticateInternalUser(request)](#M-Application-Controllers-AuthenticationController-AuthenticateInternalUser-Application-Requests-Authentication-UserLogonRequest- 'Application.Controllers.AuthenticationController.AuthenticateInternalUser(Application.Requests.Authentication.UserLogonRequest)')
  - [Login()](#M-Application-Controllers-AuthenticationController-Login 'Application.Controllers.AuthenticationController.Login')
- [BaseController](#T-Application-Controllers-BaseController 'Application.Controllers.BaseController')
  - [GetSessionUser()](#M-Application-Controllers-BaseController-GetSessionUser 'Application.Controllers.BaseController.GetSessionUser')
- [HomeController](#T-Application-Controllers-HomeController 'Application.Controllers.HomeController')
  - [Index()](#M-Application-Controllers-HomeController-Index 'Application.Controllers.HomeController.Index')
  - [VendorMenu()](#M-Application-Controllers-HomeController-VendorMenu 'Application.Controllers.HomeController.VendorMenu')
- [InternalResponseController](#T-Application-Controllers-InternalResponseController 'Application.Controllers.InternalResponseController')
  - [QuoteResponderModal(request)](#M-Application-Controllers-InternalResponseController-QuoteResponderModal-Application-Requests-Vendor-BaseQuoteRequest- 'Application.Controllers.InternalResponseController.QuoteResponderModal(Application.Requests.Vendor.BaseQuoteRequest)')
  - [Respond(request)](#M-Application-Controllers-InternalResponseController-Respond-Application-Requests-Vendor-BaseQuoteRequest- 'Application.Controllers.InternalResponseController.Respond(Application.Requests.Vendor.BaseQuoteRequest)')
  - [VendorQuotes()](#M-Application-Controllers-InternalResponseController-VendorQuotes 'Application.Controllers.InternalResponseController.VendorQuotes')
- [QuoteResponseController](#T-Application-Controllers-QuoteResponseController 'Application.Controllers.QuoteResponseController')
  - [Create(newResponse)](#M-Application-Controllers-QuoteResponseController-Create-Services-EntityFramework-DbEntities-QuoteResponse- 'Application.Controllers.QuoteResponseController.Create(Services.EntityFramework.DbEntities.QuoteResponse)')
  - [QuoteResponseModal(request)](#M-Application-Controllers-QuoteResponseController-QuoteResponseModal-Application-Requests-Vendor-BaseQuoteRequest- 'Application.Controllers.QuoteResponseController.QuoteResponseModal(Application.Requests.Vendor.BaseQuoteRequest)')
- [VendorCatalogueController](#T-Application-Controllers-VendorCatalogueController 'Application.Controllers.VendorCatalogueController')
  - [Index()](#M-Application-Controllers-VendorCatalogueController-Index 'Application.Controllers.VendorCatalogueController.Index')
  - [RequestVendorQuote(request)](#M-Application-Controllers-VendorCatalogueController-RequestVendorQuote-Application-Requests-QuoteRequest-VendorQuoteRequest- 'Application.Controllers.VendorCatalogueController.RequestVendorQuote(Application.Requests.QuoteRequest.VendorQuoteRequest)')
  - [VendorCatalogueSearch(searchTerm)](#M-Application-Controllers-VendorCatalogueController-VendorCatalogueSearch-System-String- 'Application.Controllers.VendorCatalogueController.VendorCatalogueSearch(System.String)')
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
| request | [Application.Requests.Authentication.UserLogonRequest](#T-Application-Requests-Authentication-UserLogonRequest 'Application.Requests.Authentication.UserLogonRequest') | Request asks for their email address and password |

<a name='M-Application-Controllers-AuthenticationController-AuthenticateInternalUser-Application-Requests-Authentication-UserLogonRequest-'></a>
### AuthenticateInternalUser(request) `method`

##### Summary

Authenticates abc users into the system. Will redirect them to their homepage

##### Returns

Returns a json result to tell the javascript if their login was successful

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Authentication.UserLogonRequest](#T-Application-Requests-Authentication-UserLogonRequest 'Application.Requests.Authentication.UserLogonRequest') | Request asks for their email address and password |

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

<a name='T-Application-Controllers-HomeController'></a>
## HomeController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-HomeController-Index'></a>
### Index() `method`

##### Summary

The homescreen for the internal users. It is loaded straight after logging in and displays
a grid of possible further menus.

##### Returns

Returns a View

##### Parameters

This method has no parameters.

<a name='M-Application-Controllers-HomeController-VendorMenu'></a>
### VendorMenu() `method`

##### Summary

The internal vendor management menu, it is accessed from the homescreen.
This menu splits into 3 vendor related menus: Vendor Catalogue, Vendor List and Vendor Quotes.

##### Returns

Returns a View

##### Parameters

This method has no parameters.

<a name='T-Application-Controllers-InternalResponseController'></a>
## InternalResponseController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-InternalResponseController-QuoteResponderModal-Application-Requests-Vendor-BaseQuoteRequest-'></a>
### QuoteResponderModal(request) `method`

##### Summary

Loads the Quote Responder modal when 'Open Quote' button is pressed on a quote.
The modal contains all previous responses for the loaded quote and an ability to approve/reject 
the quote if it is awaiting a response.

##### Returns

Returns a JsonResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Vendor.BaseQuoteRequest](#T-Application-Requests-Vendor-BaseQuoteRequest 'Application.Requests.Vendor.BaseQuoteRequest') |  |

<a name='M-Application-Controllers-InternalResponseController-Respond-Application-Requests-Vendor-BaseQuoteRequest-'></a>
### Respond(request) `method`

##### Summary

Is called when an internal user on the Vendor Quotes page responds to quote from within a Quote Responder Modal.
The quote is updated when the user either approves or rejects it.

##### Returns

Returns a JsonResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.Vendor.BaseQuoteRequest](#T-Application-Requests-Vendor-BaseQuoteRequest 'Application.Requests.Vendor.BaseQuoteRequest') |  |

<a name='M-Application-Controllers-InternalResponseController-VendorQuotes'></a>
### VendorQuotes() `method`

##### Summary

Loads the internal Vendor Quotes page. 
A list of all vendor quotes and their statuses are displayed here.

##### Returns

Returns a View

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

<a name='T-Application-Controllers-VendorCatalogueController'></a>
## VendorCatalogueController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-VendorCatalogueController-Index'></a>
### Index() `method`

##### Summary

Loads the view for the vendor catalogue. The vendor catalogue loads all vendor items and displays them in a list.
Users can request quotes for vendor items from this page.

##### Returns

Returns a View

##### Parameters

This method has no parameters.

<a name='M-Application-Controllers-VendorCatalogueController-RequestVendorQuote-Application-Requests-QuoteRequest-VendorQuoteRequest-'></a>
### RequestVendorQuote(request) `method`

##### Summary

Called when a user requests a quote for an item in the Vendor Catalogue.
The quote is created and can be seen on the 'Vendor Quotes' page.

##### Returns

Returns a JsonResult with success data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [Application.Requests.QuoteRequest.VendorQuoteRequest](#T-Application-Requests-QuoteRequest-VendorQuoteRequest 'Application.Requests.QuoteRequest.VendorQuoteRequest') |  |

<a name='M-Application-Controllers-VendorCatalogueController-VendorCatalogueSearch-System-String-'></a>
### VendorCatalogueSearch(searchTerm) `method`

##### Summary

Searches the vendor items using the search term. 
Called when an item is searched for in the Vendor Catalogue.

##### Returns

Returns the Vendor Catalogue View with a filtered list of items

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchTerm | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Application-Controllers-VendorHomeController'></a>
## VendorHomeController `type`

##### Namespace

Application.Controllers

<a name='M-Application-Controllers-VendorHomeController-Index'></a>
### Index() `method`

##### Summary

This is for the home screen of external users, it will load up a list of their current
quotes that are active for the vendor that they work for.

##### Returns

Returns a View

##### Parameters

This method has no parameters.
