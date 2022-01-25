// HTTP CODES
export enum HttpStatusCode {
  NoResponse = 0,
  Success = 200,
  PartialContent = 206,
  Unauthorized = 401,
  Forbidden = 403,
  ValidationMessage = 422,
  ServiceUnavailable = 503,
}
