# Asp.Net Core 3 Web Api

Practice demonstration of Asp.Net Core 3 Web Api

- [Asp.Net Core 3 Web Api](#aspnet-core-3-web-api)
  - [Roadmap](#roadmap)

My intention is to eventually build this into a full working application writting in Asp dotNet Core 3+ web api starting.

## Roadmap

Architecture:

- [x] Integrate swagger api
- [ ] Allow database connectionstring to be read from environment variables
- [ ] Use Command Query Separation (CQS) pattern
- [ ] Add Guard Clauses: [GuardClauses](https://github.com/ardalis/GuardClauses)
- [ ] Automapper utilities: [Retrieving Property name from lambda expression](https://stackoverflow.com/a/52305334/939634)
- [ ] Exception handler
- [x] Versioning -- fetch api format: **api/v{version:apiVersion}/[controller]/{other-url}** | example: **api/v1.0/user/users**
- [ ] Token authentication: [overview](https://medium.com/@samueleresca/developing-token-authentication-using-asp-net-core-c3fbd7bfd7cb)
- [ ] Implement [ULID](https://github.com/ulid/spec) instead of GUID/ULID for Ids. See this [note written by Steven van Deursen](https://blogs.cuttingedge.it/steven/posts/2012/returning-data-from-command-handlers/)
- [ ] Authorize access
- [ ] OData

Funtionality:
