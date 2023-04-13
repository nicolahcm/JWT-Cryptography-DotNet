using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JWTCryptography
{
	public class JWT
	{
		string key = "1234567890qweasd0";

		public string GenerateToken()
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

			var secToken = new JwtSecurityToken(
				signingCredentials: credentials,
				issuer: "tech1",
				audience: "unknown",
				claims: new[]
				{
			new Claim(JwtRegisteredClaimNames.Sub, "meziantou")
				},
				expires: DateTime.UtcNow.AddDays(1));

			var handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(secToken);
		}

		public bool ValidateToken(string authToken)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var validationParameters = GetValidationParameters();

			SecurityToken validatedToken;
			try {
				IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
				return true;
			} catch (Exception ex)
			{
				return false;
			}
		}

		public TokenValidationParameters GetValidationParameters()
		{
			return new TokenValidationParameters()
			{
				ValidateLifetime = true, 
				ValidateAudience = true, 
				ValidateIssuer = true,   // if set to false, does not check issuer
				ValidIssuer = "tech1",
				ValidAudience = "unknown",
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
			};
		}
		
	}
}
