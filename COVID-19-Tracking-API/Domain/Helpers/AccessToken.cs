using System; 
using System.IdentityModel.Tokens.Jwt;
using System.Text; 
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims; 
using Newtonsoft.Json;
using C19Tracking.API.Resources;

namespace C19Tracking.API.Domain.Helpers
{
    public class AccessToken
    {
        public string GenerateToken(UserResource account, string secretKey) 
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					 new Claim(ClaimTypes.Name, account.UserID.ToString()),
					 new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(account)),
				}),
				Expires = DateTime.UtcNow.AddYears(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
    }
}
