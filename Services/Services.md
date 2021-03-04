<a name='assembly'></a>
# Services

## Contents

- [GlobalActionFilter](#T-Services-Filters-GlobalActionFilter 'Services.Filters.GlobalActionFilter')
  - [OnActionExecutionAsync(context,next)](#M-Services-Filters-GlobalActionFilter-OnActionExecutionAsync-Microsoft-AspNetCore-Mvc-Filters-ActionExecutingContext,Microsoft-AspNetCore-Mvc-Filters-ActionExecutionDelegate- 'Services.Filters.GlobalActionFilter.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)')
- [IAuthenticationManager](#T-Services-AuthenticationManagement-IAuthenticationManager 'Services.AuthenticationManagement.IAuthenticationManager')
  - [AuthenticateExternalUser(sessionContext,email)](#M-Services-AuthenticationManagement-IAuthenticationManager-AuthenticateExternalUser-Microsoft-AspNetCore-Http-ISession,System-String- 'Services.AuthenticationManagement.IAuthenticationManager.AuthenticateExternalUser(Microsoft.AspNetCore.Http.ISession,System.String)')
  - [AuthenticateInternalUser(sessionContext,email)](#M-Services-AuthenticationManagement-IAuthenticationManager-AuthenticateInternalUser-Microsoft-AspNetCore-Http-ISession,System-String- 'Services.AuthenticationManagement.IAuthenticationManager.AuthenticateInternalUser(Microsoft.AspNetCore.Http.ISession,System.String)')
  - [GetSessionUser(sessionContext)](#M-Services-AuthenticationManagement-IAuthenticationManager-GetSessionUser-Microsoft-AspNetCore-Http-ISession- 'Services.AuthenticationManagement.IAuthenticationManager.GetSessionUser(Microsoft.AspNetCore.Http.ISession)')
- [IGenericQuerier](#T-Services-GenericRepository-IGenericQuerier 'Services.GenericRepository.IGenericQuerier')
  - [LoadDbSet\`\`1()](#M-Services-GenericRepository-IGenericQuerier-LoadDbSet``1 'Services.GenericRepository.IGenericQuerier.LoadDbSet``1')
  - [LoadEntity\`\`1(where)](#M-Services-GenericRepository-IGenericQuerier-LoadEntity``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'Services.GenericRepository.IGenericQuerier.LoadEntity``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
  - [Load\`\`2(select,where)](#M-Services-GenericRepository-IGenericQuerier-Load``2-System-Linq-Expressions-Expression{System-Func{``0,``1}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'Services.GenericRepository.IGenericQuerier.Load``2(System.Linq.Expressions.Expression{System.Func{``0,``1}},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})')
- [IGenericRepo](#T-Services-GenericRepository-IGenericRepo 'Services.GenericRepository.IGenericRepo')
  - [AddRange\`\`1()](#M-Services-GenericRepository-IGenericRepo-AddRange``1-System-Collections-Generic-List{``0}- 'Services.GenericRepository.IGenericRepo.AddRange``1(System.Collections.Generic.List{``0})')
  - [Add\`\`1()](#M-Services-GenericRepository-IGenericRepo-Add``1-``0- 'Services.GenericRepository.IGenericRepo.Add``1(``0)')
  - [RemoveRange\`\`1()](#M-Services-GenericRepository-IGenericRepo-RemoveRange``1-System-Collections-Generic-List{``0}- 'Services.GenericRepository.IGenericRepo.RemoveRange``1(System.Collections.Generic.List{``0})')
  - [Remove\`\`1()](#M-Services-GenericRepository-IGenericRepo-Remove``1-``0- 'Services.GenericRepository.IGenericRepo.Remove``1(``0)')
  - [SaveChanges()](#M-Services-GenericRepository-IGenericRepo-SaveChanges 'Services.GenericRepository.IGenericRepo.SaveChanges')
- [IQuoteManager](#T-Services-QuoteManagement-IQuoteManager 'Services.QuoteManagement.IQuoteManager')
  - [GetQuote(quoteID)](#M-Services-QuoteManagement-IQuoteManager-GetQuote-System-Int32- 'Services.QuoteManagement.IQuoteManager.GetQuote(System.Int32)')
  - [GetQuotes()](#M-Services-QuoteManagement-IQuoteManager-GetQuotes 'Services.QuoteManagement.IQuoteManager.GetQuotes')
  - [GetVendorQuotes(vendorID)](#M-Services-QuoteManagement-IQuoteManager-GetVendorQuotes-System-Int32- 'Services.QuoteManagement.IQuoteManager.GetVendorQuotes(System.Int32)')
  - [RequestQuote(item,quantity)](#M-Services-QuoteManagement-IQuoteManager-RequestQuote-Services-Models-DTOs-VendorItemDTO,System-Int32- 'Services.QuoteManagement.IQuoteManager.RequestQuote(Services.Models.DTOs.VendorItemDTO,System.Int32)')
- [IQuoteResponseManager](#T-Services-QuoteResponseManagement-IQuoteResponseManager 'Services.QuoteResponseManagement.IQuoteResponseManager')
  - [Create(response)](#M-Services-QuoteResponseManagement-IQuoteResponseManager-Create-Services-EntityFramework-DbEntities-QuoteResponse- 'Services.QuoteResponseManagement.IQuoteResponseManager.Create(Services.EntityFramework.DbEntities.QuoteResponse)')
- [IUserManager](#T-Services-UserManagement-IUserManager 'Services.UserManagement.IUserManager')
  - [GetExternalUser(userID)](#M-Services-UserManagement-IUserManager-GetExternalUser-System-Int32- 'Services.UserManagement.IUserManager.GetExternalUser(System.Int32)')
- [IVendorItemManager](#T-Services-VendorItemManagement-IVendorItemManager 'Services.VendorItemManagement.IVendorItemManager')
  - [LoadVendorItem(ID)](#M-Services-VendorItemManagement-IVendorItemManager-LoadVendorItem-System-Int32- 'Services.VendorItemManagement.IVendorItemManager.LoadVendorItem(System.Int32)')
  - [LoadVendorItems()](#M-Services-VendorItemManagement-IVendorItemManager-LoadVendorItems 'Services.VendorItemManagement.IVendorItemManager.LoadVendorItems')
  - [SearchVendorItems(searchString)](#M-Services-VendorItemManagement-IVendorItemManager-SearchVendorItems-System-String- 'Services.VendorItemManagement.IVendorItemManager.SearchVendorItems(System.String)')
- [IVendorManager](#T-Services-VendorManagement-IVendorManager 'Services.VendorManagement.IVendorManager')
  - [GetVendor(vendorId)](#M-Services-VendorManagement-IVendorManager-GetVendor-System-Int32- 'Services.VendorManagement.IVendorManager.GetVendor(System.Int32)')
- [SessionHelper](#T-Services-SessionManagement-Helpers-SessionHelper 'Services.SessionManagement.Helpers.SessionHelper')
  - [GetUserSession(session)](#M-Services-SessionManagement-Helpers-SessionHelper-GetUserSession-Microsoft-AspNetCore-Http-ISession- 'Services.SessionManagement.Helpers.SessionHelper.GetUserSession(Microsoft.AspNetCore.Http.ISession)')
  - [Get\`\`1(session,key)](#M-Services-SessionManagement-Helpers-SessionHelper-Get``1-Microsoft-AspNetCore-Http-ISession,System-String- 'Services.SessionManagement.Helpers.SessionHelper.Get``1(Microsoft.AspNetCore.Http.ISession,System.String)')
  - [HasUserSession(session)](#M-Services-SessionManagement-Helpers-SessionHelper-HasUserSession-Microsoft-AspNetCore-Http-ISession- 'Services.SessionManagement.Helpers.SessionHelper.HasUserSession(Microsoft.AspNetCore.Http.ISession)')
  - [Set\`\`1(session,key,value)](#M-Services-SessionManagement-Helpers-SessionHelper-Set``1-Microsoft-AspNetCore-Http-ISession,System-String,``0- 'Services.SessionManagement.Helpers.SessionHelper.Set``1(Microsoft.AspNetCore.Http.ISession,System.String,``0)')

<a name='T-Services-Filters-GlobalActionFilter'></a>
## GlobalActionFilter `type`

##### Namespace

Services.Filters

<a name='M-Services-Filters-GlobalActionFilter-OnActionExecutionAsync-Microsoft-AspNetCore-Mvc-Filters-ActionExecutingContext,Microsoft-AspNetCore-Mvc-Filters-ActionExecutionDelegate-'></a>
### OnActionExecutionAsync(context,next) `method`

##### Summary

This method is called everytime a controller action is called. It ensures that the user in the current session has access to the action.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext](#T-Microsoft-AspNetCore-Mvc-Filters-ActionExecutingContext 'Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext') | Current HttpContext |
| next | [Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate](#T-Microsoft-AspNetCore-Mvc-Filters-ActionExecutionDelegate 'Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate') | The intended action method. |

<a name='T-Services-AuthenticationManagement-IAuthenticationManager'></a>
## IAuthenticationManager `type`

##### Namespace

Services.AuthenticationManagement

<a name='M-Services-AuthenticationManagement-IAuthenticationManager-AuthenticateExternalUser-Microsoft-AspNetCore-Http-ISession,System-String-'></a>
### AuthenticateExternalUser(sessionContext,email) `method`

##### Summary

For authenticating external users. (Part of the login process)

##### Returns

Void

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionContext | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') |  |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Users email address |

<a name='M-Services-AuthenticationManagement-IAuthenticationManager-AuthenticateInternalUser-Microsoft-AspNetCore-Http-ISession,System-String-'></a>
### AuthenticateInternalUser(sessionContext,email) `method`

##### Summary

For authenticating internal users. (Part of the login process)

##### Returns

Void

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionContext | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') |  |
| email | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Users email address |

<a name='M-Services-AuthenticationManagement-IAuthenticationManager-GetSessionUser-Microsoft-AspNetCore-Http-ISession-'></a>
### GetSessionUser(sessionContext) `method`

##### Summary

Get a users current session user external or internal, will return null if the user does
not have a logged in session.

##### Returns

Abstract user, an abstract instance of both an external or internal user.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sessionContext | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') |  |

<a name='T-Services-GenericRepository-IGenericQuerier'></a>
## IGenericQuerier `type`

##### Namespace

Services.GenericRepository

##### Summary

This is a generic query manager that subtracts the need
 for entity repositories.

<a name='M-Services-GenericRepository-IGenericQuerier-LoadDbSet``1'></a>
### LoadDbSet\`\`1() `method`

##### Summary

Load db set from the db. Not suitable for loading large amounts of data as it keeps it's reference. 
 Use with caution. Entity mappings should be done with [Load\`\`2](#M-Services-GenericRepository-IGenericQuerier-Load``2-System-Linq-Expressions-Expression{System-Func{``0,``1}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}- 'Services.GenericRepository.IGenericQuerier.Load``2(System.Linq.Expressions.Expression{System.Func{``0,``1}},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})') when loading large dataset that do not need to be edited.

##### Returns

Db set from the data base of type.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TEntity | Must be of type that belongs to the entities generated by the entity framework scaffold |

<a name='M-Services-GenericRepository-IGenericQuerier-LoadEntity``1-System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### LoadEntity\`\`1(where) `method`

##### Summary

Directly loads an entity from the database and keeps its references. If an entity from this result is altered and save changes is called it will be modified on the database end too.
Used for grabbing entities for deletion and updating.

##### Returns

Returns an entity with links to the dbset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| where | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | That satisfy a specific predicate. If this is no required user [LoadDbSet\`\`1](#M-Services-GenericRepository-IGenericQuerier-LoadDbSet``1 'Services.GenericRepository.IGenericQuerier.LoadDbSet``1') |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs to the entities generated by the entity framework scaffold |

<a name='M-Services-GenericRepository-IGenericQuerier-Load``2-System-Linq-Expressions-Expression{System-Func{``0,``1}},System-Linq-Expressions-Expression{System-Func{``0,System-Boolean}}-'></a>
### Load\`\`2(select,where) `method`

##### Summary

Load a dbset entity and map it into a dto with an optional where statement.

##### Returns

Returns an IQueryable of the entity which is executed once an async method is called on it. E.g. ToListAsync()

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| select | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1}}') | The map statement. |
| where | [System.Linq.Expressions.Expression{System.Func{\`\`0,System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}}') | Optional where statement. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs to the entities generated by the entity framework scaffold |
| EntityDTO | Must be the mapping object that is no an object of the dbsets. |

<a name='T-Services-GenericRepository-IGenericRepo'></a>
## IGenericRepo `type`

##### Namespace

Services.GenericRepository

##### Summary

This is a generic repository that subtracts the need for entity repositories.

<a name='M-Services-GenericRepository-IGenericRepo-AddRange``1-System-Collections-Generic-List{``0}-'></a>
### AddRange\`\`1() `method`

##### Summary

Add a multiple rows to the database.

##### Returns

An integer for how many rows in the db have been affected.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs the entites generated by entity frameworks scaffold/ |

<a name='M-Services-GenericRepository-IGenericRepo-Add``1-``0-'></a>
### Add\`\`1() `method`

##### Summary

Add a row to the database.

##### Returns

An integer for how many rows in the db have been affected.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs the entites generated by entity frameworks scaffold/ |

<a name='M-Services-GenericRepository-IGenericRepo-RemoveRange``1-System-Collections-Generic-List{``0}-'></a>
### RemoveRange\`\`1() `method`

##### Summary

Remove rows from the database.

##### Returns

An integer for how many rows in the db have been affected.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs the entites generated by entity frameworks scaffold/ |

<a name='M-Services-GenericRepository-IGenericRepo-Remove``1-``0-'></a>
### Remove\`\`1() `method`

##### Summary

Remove a row from the database.

##### Returns

An integer for how many rows in the db have been affected.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| Entity | Must be of type that belongs the entites generated by entity frameworks scaffold/ |

<a name='M-Services-GenericRepository-IGenericRepo-SaveChanges'></a>
### SaveChanges() `method`

##### Summary

Used after editing dbset entities.

##### Returns

An integer for how many rows in the db have been affected.

##### Parameters

This method has no parameters.

<a name='T-Services-QuoteManagement-IQuoteManager'></a>
## IQuoteManager `type`

##### Namespace

Services.QuoteManagement

<a name='M-Services-QuoteManagement-IQuoteManager-GetQuote-System-Int32-'></a>
### GetQuote(quoteID) `method`

##### Summary

A full quote with its summary and quote responses if it has any

##### Returns

Returns a quote

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| quoteID | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Unique identifier for the quote |

<a name='M-Services-QuoteManagement-IQuoteManager-GetQuotes'></a>
### GetQuotes() `method`

##### Summary

Load all quotes that are currently on the system

##### Returns

A List of quotes

##### Parameters

This method has no parameters.

<a name='M-Services-QuoteManagement-IQuoteManager-GetVendorQuotes-System-Int32-'></a>
### GetVendorQuotes(vendorID) `method`

##### Summary

Get a list of all quotes associated with a specific vendor

##### Returns

Returns a list of quote overviews, the quote overview object is a small summaty of the quote without its quote responses attatched.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vendorID | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Unique vendor id |

<a name='M-Services-QuoteManagement-IQuoteManager-RequestQuote-Services-Models-DTOs-VendorItemDTO,System-Int32-'></a>
### RequestQuote(item,quantity) `method`

##### Summary

Used to request a quote from a vendor

##### Returns

Returns a bool, true if the request is created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [Services.Models.DTOs.VendorItemDTO](#T-Services-Models-DTOs-VendorItemDTO 'Services.Models.DTOs.VendorItemDTO') | The item in question |
| quantity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The amount of the item in question requested |

<a name='T-Services-QuoteResponseManagement-IQuoteResponseManager'></a>
## IQuoteResponseManager `type`

##### Namespace

Services.QuoteResponseManagement

<a name='M-Services-QuoteResponseManagement-IQuoteResponseManager-Create-Services-EntityFramework-DbEntities-QuoteResponse-'></a>
### Create(response) `method`

##### Summary

Create a quote response

##### Returns

Returns a boolean, will be true of the response is successfully created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [Services.EntityFramework.DbEntities.QuoteResponse](#T-Services-EntityFramework-DbEntities-QuoteResponse 'Services.EntityFramework.DbEntities.QuoteResponse') | Takes in a quoete response object which asks for a quote id associated with the response, a response text and a price. |

<a name='T-Services-UserManagement-IUserManager'></a>
## IUserManager `type`

##### Namespace

Services.UserManagement

<a name='M-Services-UserManagement-IUserManager-GetExternalUser-System-Int32-'></a>
### GetExternalUser(userID) `method`

##### Summary

Load External user, this user is a user from outside of the abcs internal system

##### Returns

Returns the external user object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userID | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Unique id for that user |

<a name='T-Services-VendorItemManagement-IVendorItemManager'></a>
## IVendorItemManager `type`

##### Namespace

Services.VendorItemManagement

<a name='M-Services-VendorItemManagement-IVendorItemManager-LoadVendorItem-System-Int32-'></a>
### LoadVendorItem(ID) `method`

##### Summary

Get a vendor item associated with a specific id

##### Returns

Returns a vendor item specific to the give id

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ID | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Requires a vendor items unique id. |

<a name='M-Services-VendorItemManagement-IVendorItemManager-LoadVendorItems'></a>
### LoadVendorItems() `method`

##### Summary

Load all vendor items that are in the abc system

##### Returns

A list of vendro items containiing thier details such as name and description.

##### Parameters

This method has no parameters.

<a name='M-Services-VendorItemManagement-IVendorItemManager-SearchVendorItems-System-String-'></a>
### SearchVendorItems(searchString) `method`

##### Summary

Search vendor item by seeing ifthe given string is contained within the items namn

##### Returns

Can return a list of 1 - x or an empty list if nothing is found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Search string |

<a name='T-Services-VendorManagement-IVendorManager'></a>
## IVendorManager `type`

##### Namespace

Services.VendorManagement

<a name='M-Services-VendorManagement-IVendorManager-GetVendor-System-Int32-'></a>
### GetVendor(vendorId) `method`

##### Summary

Loading vendor entity, for vendors associateed with abc

##### Returns

Returns a vendor dto

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vendorId | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Use a vendors unique id to get. |

<a name='T-Services-SessionManagement-Helpers-SessionHelper'></a>
## SessionHelper `type`

##### Namespace

Services.SessionManagement.Helpers

<a name='M-Services-SessionManagement-Helpers-SessionHelper-GetUserSession-Microsoft-AspNetCore-Http-ISession-'></a>
### GetUserSession(session) `method`

##### Summary

Used to see if their is a current user session stored in memory

##### Returns

Returns an authenticated session if a user has an exisitng session or will return null if there is no user session

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') | Controller session contexxt |

<a name='M-Services-SessionManagement-Helpers-SessionHelper-Get``1-Microsoft-AspNetCore-Http-ISession,System-String-'></a>
### Get\`\`1(session,key) `method`

##### Summary

Helper for getting custom session objects

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Services-SessionManagement-Helpers-SessionHelper-HasUserSession-Microsoft-AspNetCore-Http-ISession-'></a>
### HasUserSession(session) `method`

##### Summary

Bool checker to see of the current user has a logged in session for either
an external or internal user.

##### Returns

Returns true if there is a user session and false if none was found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') | Session context from a controller |

<a name='M-Services-SessionManagement-Helpers-SessionHelper-Set``1-Microsoft-AspNetCore-Http-ISession,System-String,``0-'></a>
### Set\`\`1(session,key,value) `method`

##### Summary

Helper for setting custom objects in the session

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| session | [Microsoft.AspNetCore.Http.ISession](#T-Microsoft-AspNetCore-Http-ISession 'Microsoft.AspNetCore.Http.ISession') |  |
| key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| value | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
