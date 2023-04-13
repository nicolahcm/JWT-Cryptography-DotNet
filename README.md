

1. The token can be generated with Sha256 or Sha512 (and probably other algorithms), still the validateToken method,
	even though does not take as parameter the Cryptography algorithm, still can validate it right (probably it tries
	different algorithms, or..?)


2. 
	new TokenValidationParameters()
	{
		ValidateLifetime = true, // It checks the expiration time
		ValidateAudience = true, // Checks that the Audience value of the token, has been generated with value Audience = "Sample"
		ValidateIssuer = false,   // Because there is no issuer in the generated token
		ValidAudience = "Sample",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
	};

If the token is expired, then .ValidateToken returns false with such TokenValidationParameters.
If the Audience value with which it has been created is different from "Sample", then .ValidateToken returns false with such TokenValidationParameters.


3. To read the data of the token:
	var res = (new JwtSecurityTokenHandler()).ReadJwtToken(token1);

4. Seems to be that the key has to have at least 16 characters
