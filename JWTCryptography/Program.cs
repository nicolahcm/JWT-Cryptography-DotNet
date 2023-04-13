// See https://aka.ms/new-console-template for more information
using JWTCryptography;
using System.IdentityModel.Tokens.Jwt;


JWT jwt = new JWT();

string token = jwt.GenerateToken();
bool result = jwt.ValidateToken(token);

// Read values of token
var tokenHandler = new JwtSecurityTokenHandler();
var res = tokenHandler.ReadJwtToken(token);